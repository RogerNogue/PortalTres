using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WindScript : MonoBehaviour
{
    public float displacementUpwardsValue;
    public float displacementDownwardsValue;
    public float displacementRightwardsValue;
    public float displacementLeftwardsValue;

    public bool activated = true;

    float currentDisplacementUpwardsValue;
    float currentDisplacementDownwardsValue;
    float currentDisplacementRightwardsValue;
    float currentDisplacementLeftwardsValue;

    Player1MovementScript pl1;
    bool gotPlayer1 = false;
    Player2MovementScript pl2;
    bool gotPlayer2 = false;

    void Start()
    {
        currentDisplacementUpwardsValue = displacementUpwardsValue;
        currentDisplacementDownwardsValue = displacementDownwardsValue;
        currentDisplacementRightwardsValue = displacementRightwardsValue;
        currentDisplacementLeftwardsValue = displacementLeftwardsValue;
    }

    void addWindForceToAPlayer1(Player1MovementScript p)
    {
        p.upwardsDisplacement += currentDisplacementUpwardsValue;
        p.downwardsDisplacement += currentDisplacementDownwardsValue;
        p.leftwardsDisplacement += currentDisplacementLeftwardsValue;
        p.rightwardsDisplacement += currentDisplacementRightwardsValue;
    }
    void addWindForceToAPlayer2(Player2MovementScript p)
    {
        p.upwardsDisplacement += currentDisplacementUpwardsValue;
        p.downwardsDisplacement += currentDisplacementDownwardsValue;
        p.leftwardsDisplacement += currentDisplacementLeftwardsValue;
        p.rightwardsDisplacement += currentDisplacementRightwardsValue;
    }

    void substractWindForceToAPlayer1(Player1MovementScript p)
    {
        p.upwardsDisplacement -= currentDisplacementUpwardsValue;
        p.downwardsDisplacement -= currentDisplacementDownwardsValue;
        p.leftwardsDisplacement -= currentDisplacementLeftwardsValue;
        p.rightwardsDisplacement -= currentDisplacementRightwardsValue;
    }
    void substractWindForceToAPlayer2(Player2MovementScript p)
    {
        p.upwardsDisplacement -= currentDisplacementUpwardsValue;
        p.downwardsDisplacement -= currentDisplacementDownwardsValue;
        p.leftwardsDisplacement -= currentDisplacementLeftwardsValue;
        p.rightwardsDisplacement -= currentDisplacementRightwardsValue;
    }

    public void toggled()
    {
        activated = !activated;
        if(activated)
        {
            turnedOn();
            transform.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            turnedOff();
            transform.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    void turnedOff()
    {
        //if any player was inside, change their stuff
        if (gotPlayer1)
        {
            substractWindForceToAPlayer1(pl1);
        }
        if (gotPlayer2)
        {
            substractWindForceToAPlayer2(pl2);
        }
        currentDisplacementUpwardsValue = 0.0f;
        currentDisplacementDownwardsValue = 0.0f;
        currentDisplacementRightwardsValue = 0.0f;
        currentDisplacementLeftwardsValue = 0.0f;
    }
    void turnedOn()
    {
        currentDisplacementUpwardsValue = displacementUpwardsValue;
        currentDisplacementDownwardsValue = displacementDownwardsValue;
        currentDisplacementRightwardsValue = displacementRightwardsValue;
        currentDisplacementLeftwardsValue = displacementLeftwardsValue;
        if (gotPlayer1)
        {
            addWindForceToAPlayer1(pl1);
        }
        if (gotPlayer2)
        {
            addWindForceToAPlayer2(pl2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player is invulnerable, we ignore the collision
        if (collision.transform.parent.tag == "Player1")
        {
            pl1 = collision.transform.parent.GetComponent<Player1MovementScript>();
            addWindForceToAPlayer1(pl1);
            gotPlayer1 = true;
        }
        if (collision.transform.parent.tag == "Player2")
        {
            pl2 = collision.transform.parent.GetComponent<Player2MovementScript>();
            addWindForceToAPlayer2(pl2);
            gotPlayer2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.tag == "Player1")
        {
            pl1 = collision.transform.parent.GetComponent<Player1MovementScript>();
            substractWindForceToAPlayer1(pl1);
            gotPlayer1 = false;
        }
        if (collision.transform.parent.tag == "Player2")
        {
            pl2 = collision.transform.parent.GetComponent<Player2MovementScript>();
            substractWindForceToAPlayer2(pl2);
            gotPlayer2 = false;
        }
    }
}
