using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.parent.tag != "Player1" && collision.transform.parent.tag != "Player2")
        {
            //kill the shit out of him
            collision.transform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.gameObject.SetActive(false);
    }
}
