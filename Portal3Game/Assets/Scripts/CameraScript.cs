using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    
    public float cameraSpeed;

    public bool catSpeedBoost = false;
    public float speedBoostAmount = 0.0f;

    private Vector3 initialPosition;
    private float totalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(catSpeedBoost)
        {
            totalSpeed = cameraSpeed + speedBoostAmount;
        }
        else
        {
            totalSpeed = cameraSpeed;
        }

        transform.position += new Vector3(totalSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
