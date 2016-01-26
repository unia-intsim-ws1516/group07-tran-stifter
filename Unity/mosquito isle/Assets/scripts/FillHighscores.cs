using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FillHighscores : MonoBehaviour {

    public Dictionary<string, int> highscores;
    private int scoreUpperBound = 1000;
    private GameObject np;

	// Use this for initialization
	void Start () {
        np = GameObject.FindWithTag("NamesPoints");

        highscores.Add("S.", 999);
        highscores.Add("Alice", 300);
        highscores.Add("Bob", 645);
        highscores.Add("Nobody", 5);

    }

    public void addNewestHS(string name, int points )
    {

    }

    public void fillHighscoreTable()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
