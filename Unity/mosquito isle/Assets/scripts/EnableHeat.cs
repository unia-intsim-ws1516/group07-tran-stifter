using UnityEngine;
using System.Collections;

public class EnableHeat : MonoBehaviour {

    private SkinnedMeshRenderer rend;
    private Shader shader1;
    private Shader shader2;

    private const int distanceToAnimal = 200;

    GameObject playerTag;
    GameObject[] gorillasSit;
    GameObject[] gorillasMoving;

    // Use this for initialization
    void Start () {
        //Debug.Log(gameObject.name);
        playerTag = GameObject.FindWithTag("Player");
        gorillasSit = GameObject.FindGameObjectsWithTag("GorillaSit");
        gorillasMoving = GameObject.FindGameObjectsWithTag("GorillaMove");
        //Debug.Log( gorillasMoving.Length );

        
        shader1 = Shader.Find("Custom/ToonBasicAdjusted");
        shader2 = Shader.Find("Toon/Basic");

        //rend.material.shader = shader2;
    }

    public int getDistanceToAnimal()
    {
        return distanceToAnimal;
    }

    private float calculateDistance(GameObject player, GameObject animal)
    {        
        return Vector3.Distance(player.transform.position, animal.transform.position);
    }

    // Update is called once per frame
    void Update () {        
        foreach ( GameObject obj in gorillasMoving )
        {
            rend = obj.GetComponent<SkinnedMeshRenderer>();
            //rend.material.shader = shader2;
            //rend.material.SetColor("_Color", Color.white );
            if( calculateDistance( playerTag, obj) <= distanceToAnimal )
            {
                rend.material.shader = shader1;
                rend.material.SetColor("_Color", new Color( 1, 0.549f, 0, 1 ) );
            }
        }

        foreach( GameObject obj in gorillasSit )
        {
            rend = obj.GetComponent<SkinnedMeshRenderer>();
            rend.material.shader = shader2;
            rend.material.SetColor("_Color", Color.white);
            if (calculateDistance(playerTag, obj) <= distanceToAnimal)
            {
                rend.material.shader = shader1;
                rend.material.SetColor("_Color", new Color(1, 0.549f, 0, 1));
            }
        }
	}
}
