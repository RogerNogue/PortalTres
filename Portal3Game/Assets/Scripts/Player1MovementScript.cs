using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MovementScript : MonoBehaviour
{
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //going through input detection modifying the position of the player
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0.0f, playerSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -playerSpeed * Time.deltaTime, 0.0f); 
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(playerSpeed * Time.deltaTime, 0.0f, 0.0f);
        }

    }
}
