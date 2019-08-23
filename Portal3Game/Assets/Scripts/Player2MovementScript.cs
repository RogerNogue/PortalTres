using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MovementScript : MonoBehaviour
{
    public float playerSpeed;
    private Vector3 orientationPosition;
    private bool moving;

    void calculateMovementAndDirection()
    {
        //going through input detection modifying the position of the player
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f, playerSpeed * Time.deltaTime, 0.0f);
            orientationPosition.y += 1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0.0f, 0.0f);
            orientationPosition.x -= 1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -playerSpeed * Time.deltaTime, 0.0f);
            orientationPosition.y -= 1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(playerSpeed * Time.deltaTime, 0.0f, 0.0f);
            orientationPosition.x += 1;
            moving = true;
        }
        if (moving)
        {

            transform.rotation = Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f), new Vector3(-orientationPosition.y, orientationPosition.x, orientationPosition.z));

            orientationPosition.x = orientationPosition.y = orientationPosition.z = 0.0f;
            moving = false;

            //maybe later need for lerping: https://answers.unity.com/questions/36255/lookat-to-only-rotate-on-y-axis-how.html
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        orientationPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovementAndDirection();

    }
}