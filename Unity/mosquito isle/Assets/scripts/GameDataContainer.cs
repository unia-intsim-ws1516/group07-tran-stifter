using UnityEngine;
using System.Collections;

public class GameDataContainer : MonoBehaviour {

    public GameObject guiMenu;
    public Camera camWithoutBreath;
    public MosquitoMovement mosqMovement;
    public EnablePPFilters filters;
    public ParticleSystem ps;

    public bool menuActive = true;
    public bool gameStarted = false;
    public bool firstLevel = true;

    public bool loosing = false;
    public bool winning2ndLevel = false;

    public float timerSimulationTime = 0;


    void Awake()
    {
        DontDestroyOnLoad( this );
        guiMenu = GameObject.FindWithTag("GUIMenu");
        camWithoutBreath = Camera.main;
        filters = GameObject.FindObjectOfType<EnablePPFilters>();
        mosqMovement = GameObject.FindObjectOfType<MosquitoMovement>();
        ps = GetComponent<ParticleSystem>();
    }

    public void reinitialiseReferences()
    {
        guiMenu = GameObject.FindWithTag("GUIMenu");
        camWithoutBreath = Camera.main;
        filters = GameObject.FindObjectOfType<EnablePPFilters>();
        mosqMovement = GameObject.FindObjectOfType<MosquitoMovement>();
        ps = GetComponent<ParticleSystem>();
    }

    // Use this for initialization
    void Start () {
        guiMenu = GameObject.FindWithTag("GUIMenu");
        camWithoutBreath = Camera.main;
        filters = GameObject.FindObjectOfType<EnablePPFilters>();
        mosqMovement = GameObject.FindObjectOfType<MosquitoMovement>();
        ps = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
