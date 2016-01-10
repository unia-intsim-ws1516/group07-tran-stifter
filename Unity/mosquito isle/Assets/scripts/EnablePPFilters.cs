using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class EnablePPFilters : MonoBehaviour {

    public int farClipPlaneMin = 500;
    public int farClipPlaneMax = 6000;

    //public float blurSoftValue = 3.0f;
    //public float blurHardValue = 7.5f;

    private bool colorState = false;
    private bool downsamplingLow = false;
    private bool downsamplingHigh = false;

    private bool fogState = false;

    private GameObject tagCameraWithoutBreath;

    // Use this for initialization
    void Start () {
        tagCameraWithoutBreath = GameObject.FindWithTag("WithoutBreath");
        //Debug.Log(tagCameraWithoutBreath.CompareTag("WithoutBreath"));
    }
	
	// Update is called once per frame
	void Update () {

        if( Input.GetKeyDown(KeyCode.F1))
        {
            Camera cameraWithoutBreath = tagCameraWithoutBreath.GetComponent<Camera>();
            if(cameraWithoutBreath.farClipPlane == farClipPlaneMin)
            {
                cameraWithoutBreath.farClipPlane = farClipPlaneMax;
            }
            else
            {
                cameraWithoutBreath.farClipPlane = farClipPlaneMin;
            }
        }
	    else if (Input.GetKeyDown(KeyCode.F2))
        {
            tagCameraWithoutBreath.GetComponent<ColorCorrectionCurves>().enabled = !colorState;
            colorState = !colorState;        
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            Downsampling downComp = tagCameraWithoutBreath.GetComponent<Downsampling>();
            downComp.lowResolution = false;
            downComp.enabled = !downsamplingLow;
            downsamplingLow = !downsamplingLow;
            downsamplingHigh = false;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            Downsampling downComp = tagCameraWithoutBreath.GetComponent<Downsampling>();
            downComp.lowResolution = true;
            downComp.enabled = !downsamplingHigh;
            downsamplingHigh = !downsamplingHigh;
            downsamplingLow = false;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            RenderSettings.fog = !fogState;
            fogState = !fogState;
        }
    }
}
