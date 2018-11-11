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
    
    void setPaulyXGateTransform()
    {
        thetaSlider.value = 180 - thetaSlider.value;
        //phiSlider.value = (180 + phiSlider.value)%360;

        phiSlider.value = 360 - phiSlider.value;
        thetaSliderChanged();
        phiSliderChanged();
    }

    void setPaulyYGateTransform()
    {

    }

    void setPaulyZGateTransform()
    {

    }

    void setHadamardGateTransform()
    {

    }

    private void resetQuBitState()
    {
        initializeValues();
    }


    void thetaSliderChanged()
    {
        Debug.Log(thetaSlider.value);
        thetaInput.text = thetaSlider.value.ToString();
        thetaValue = thetaSlider.value;
        updateQBitVector();
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
        //qBitArrow.transform.rotation = Quaternion.LookRotation(new Vector3(getZValue(), getYValue(), getXValue()));
        //Debug.Log("X:" + getXValue() + "--- Y:" + getYValue() + "--- Z:" + getZValue());
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