using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private const int farclipOne = 650;
    private const int farclipTwo = 450;

    private const int moveSpeedOne = 100;
    private const int moveSpeedTwo = 80;

    private GameDataContainer gdc;

    private void setCullingMaskAll()
    {
        gdc.camWithoutBreath.cullingMask = (1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") |
                    1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("UI") |
                    1 << LayerMask.NameToLayer("basic") | 1 << LayerMask.NameToLayer("with breath"));
    }

    private void setCullingMaskRestricted()
    {
        gdc.camWithoutBreath.cullingMask = (1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") |
                    1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("UI") |
                    1 << LayerMask.NameToLayer("basic"));
    }

	// Use this for initialization
	void Awake () {

    }

    void Start()
    {
        gdc = GameObject.FindWithTag("GameData").GetComponent<GameDataContainer>();
        gdc.reinitialiseReferences();

        //Time.timeScale = 0.0f;
        if( gdc.gameStarted==false)
        {
            Time.timeScale = 0.1f;
            gdc.guiMenu.SetActive(true);
            gdc.mosqMovement.enabled = false;
            setCullingMaskRestricted();
        }    
        else
        {
            Time.timeScale = 1.0f;
            gdc.guiMenu.SetActive(false);
            gdc.menuActive = false;
            gdc.mosqMovement.enabled = true;
            setCullingMaskAll();
            gdc.filters.enabled = true;

            if( gdc.firstLevel == true )
            {
                gdc.mosqMovement.moveSpeed = moveSpeedOne;
                gdc.filters.farClipPlaneMin = farclipOne;
                gdc.filters.enableDownsampling(true, false);
                gdc.filters.setHighResolution(true);
            }
            else
            {
                gdc.mosqMovement.moveSpeed = moveSpeedTwo;
                gdc.filters.farClipPlaneMin = farclipTwo;
                gdc.filters.enableDownsampling(true, true);
                gdc.filters.setLowResolution(true);
            }
            gdc.filters.toggleFarClipPlane();
        }   
    }

    public void StartGame()
    {
        gdc.gameStarted = true;
        if (gdc.firstLevel == false)
        {
            gdc.firstLevel = true;
        }
        Application.LoadLevel(0);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("gc_update");
        if( Input.GetKeyDown(KeyCode.Escape) && gdc.gameStarted == true )
        {
            if( gdc.menuActive == false )
            {
                gdc.guiMenu.SetActive(true);
                gdc.mosqMovement.enabled = false;
                setCullingMaskRestricted();
                Time.timeScale = 0.0f;
            }
            else
            {
                gdc.guiMenu.SetActive(false);
                gdc.mosqMovement.enabled = true;
                setCullingMaskAll();
                Time.timeScale = 1.0f;
            }
            gdc.menuActive = !gdc.menuActive;
        }
	}
}
