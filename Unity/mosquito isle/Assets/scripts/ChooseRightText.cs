using UnityEngine;
using System.Collections;

public class ChooseRightText : MonoBehaviour {

    private GameDataContainer gdc;
    public GameObject titelGameOver;
    public GameObject titelWinner;

	// Use this for initialization
	void Start () {
        gdc = GameDataContainer.FindObjectOfType<GameDataContainer>();

        if(gdc.loosing == true )
        {
            titelGameOver.SetActive(true);
            titelWinner.SetActive(false);
        }
        else if(gdc.loosing == false && gdc.winning2ndLevel == false)
        {
            titelGameOver.SetActive(false);
            titelWinner.SetActive(true);
        }
        else if( gdc.loosing == false && gdc.winning2ndLevel == true )
        {
            titelGameOver.SetActive(false);
            titelWinner.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
