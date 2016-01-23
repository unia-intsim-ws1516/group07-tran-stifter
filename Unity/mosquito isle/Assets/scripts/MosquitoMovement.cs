using UnityEngine;
using System.Collections;

public class MosquitoMovement : MonoBehaviour {

    private const float speedFactorNormal = 1.0f;
    private const float speedFactorFast = 2.5f;
    private const int fastSpeedTime = 3;

    private float timeRemaining = 120;

    [Range(0,600)]
    public float moveSpeed;
    private float speedFactor;
    
    public ParticleSystem part;
    public ParticleCollisionEvent[] collisionEvents;

    public void setSpeedFactor(bool fast)
    {
        if (fast == true)
        {
            speedFactor = speedFactorFast;
        }
    }

    // Use this for initialization
    void Start () {
        //Debug.Log("test");
        speedFactor = speedFactorNormal;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController cc = (CharacterController)gameObject.GetComponent(typeof(CharacterController));

        if (speedFactor == speedFactorFast)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                speedFactor = speedFactorNormal;
            }
        }


        float rotateSpeed = 6.0f;
        float rotationY = Input.GetAxis("Mouse X") * rotateSpeed * speedFactor;
        transform.Rotate(0, rotationY, 0);

        //float rotateSpeedVertical = 8.0f;
        //float rotationX = Input.GetAxis("Mouse Y") * rotateSpeed;
        //transform.Rotate(rotationX, rotationY, 0);

        float dt = Time.deltaTime;
        float dy = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            dy = moveSpeed * speedFactor * dt;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dy -= moveSpeed * speedFactor * dt;
        }
        float dx = Input.GetAxis("Horizontal") * dt * moveSpeed * speedFactor;
        float dz = Input.GetAxis("Vertical") * dt * moveSpeed * speedFactor;

        cc.Move(transform.TransformDirection(new Vector3(-dx, dy, -dz)));
    }

    //void OnParcticleCollision(GameObject other)
    //{
    //    Debug.Log("yeah");
    //    speedFactor = speedFactorFast;
    //    timeRemaining = fastSpeedTime;
    //}

    public void increaseMovementSpeedTemporarily( )
    {
        Debug.Log("Hallo Movement");
        setSpeedFactor(true);
    }
}
