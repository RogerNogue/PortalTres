using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilItemScript : MonoBehaviour
{
    bool isInvulnerable(GameObject collided)
    {
        //if player 1 we use the Player1MovementScript
        if(collided.tag == "Player1")
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
    void sendDamageSignal(GameObject collided)
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
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.parent.gameObject.name);
        //if player is invulnerable, we ignore the collision
        if(isInvulnerable(col.transform.parent.gameObject))
        {
            return;
        }
        sendDamageSignal(col.transform.parent.gameObject);
        LifeScript lifeGO = col.transform.parent.gameObject.GetComponent<LifeScript>();
        lifeGO.currentHP -= 1;
    }
}
