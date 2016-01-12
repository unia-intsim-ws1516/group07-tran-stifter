using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject guiMenu;
    private Camera camWithoutBreath;
    public MosquitoMovement mosqMovement;
    private EnablePPFilters filters;

    private bool menuActive = true;
    private int currentMask=0;


	// Use this for initialization
	void Awake () {
        Debug.Log("gc");
        guiMenu = GameObject.FindWithTag("GUIMenu");
        camWithoutBreath = Camera.main;

        currentMask = camWithoutBreath.cullingMask;
        camWithoutBreath.cullingMask = (1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") |
                    1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("UI") |
                    1 << LayerMask.NameToLayer("basic"));

        guiMenu.SetActive(true);
        mosqMovement.enabled = false;

        filters = GameObject.FindObjectOfType<EnablePPFilters>();
	}

    public void StartGame()
    {
        menuActive = false;
        guiMenu.SetActive(false);
        mosqMovement.enabled = true;

        camWithoutBreath.cullingMask = (1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") |
                    1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("UI") |
                    1 << LayerMask.NameToLayer("basic") | 1 << LayerMask.NameToLayer("with breath") );

        // toggle doesnt work, use t/f
        filters.toggleFarClipPlane();
        filters.toggleHighResolution();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("gc_update");
        if( Input.GetKeyDown(KeyCode.Escape) )
        {
            if( menuActive == false )
            {
                guiMenu.SetActive(true);
                mosqMovement.enabled = false;
                currentMask = camWithoutBreath.cullingMask;
                camWithoutBreath.cullingMask = (1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") | 
                    1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("UI") | 
                    1 << LayerMask.NameToLayer("basic"));
            }
            else
            {
                guiMenu.SetActive(false);
                mosqMovement.enabled = true;
                camWithoutBreath.cullingMask = currentMask;
            }
            menuActive = !menuActive;
        }
	}
}
