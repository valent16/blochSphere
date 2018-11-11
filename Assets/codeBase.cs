using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codeBase : MonoBehaviour {

    public float thetaValue;
    public float phiValue;

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
        thetaSlider.value = 0;
        phiSlider.value = 0;
        
        thetaSlider.onValueChanged.AddListener(delegate { thetaSliderChanged(); });
        phiSlider.onValueChanged.AddListener(delegate { phiSliderChanged(); });
        
        //Sets listeners on gates buttons
        PaulyXGate.onClick.AddListener(delegate { setPaulyXGateTransform(); });
        PaulyYGate.onClick.AddListener(delegate { setPaulyYGateTransform(); });
        PaulyZGate.onClick.AddListener(delegate { setPaulyZGateTransform(); });
        HadamardGate.onClick.AddListener(delegate { setHadamardGateTransform(); });

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void setPaulyXGateTransform()
    {

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
    }

}
