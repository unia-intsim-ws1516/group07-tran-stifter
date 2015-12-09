using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class EnablePPFilters : MonoBehaviour {

    public float blurSoftValue = 3.0f;
    public float blurHardValue = 7.5f;

    private bool colorState = false;
    private bool blurSoftState = false;
    private bool blurHardState = false;

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
            BlurOptimized blurComp = gameObject.GetComponent<BlurOptimized>();
            blurComp.enabled = !blurSoftState;
            blurComp.blurSize = blurSoftValue;

            if (blurHardState == true)
            {
                blurHardState = false;
            }

            blurSoftState = !blurSoftState;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            BlurOptimized blurComp = gameObject.GetComponent<BlurOptimized>();
            blurComp.enabled = !blurHardState;
            blurComp.blurSize = blurHardValue;

            if(blurSoftState == true)
            {
                blurSoftState = false;
            }

            blurHardState = !blurHardState;
        }
    }
}
