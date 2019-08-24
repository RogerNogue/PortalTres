using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool cameraScrolling = true;

    public GameObject mainCamera;

    private CameraScript camScript;

    // Start is called before the first frame update
    void Start()
    {
        camScript = mainCamera.GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            cameraScrolling = !cameraScrolling;
        }
        if (cameraScrolling)//input
        {
            camScript.enabled = true;
        }
        else
        {
            camScript.enabled = false;
        }
    }
}
