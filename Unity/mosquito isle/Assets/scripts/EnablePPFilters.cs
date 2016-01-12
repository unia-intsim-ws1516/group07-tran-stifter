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
        tagCameraWithoutBreath = GameObject.FindWithTag("MainCamera");
        //Debug.Log(tagCameraWithoutBreath.CompareTag("WithoutBreath"));
    }
	
    public void toggleFarClipPlane()
    {
        Camera cameraWithoutBreath = tagCameraWithoutBreath.GetComponent<Camera>();
        if (cameraWithoutBreath.farClipPlane == farClipPlaneMin)
        {
            cameraWithoutBreath.farClipPlane = farClipPlaneMax;
        }
        else
        {
            cameraWithoutBreath.farClipPlane = farClipPlaneMin;
        }
    }

    public void toggleColors()
    {
        tagCameraWithoutBreath.GetComponent<ColorCorrectionCurves>().enabled = !colorState;
        colorState = !colorState;
    }
    //aufräumen
    public void setHighResolution()
    {
        Downsampling downComp = tagCameraWithoutBreath.GetComponent<Downsampling>();
        downComp.lowResolution = false;
        downComp.enabled = !downsamplingLow;
        downsamplingLow = !downsamplingLow;
        downsamplingHigh = false;
    }

    public void toggleLowResolution()
    {
        Downsampling downComp = tagCameraWithoutBreath.GetComponent<Downsampling>();
        downComp.lowResolution = true;
        downComp.enabled = !downsamplingHigh;
        downsamplingHigh = !downsamplingHigh;
        downsamplingLow = false;
    }

    

	// Update is called once per frame
	void Update () {

        if( Input.GetKeyDown(KeyCode.F1))
        {
            toggleFarClipPlane();
        }
	    else if (Input.GetKeyDown(KeyCode.F2))
        {
            toggleColors();
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            if( downsamplingHigh == true )
            {
                setHighResolution( false );
            }
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            toggleLowResolution();
        }
        //else if (Input.GetKeyDown(KeyCode.F5))
        //{
        //    RenderSettings.fog = !fogState;
        //    fogState = !fogState;
        //}
    }
}
