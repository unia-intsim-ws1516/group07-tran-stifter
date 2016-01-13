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

    private Downsampling downComp;
    private GameObject tagCameraWithoutBreath;

    // Use this for initialization
    void Start () {
        tagCameraWithoutBreath = GameObject.FindWithTag("MainCamera");
        //Debug.Log("camera found: " + tagCameraWithoutBreath.CompareTag("WithoutBreath"));
        downComp = tagCameraWithoutBreath.GetComponent<Downsampling>();
    }
	
    public void toggleFarClipPlane()
    {
        if (tagCameraWithoutBreath.GetComponent<Camera>().farClipPlane == farClipPlaneMin)
        {
            tagCameraWithoutBreath.GetComponent<Camera>().farClipPlane = farClipPlaneMax;
        }
        else
        {
            tagCameraWithoutBreath.GetComponent<Camera>().farClipPlane = farClipPlaneMin;
        }
    }

    public void toggleColors()
    {
        tagCameraWithoutBreath.GetComponent<ColorCorrectionCurves>().enabled = !colorState;
        colorState = !colorState;
    }
    //aufräumen
    public void setHighResolution(bool high)
    {
        downsamplingHigh = high;
        downsamplingLow = false;
    }

    public void setLowResolution( bool low )
    {
        downsamplingLow = low;
        downsamplingHigh = false;
    }

    public void enableDownsampling( bool moduleEnabled, bool lowEnabled )
    {
        downComp.enabled = moduleEnabled;
        downComp.lowResolution = lowEnabled;
    }

	// Update is called once per frame
	void Update () {
        
        if ( Input.GetKeyDown(KeyCode.F1))
        {
            toggleFarClipPlane();
        }
	    else if (Input.GetKeyDown(KeyCode.F2))
        {
            toggleColors();
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            if( downsamplingHigh == false )
            {
                enableDownsampling(true, false);
                setHighResolution(true);
            }
            else
            {
                enableDownsampling(false, false);
                setHighResolution(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            if (downsamplingLow == false)
            {
                enableDownsampling(true, true);
                setLowResolution(true);
            }
            else
            {
                enableDownsampling(false, false);
                setLowResolution(false);
            }
        }
        //else if (Input.GetKeyDown(KeyCode.F5))
        //{
        //    RenderSettings.fog = !fogState;
        //    fogState = !fogState;
        //}
    }
}
