using UnityEngine;
using System.Collections;

public class DockToAnimal : MonoBehaviour {

    public const int dockingDistance = 100;

    GameObject playerTag;
    GameObject[] gorillasSit;
    GameObject[] gorillasMoving;

    // Use this for initialization
    void Start () {
        playerTag = GameObject.FindWithTag("Player");
        gorillasSit = GameObject.FindGameObjectsWithTag("GorillaSit");
        gorillasMoving = GameObject.FindGameObjectsWithTag("GorillaMove");

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
            Debug.Log("can dock?");
            playerTag.transform.parent = nearestAnimal.transform;
            playerTag.GetComponent<MosquitoMovement>().enabled = false;
        }
        else if( Input.GetKeyDown(KeyCode.E) )
        {
            playerTag.transform.parent = null;
            playerTag.GetComponent<MosquitoMovement>().enabled = true;
        }
    }
}
