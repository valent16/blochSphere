using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codeBase : MonoBehaviour {
    public const int ThetaInitValue = 0;
    public const int PhiInitValue = 0;

    public float thetaValue = ThetaInitValue;
    public float phiValue = PhiInitValue;

    public Slider thetaSlider;
    public Slider phiSlider;

    public InputField thetaInput;
    public InputField phiInput;

    public GameObject qBitArrow;
    public Toggle vectorPackToggle;


    public Button PaulyXGate;
    public Button PaulyYGate;
    public Button PaulyZGate;
    public Button HadamardGate;

    public Button ResetStateButton;

    //List used when a range of vectors is used
    public List<GameObject> qubitArrows = new List<GameObject>();

    // Use this for initialization
    void Start () {
        initializeValues();
        initializeListeners();
    }

    //Initilizes the listeners of each canvas items
    private void initializeListeners()
    {
        //Sets liteners on sliders
        thetaSlider.onValueChanged.AddListener(delegate { thetaSliderChanged(); });
        phiSlider.onValueChanged.AddListener(delegate { phiSliderChanged(); });

        //Sets listeners on the input box
        thetaInput.onValueChanged.AddListener(delegate { thetaInputChanged(); });
        thetaInput.onEndEdit.AddListener(delegate { checkEndEditThetaValue(); });
        phiInput.onValueChanged.AddListener(delegate { phiInputChanged(); });
        phiInput.onEndEdit.AddListener(delegate { checkEndEditPhiValue(); });

        //Sets listeners on gates buttons
        PaulyXGate.onClick.AddListener(delegate { setPaulyXGateTransform(); });
        PaulyYGate.onClick.AddListener(delegate { setPaulyYGateTransform(); });
        PaulyZGate.onClick.AddListener(delegate { setPaulyZGateTransform(); });
        HadamardGate.onClick.AddListener(delegate { setHadamardGateTransform(); });

        //Sets listener on the reset button
        ResetStateButton.onClick.AddListener(delegate { resetQuBitState(); });
    }

    //Initializes field values 
    private void initializeValues()
    {
        thetaSlider.value = ThetaInitValue;
        phiSlider.value = PhiInitValue;

        thetaInput.contentType = InputField.ContentType.IntegerNumber;
        thetaInput.text = ThetaInitValue.ToString();
        
        phiInput.contentType = InputField.ContentType.IntegerNumber;
        phiInput.text = PhiInitValue.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
    
    //Apply X Pauli gate on the quantum Bit
    void setPaulyXGateTransform()
    {
        thetaSlider.value = 180 - thetaSlider.value;
        phiSlider.value = (360 + 180 - phiSlider.value) % 360;
        thetaSliderChanged();
        phiSliderChanged();
    }

    //Apply Y Pauli gate on the quantum Bit
    void setPaulyYGateTransform()
    {
        thetaSlider.value = 180 - thetaSlider.value;
        phiSlider.value = 360 - phiSlider.value;
        thetaSliderChanged();
        phiSliderChanged();
    }

    //Apply Z Pauli gate on the quantum Bit
    void setPaulyZGateTransform()
    {
        phiSlider.value = (180 + phiSlider.value) % 360;
        phiSliderChanged();
    }

    void setHadamardGateTransform()
    {
        //thetaSlider.value = 180 - thetaSlider.value;
        //phiSlider.value = (360 + 180 - phiSlider.value) % 360;

        //if (thetaSlider.value <= 90 && phiSlider.value <= 180)
        //{
        //    phiSlider.value = 360 - phiSlider.value;
        //}else if (thetaSlider.value <= 90 && phiSlider.value > 180)
        //{
        //    thetaSlider.value = 180 - thetaSlider.value;
        //}else if (thetaSlider.value > 90 && phiSlider.value <= 180)
        //{
        //    thetaSlider.value = 180 - thetaSlider.value;
        //}
        //else
        //{
        //    phiSlider.value = 360 - phiSlider.value;
        //}
        //thetaSliderChanged();
        //phiSliderChanged();
    }

    private void resetQuBitState()
    {
        initializeValues();
    }

    private bool tryParseIntValues(InputField field)
    {
        if (!thetaInput.text.Equals(""))
        {
            int num;
            if (int.TryParse(thetaInput.text, out num))
            {
                return true;
            }
        }
        return false;
    }

    void thetaSliderChanged()
    {
        Debug.Log(thetaSlider.value);
        thetaInput.text = thetaSlider.value.ToString();
        thetaValue = thetaSlider.value;
        updateQBitVector();
    }

    void thetaInputChanged()
    {
        if (tryParseIntValues(thetaInput))
        {
            Debug.Log(thetaInput.text);
            thetaSlider.value = int.Parse(thetaInput.text);
            thetaValue = thetaSlider.value;
            updateQBitVector();
        }
    }

    void phiInputChanged()
    {
        if (tryParseIntValues(phiInput))
        {
            Debug.Log(phiInput.text);
            phiSlider.value = int.Parse(phiInput.text);
            phiValue = phiSlider.value;
            updateQBitVector();
        }
    }

    void checkEndEditThetaValue()
    {
        if (thetaInput.text.Equals(""))
        {
            thetaInput.text = thetaSlider.value.ToString();
            thetaValue = thetaSlider.value;
            updateQBitVector();
        }
    }

    void checkEndEditPhiValue()
    {
        if (phiInput.text.Equals(""))
        {
            phiInput.text = phiSlider.value.ToString();
            phiValue = phiSlider.value;
            updateQBitVector();
        }
    }

    void phiSliderChanged()
    {
        Debug.Log(phiSlider.value);
        phiInput.text = phiSlider.value.ToString();
        phiValue = phiSlider.value;
        updateQBitVector();
    }

    void updateQBitVector()
    {
        qBitArrow.transform.rotation = Quaternion.Euler(this.thetaValue, this.phiValue, 0);
    }

    //return the X value of the direction vector
    float getXValue()
    {
        return Mathf.Sin(phiValue * Mathf.PI / 180) * Mathf.Sin(thetaValue * Mathf.PI / 180 / 2);
    }

    //return the Y value of the direction vector
    float getYValue()
    {
        return Mathf.Cos(phiValue * Mathf.PI / 180) * Mathf.Sin(thetaValue * Mathf.PI / 180 / 2);
    }

    //return the Z value of the direction vector
    float getZValue()
    {
        return Mathf.Cos(thetaValue * Mathf.PI / 180 /2);
    }
}