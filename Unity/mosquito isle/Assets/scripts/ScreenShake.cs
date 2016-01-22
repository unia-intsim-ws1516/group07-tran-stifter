using UnityEngine;
using System.Collections;


public class ScreenShake : MonoBehaviour {

    private const float magnitude = 155.0f;
    private const int duration = 1800;
    private float percentComplete = 0;

    private bool screenshake = false;

    void Update()
    {
        if (screenshake == true)
        {
            Debug.Log("Hallo screen shake");
            float elapsed = 0.0f;

            //Vector3 origCamPos = Camera.main.transform.position;
            Vector3 origPos = GameObject.FindWithTag("Player").transform.position;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                percentComplete = elapsed / duration;
                float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

                float x = Random.value * 2.0f - 1.0f;
                float y = Random.value * 2.0f - 1.0f;

                x *= magnitude * damper;
                y *= magnitude * damper;

                //Camera.main.transform.position = new Vector3(x, y, origCamPos.z);
                GameObject.FindWithTag("Player").transform.position = new Vector3(x, y, origPos.z);
            }
            //Camera.main.transform.position = origCamPos;
            GameObject.FindWithTag("Player").transform.position = origPos;
            screenshake = false;
        }
    }

    public void screenShakeCam()
    {
        screenshake = true;
    }
}
