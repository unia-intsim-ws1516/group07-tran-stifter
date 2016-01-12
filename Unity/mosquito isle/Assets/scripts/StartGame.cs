using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public GameController gameControllerInstance;

	// Use this for initialization
	void Start () {
        gameControllerInstance = GameObject.FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	public void LoadGame () {
        gameControllerInstance.StartGame();
	}
}
