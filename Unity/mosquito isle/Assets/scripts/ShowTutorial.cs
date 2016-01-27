using UnityEngine;
using System.Collections;

public class ShowTutorial : MonoBehaviour {

    private GameObject panelTitel;
    private GameObject panelTutorial;

    private bool showTut = false;

    void Start()
    {
        panelTitel = GameObject.FindWithTag("PanelTitel");
        panelTutorial = GameObject.FindWithTag("PanelTutorial");
        panelTutorial.SetActive(false);
    }

    public void showTutorial()
    {
        if( showTut == false  )
        {
            showTut = true;
            panelTitel.SetActive(false);
            panelTutorial.SetActive(true);
        }
        else
        {
            showTut = false;
            panelTitel.SetActive(true);
            panelTutorial.SetActive(false);
        }
    }
}
