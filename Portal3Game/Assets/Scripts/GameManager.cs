using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool cameraScrolling = true;

    public GameObject mainCamera;
    public SpriteRenderer redLight;
    private CameraScript camScript;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        camScript = mainCamera.GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraScrolling)//input
        {
            camScript.enabled = true;
        }
        else
        {
            camScript.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            cameraScrolling = !paused;
            redLight.enabled = paused;
        }

        if(paused)
        {
            // Freeze Players / change sprites / etc
            // Trigger police sound
            // enable redLight
            // enable canvas
            redLight.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.6f));
        }

    }
}
