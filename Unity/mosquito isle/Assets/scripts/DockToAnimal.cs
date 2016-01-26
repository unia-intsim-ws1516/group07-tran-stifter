using UnityEngine;
using System.Collections;

public class DockToAnimal : MonoBehaviour {

    public const int dockingDistance = 100;
    public bool docked = false;

    GameObject playerTag;
    GameObject[] gorillasSit;
    GameObject[] gorillasMoving;
    public GameObject dockedGorilla = null;

    private Camera cam;
    private BloodFeeding bf;
    private GameController gc;
    private ScreenShakeLanding ssl;

    private float timer;

    // Use this for initialization
    void Start () {
        gc = GameController.FindObjectOfType<GameController>();
        playerTag = GameObject.FindWithTag("Player");
        gorillasSit = GameObject.FindGameObjectsWithTag("GorillaSit");
        gorillasMoving = GameObject.FindGameObjectsWithTag("GorillaMove");
        ssl = GameObject.FindObjectOfType<ScreenShakeLanding>();

        cam = Camera.main;
        bf = cam.GetComponent<BloodFeeding>();
    }

    private GameObject findNearestAnimal()
    {
        float minDistance = 10000;
        GameObject objWithMinDistance = null;
        
        foreach( GameObject obj in gorillasMoving)
        {
            float distanceToObj = calculateDistance(playerTag, obj);
            if (  distanceToObj < minDistance)
            {
                minDistance = distanceToObj;
                objWithMinDistance = obj;
            }
        }
        foreach (GameObject obj in gorillasSit)
        {
            float distanceToObj = calculateDistance(playerTag, obj);
            if (distanceToObj < minDistance)
            {
                minDistance = distanceToObj;
                objWithMinDistance = obj;
            }
        }
        return objWithMinDistance;
    }

    private float calculateDistance(GameObject player, GameObject animal)
    {
        return Vector3.Distance(player.transform.position, animal.transform.position);
    }

    // Update is called once per frame
    void Update () {
        GameObject nearestAnimal = findNearestAnimal();

        if( calculateDistance( playerTag, nearestAnimal ) <= dockingDistance  && Input.GetKeyDown(KeyCode.F) )
        {
            //Debug.Log("can dock?");
            playerTag.transform.parent = nearestAnimal.transform;
            playerTag.GetComponent<MosquitoMovement>().enabled = false;
            bf.enabled = true;
            docked = true;
            ssl.Shake(1.6f, 0.2f);
            dockedGorilla = nearestAnimal;
        }
        else if( Input.GetKeyDown(KeyCode.E) )
        {
            playerTag.transform.parent = null;
            playerTag.GetComponent<MosquitoMovement>().enabled = true;
            bf.resetTimer();
            bf.disableStuff();
            bf.enabled = false;
            docked = false;
            gc.checkWinningConditionAfterBloodFeeding();
        }
    }
}
