using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    private const int farclipOne = 650;
    private const int farclipTwo = 450;

    private const int moveSpeedOne = 120;
    private const int moveSpeedTwo = 80;

    //private const string gameOverString = "GAME OVER!";
    //private const string winningString = "YOU WON!";

    private GameDataContainer gdc;
    public ScreenShake screenShakeScript;
    public DockToAnimal dockAnimal;


    public bool successfulBloodFeeding = false;

    private float timerUntilWin = 3.0f;

    private float timerScreenShake = 8.0f;

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
        screenShakeScript = GameObject.FindObjectOfType<ScreenShake>();
        dockAnimal = GameObject.FindObjectOfType<DockToAnimal>();

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
        gdc.timerSimulationTime += Time.deltaTime;

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

        //if( Input.GetKeyDown( KeyCode.F ) )
        //{
        //    screenShakeScript.Shake( 0.16f, 0.008f);
        //}

        //timer for screen shake stuff
        timerScreenShake -= Time.deltaTime;
        if ( timerScreenShake < 0 )
        {
            if (dockAnimal.docked == false)
            {
                screenShakeScript.Shake(0.18f, 0.04f);
            }
            timerScreenShake = Random.Range(10.0f, 60.0f);
        }
	}

    public void loadSecondDifficulty()
    {
        gdc.firstLevel = false;
        Application.LoadLevel(0);
    }

    public bool isSecondLevel()
    {
        return !gdc.firstLevel;
    }

    public void loadHighscoreScene( bool loosing, bool winning2ndLevel )
    {
        gdc.loosing = loosing;
        gdc.winning2ndLevel = winning2ndLevel;
        
        Application.LoadLevel(1);
    }

    public void checkWinningConditionAfterBloodFeeding()
    {
        if( successfulBloodFeeding == true )
        {
            StartCoroutine("SlowTime");
            //this.loadHighscoreScene(false, this.isSecondLevel());
        }
    }

    IEnumerator SlowTime()
    {
        float elapsed = 0.0f;

        while( elapsed < timerUntilWin )
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        this.loadHighscoreScene(false, this.isSecondLevel());        
    }
}
