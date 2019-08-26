using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingBarrelScript : EvilItemScript
{
    public float upwardsSpeed;
    public float rightSpeed;
    public float leftSpeed;
    public float downwardsSpeed;

    private bool rolling = false;
    private Animator barrelAnimator;
    // Start is called before the first frame update
    void Start()
    {
        barrelAnimator = GetComponentInChildren<Animator>();
        GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rolling)
        {
            transform.position += new Vector3((rightSpeed - leftSpeed) * Time.deltaTime, (upwardsSpeed - downwardsSpeed) * Time.deltaTime, 0.0f);
        }
    }

    public void clicked()
    {
        GetComponent<AudioSource>().enabled = true;
        //transform.GetComponentInChildren<BoxCollider2D>().enabled = true;
        barrelAnimator.enabled = true;
        rolling = true;
        //temporal color setting
        transform.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if player is invulnerable, we ignore the collision
        if (rolling)
        {
            if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
            {
                if (isInvulnerable(collision.transform.gameObject))
                {
                    return;
                }
            
                LifeScript lifeGO = collision.transform.gameObject.GetComponent<LifeScript>();
                lifeGO.currentHP -= 1;
                sendDamageSignal(collision.transform.gameObject);
            }
            GetComponent<AudioSource>().enabled = false;
            rolling = false;
            barrelAnimator.enabled = false;
            gameObject.GetComponent<ShineAndHighlight>().enabled = false;
            enabled = false;
        }

    }
    
}
