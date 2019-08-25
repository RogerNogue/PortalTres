using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WindScript : MonoBehaviour
{
    public float displacementUpwardsValue;
    public float displacementDownwardsValue;
    public float displacementRightwardsValue;
    public float displacementLeftwardsValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player is invulnerable, we ignore the collision
        if (collision.transform.parent.tag == "Player1")
        {
            Player1MovementScript player1 = collision.transform.parent.GetComponent<Player1MovementScript>();
            player1.upwardsDisplacement += displacementUpwardsValue;
            player1.downwardsDisplacement += displacementDownwardsValue;
            player1.leftwardsDisplacement += displacementLeftwardsValue;
            player1.rightwardsDisplacement += displacementRightwardsValue;
        }
        if (collision.transform.parent.tag == "Player2")
        {
            Player2MovementScript player2 = collision.transform.parent.GetComponent<Player2MovementScript>();
            player2.upwardsDisplacement += displacementUpwardsValue;
            player2.downwardsDisplacement += displacementDownwardsValue;
            player2.leftwardsDisplacement += displacementLeftwardsValue;
            player2.rightwardsDisplacement += displacementRightwardsValue;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.tag == "Player1")
        {
            Player1MovementScript player1 = collision.transform.parent.GetComponent<Player1MovementScript>();
            player1.upwardsDisplacement -= displacementUpwardsValue;
            player1.downwardsDisplacement -= displacementDownwardsValue;
            player1.leftwardsDisplacement -= displacementLeftwardsValue;
            player1.rightwardsDisplacement -= displacementRightwardsValue;
        }
        if (collision.transform.parent.tag == "Player2")
        {
            Player2MovementScript player2 = collision.transform.parent.GetComponent<Player2MovementScript>();
            player2.upwardsDisplacement -= displacementUpwardsValue;
            player2.downwardsDisplacement -= displacementDownwardsValue;
            player2.leftwardsDisplacement -= displacementLeftwardsValue;
            player2.rightwardsDisplacement -= displacementRightwardsValue;
        }
    }
}
