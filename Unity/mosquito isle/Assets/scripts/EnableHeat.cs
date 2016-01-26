using UnityEngine;
using System.Collections;

public class EnableHeat : MonoBehaviour {

    private SkinnedMeshRenderer rend;
    private Shader shader1;
    private Shader shader2;

    private const int distanceToAnimal = 200;

    private ArrayList colourVariations = null;

    GameObject playerTag;
    GameObject[] gorillasSit;
    GameObject[] gorillasMoving;

    private BloodFeeding bf;

    public bool enoughBlood = true;

    // Use this for initialization
    void Start () {
        //Debug.Log(gameObject.name);
        playerTag = GameObject.FindWithTag("Player");
        gorillasSit = GameObject.FindGameObjectsWithTag("GorillaSit");
        gorillasMoving = GameObject.FindGameObjectsWithTag("GorillaMove");
        //Debug.Log( gorillasMoving.Length );
        bf = GameObject.FindObjectOfType<BloodFeeding>();

        
        shader1 = Shader.Find("Custom/ToonBasicAdjusted");
        shader2 = Shader.Find("Toon/Basic");

        colourVariations = new ArrayList();
        colourVariations.Add(new Color(1, 0.549f, 0, 1));
        colourVariations.Add(new Color(1, 0.627f, 0, 1));
        colourVariations.Add(new Color(1, 0.706f, 0, 1));
        colourVariations.Add(new Color(1, 0.804f, 0.33f, 1));
        colourVariations.Add(new Color(1, 0.902f, 0.671f, 1));
        colourVariations.Add(Color.white);

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
                if( enoughBlood == true )
                {
                    rend.material.SetColor("_Color", new Color(1, 0.549f, 0, 1));
                }
                else
                {
                    // make it gradually
                    rend.material.SetColor("_Color", Color.white );
                }
            }
        }

        foreach( GameObject obj in gorillasSit )
        {
            rend = obj.GetComponent<SkinnedMeshRenderer>();
            rend.material.shader = shader2;
            rend.material.SetColor("_Color", Color.white);
            if (calculateDistance(playerTag, obj) <= distanceToAnimal )
            {
                rend.material.shader = shader1;
                if(enoughBlood == true && bf.bloodFeedingCounter == 0) 
                {
                    rend.material.SetColor("_Color", new Color(1, 0.549f, 0, 1));
                }
                else if(enoughBlood == true && bf.bloodFeedingCounter == 1)
                {
                    rend.material.SetColor("_Color", new Color(1, 0.549f, 0, 1));
                }
                else if (enoughBlood == true && bf.bloodFeedingCounter == 2)
                {
                    rend.material.SetColor("_Color", (Color)colourVariations[1]);
                }
                else if (enoughBlood == true && bf.bloodFeedingCounter == 3)
                {
                    rend.material.SetColor("_Color", (Color)colourVariations[2]);
                }
                else if (enoughBlood == true && bf.bloodFeedingCounter == 4)
                {
                    rend.material.SetColor("_Color", (Color)colourVariations[3]);
                }
                else if (enoughBlood == true && bf.bloodFeedingCounter == 5)
                {
                    rend.material.SetColor("_Color", (Color)colourVariations[4]);
                }
                else if(bf.bloodFeedingCounter == 6)
                {
                    rend.material.SetColor("_Color", (Color)colourVariations[5]);
                }
            }
        }
	}
}
