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
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<BoxCollider2D>().enabled = false;
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
        Debug.Log("BARREL GOTTA ROLL");
        transform.GetComponent<BoxCollider2D>().enabled = true;
        rolling = true;
        //temporal color setting
        transform.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.transform.parent.gameObject.name);
        //if player is invulnerable, we ignore the collision
        if (isInvulnerable(col.transform.parent.gameObject))
        {
            return;
        }
        sendDamageSignal(col.transform.parent.gameObject);
        LifeScript lifeGO = col.transform.parent.gameObject.GetComponent<LifeScript>();
        lifeGO.currentHP -= 1;
    }
}
