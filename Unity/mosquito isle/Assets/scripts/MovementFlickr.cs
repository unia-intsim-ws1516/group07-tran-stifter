using UnityEngine;
using System.Collections;

public class MovementFlickr : MonoBehaviour {
    private int counter = 0;
    private int step = 8;
    //private bool locked = false;

    private SkinnedMeshRenderer rend;
    private Shader shader1;
    private Shader shader2;

    public EnableHeat heatScript;
    private int distanceToAnimalInFlickr;
    private GameObject playerTag;

    // Use this for initialization
    void Start () {
        playerTag = GameObject.FindWithTag("Player");

        distanceToAnimalInFlickr = heatScript.getDistanceToAnimal();
        
        rend = GetComponent<SkinnedMeshRenderer>();
        shader1 = Shader.Find("Custom/ToonOutlineAdjusted");
        shader2 = Shader.Find("Toon/Basic");
	}
	
	// Update is called once per frame
    void Update () {
        if( calculateDistance( playerTag, this.gameObject ) > distanceToAnimalInFlickr )
        {
            if (counter % step == 0)
            {
                rend.material.shader = shader1;
            }
            else if (counter % step == (int)(step / 2))
            {
                rend.material.shader = shader2;
            }
            counter++;
        }        
	}

    private float calculateDistance(GameObject player, GameObject animal)
    {
        return Vector3.Distance(player.transform.position, animal.transform.position);
    }
}
