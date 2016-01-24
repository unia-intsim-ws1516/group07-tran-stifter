using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class BloodFeeding : MonoBehaviour {

    public float timer = 3.0f;
    private const float timerTime = 3.0f;

    private GameObject tagCameraWithoutBreath;
    private DockToAnimal dock;
    private ScreenShakeFeeding ssf;

    // Use this for initialization
    void Start () {
        tagCameraWithoutBreath = GameObject.FindWithTag("MainCamera");
        dock = GameObject.FindObjectOfType<DockToAnimal>();
        ssf = tagCameraWithoutBreath.GetComponentInParent<ScreenShakeFeeding>();
    }
	
	// Update is called once per frame
	void Update () {
        if( dock.docked == true )
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                tagCameraWithoutBreath.GetComponent<VignetteAndChromaticAberration>().enabled = true;
                ssf.enabled = true;
                if( ssf.shakeing == false )
                {
                    ssf.Shake(0.1f, 0.003f);
                    ssf.shakeing = true;
                }
                //ssf.shakeing = true;
            }
        }        
	}

    public void resetTimer()
    {
        timer = timerTime;
    }

    public void disableStuff()
    {
        tagCameraWithoutBreath.GetComponent<VignetteAndChromaticAberration>().enabled = false;
        ssf.shakeing = false;
        ssf.enabled = false;
    }
}
