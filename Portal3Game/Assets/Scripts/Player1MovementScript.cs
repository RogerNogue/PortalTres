using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MovementScript : MonoBehaviour
{
    public float playerSpeed;
    public float sprintSpeedBonus;
    public float sprintDuration;


    private GameObject playerTrail;
    private LifeScript lifeGO;
    private Vector3 orientationPosition;
    private bool moving;
    private float sprintTimer = 0.0f;
    private bool sprinting = false;
    private float totalSpeed;


    void calculateMovementAndDirection()
    {        
        if(Input.GetKeyDown("left shift") && !sprinting)
        {
            sprinting = true;
            playerTrail.SetActive(true);
            lifeGO.currentHP -= 1;
        }
         
        if(sprinting && sprintTimer < sprintDuration)
        {
            totalSpeed = playerSpeed + sprintSpeedBonus;
            sprintTimer += Time.deltaTime;
        }
        else
        {
            totalSpeed = playerSpeed;
            playerTrail.SetActive(false);
            sprintTimer = 0.0f;
            sprinting = false;
        }

        //going through input detection modifying the position of the player
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0.0f, totalSpeed * Time.deltaTime, 0.0f);
            orientationPosition.y += 1;
            moving = true;
        }
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-totalSpeed * Time.deltaTime, 0.0f, 0.0f);
            orientationPosition.x -= 1;
            moving = true;
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -totalSpeed * Time.deltaTime, 0.0f);
            orientationPosition.y -= 1;
            moving = true;
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(totalSpeed * Time.deltaTime, 0.0f, 0.0f);
            orientationPosition.x += 1;
            moving = true;
        }
        if(moving)
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
        playerTrail = GetComponentInChildren<TrailRenderer>().gameObject;
        lifeGO = GetComponent<LifeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeGO.currentHP > 0)
        {
            calculateMovementAndDirection();
        }
    }
}
