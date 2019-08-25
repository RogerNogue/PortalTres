using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodingBarrel : EvilItemScript
{
    public float explosionDuration;
    public AudioClip explodingSound;

    private AudioSource audioSource;
    private bool exploding = false;
    private float timeOfExplosion;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<CircleCollider2D>().enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(exploding)
        {
            //TODO: run animation
            timeOfExplosion += Time.deltaTime;
            if (timeOfExplosion >= explosionDuration)
            {
                //TODO: explosion ended
                transform.GetComponent<CircleCollider2D>().radius = 0.0F;
                exploding = false;
                //TODO: should make it disappear
                transform.gameObject.SetActive(false);
            }
        }
    }

    public void clicked()
    {
        transform.GetComponent<CircleCollider2D>().enabled = true;
        timeOfExplosion = 0.0F;
        exploding = true;
        audioSource.PlayOneShot(explodingSound);
        //temporal color setting
        transform.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.parent.gameObject.name);
        //if player is invulnerable, we ignore the collision
        if (isInvulnerable(col.transform.parent.gameObject))
        {
            return;
        }
        LifeScript lifeGO = col.transform.parent.gameObject.GetComponent<LifeScript>();
        lifeGO.currentHP -= 1;
        sendDamageSignal(col.transform.parent.gameObject);
    }
}
