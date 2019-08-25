﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerCapOpening : MonoBehaviour
{
    private bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!used && Input.GetMouseButtonDown(0))
        {
            used = true;
            transform.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            transform.gameObject.GetComponent<Animator>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.parent.gameObject.name);
        //if player is invulnerable, we ignore the collision
        if (isInvulnerable(col.transform.parent.gameObject))
        {
            return;
        }
        sendDamageSignal(col.transform.parent.gameObject);
        LifeScript lifeGO = col.transform.parent.gameObject.GetComponent<LifeScript>();
        lifeGO.currentHP -= 1;
    }

    protected bool isInvulnerable(GameObject collided)
    {
        //if player 1 we use the Player1MovementScript
        if (collided.tag == "Player1")
        {
            return collided.GetComponent<Player1MovementScript>().isInvulnerable();
        }

        //if player 2 we use the Player2MovementScript
        if (collided.tag == "Player2")
        {
            return collided.GetComponent<Player2MovementScript>().isInvulnerable();
        }
        return false;
    }
    protected void sendDamageSignal(GameObject collided)
    {
        if (collided.tag == "Player1")
        {
            collided.GetComponent<Player1MovementScript>().gotDamaged();
        }
        //if player 2 we use the Player2MovementScript
        else if (collided.tag == "Player2")
        {
            collided.GetComponent<Player2MovementScript>().gotDamaged();
        }
    }
}
