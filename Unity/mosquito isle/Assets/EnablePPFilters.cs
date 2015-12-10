using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class EnablePPFilters : MonoBehaviour {

    public float blurSoftValue = 3.0f;
    public float blurHardValue = 7.5f;

    private bool colorState = false;
    private bool downsampling = false;
    private bool blurHardState = false;
    private bool fogState = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.F2))
        {
            gameObject.GetComponent<ColorCorrectionCurves>().enabled = !colorState;
            colorState = !colorState;        
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            Downsampling downComp = gameObject.GetComponent<Downsampling>();
            downComp.enabled = !downsampling;
            downsampling = !downsampling;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            BlurOptimized blurComp = gameObject.GetComponent<BlurOptimized>();
            blurComp.enabled = !blurHardState;
            blurComp.blurSize = blurHardValue;

            blurHardState = !blurHardState;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            RenderSettings.fog = !fogState;
            fogState = !fogState;
        }
    }
}
