using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    private int width = 30;
    private int height = 20;
    private bool fullscreen = false;

    new void Start()
    {
        Screen.SetResolution(width, height, fullscreen, 0);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
