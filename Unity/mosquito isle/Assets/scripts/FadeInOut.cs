using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeInOut : MonoBehaviour
{
    public GameDataContainer gdc;

    void Start()
    {
        gdc = GameObject.FindObjectOfType<GameDataContainer>();
    }

    //function to be called on button click
    public void LoadNextLevel(string name)
    {
        StartCoroutine(LevelLoad(name));
    }

    //load level after one sceond delay
    IEnumerator LevelLoad(string name)
    {
        yield return new WaitForSeconds(1f);

        //insert logic for differentiating between success and no success
        gdc.firstLevel = false;
        Application.LoadLevel(name);
    }
}

