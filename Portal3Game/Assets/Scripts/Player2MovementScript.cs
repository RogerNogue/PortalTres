using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MovementScript : MonoBehaviour
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f, playerSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -playerSpeed * Time.deltaTime, 0.0f); 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(playerSpeed * Time.deltaTime, 0.0f, 0.0f);
        }

    }
}
