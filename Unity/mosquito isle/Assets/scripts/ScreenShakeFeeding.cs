using UnityEngine;
using System.Collections;

public class ScreenShakeFeeding : MonoBehaviour {

    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay;
    public float shake_intensity = 0.0f;

    public bool shakeing = false;

    void Start()
    {

    }

    void Update()
    {
        if (shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
            shake_intensity -= shake_decay;
            if(shake_intensity <= 0)
            {
                // change later
                Debug.Break();
            }
        }
    }

    public void Shake(float intensity, float decay)
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = intensity;
        shake_decay = decay;
    }
}
