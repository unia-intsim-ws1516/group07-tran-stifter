using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject guiMenu;
    private Camera camWithoutBreath;
    public MosquitoMovement mosqMovement;
    private EnablePPFilters filters;

    private bool menuActive = true;
    private bool firstStart = true;

    private void setCullingMaskAll()
    {
        camWithoutBreath.cullingMask = (1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") |
                    1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("UI") |
                    1 << LayerMask.NameToLayer("basic") | 1 << LayerMask.NameToLayer("with breath"));
    }

    private void setCullingMaskRestricted()
    {
        camWithoutBreath.cullingMask = (1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") |
                    1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("UI") |
                    1 << LayerMask.NameToLayer("basic"));
    }

	// Use this for initialization
	void Awake () {
        Debug.Log("gc");
        guiMenu = GameObject.FindWithTag("GUIMenu");
        camWithoutBreath = Camera.main;
        filters = GameObject.FindObjectOfType<EnablePPFilters>();
    }

    void Start()
    {
        // Time.timeScale = 0.0; USE THIS INSTEAD OF DIFFERENT SCENES
        Debug.Log(Application.loadedLevel);
        if (Application.loadedLevel == 0)
        {
            guiMenu.SetActive(true);
            mosqMovement.enabled = false;
            setCullingMaskRestricted();
            firstStart = false;
        }
        else
        {
            menuActive = false;
            guiMenu.SetActive(false);
            mosqMovement.enabled = true;

            filters.toggleFarClipPlane();
            filters.setHighResolution(true);
            filters.enableDownsampling(true, false);
            setCullingMaskAll();
        }
    }

    public void StartGame()
    {
        Application.LoadLevel(0);
        //menuActive = false;
        //guiMenu.SetActive(false);
        //mosqMovement.enabled = true;

        //filters.toggleFarClipPlane();
        //filters.setHighResolution( true );
        //filters.enableDownsampling(true, false);
        //setCullingMaskAll();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("gc_update");
        if( Input.GetKeyDown(KeyCode.Escape) )
        {
            if( menuActive == false )
            {
                guiMenu.SetActive(true);
                mosqMovement.enabled = false;
                setCullingMaskRestricted();
            }
            else
            {
                guiMenu.SetActive(false);
                mosqMovement.enabled = true;
                setCullingMaskAll();
            }
            menuActive = !menuActive;
        }
	}
}
