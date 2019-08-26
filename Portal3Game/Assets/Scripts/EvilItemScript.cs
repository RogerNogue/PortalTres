using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilItemScript : MonoBehaviour
{
    protected bool isInvulnerable(GameObject collided)
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

    protected void sendDamageSignal(GameObject collided)
    {
        if (collided.tag == "Player1")
        {
            collided.GetComponent<Player1MovementScript>().gotDamaged();
        }
        else if (collided.tag == "Player2")
        {
            collided.GetComponent<Player2MovementScript>().gotDamaged();
        }
    }
}
