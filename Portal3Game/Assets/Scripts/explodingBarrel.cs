using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodingBarrel : EvilItemScript
{
    public float explosionDuration;
    public CircleCollider2D parentCollider;
    public AudioClip explodingSound;
    public Animator explosionAnimation;
    private AudioSource audioSource;
    private bool exploding = false;
    private float timeOfExplosion;
    // Start is called before the first frame update
    void Start()
    {
        //transform.GetComponent<CircleCollider2D>().enabled = false;
        audioSource = GetComponentInParent<AudioSource>();
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
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void clicked()
    {
        //transform.GetComponent<CircleCollider2D>().enabled = true;
        timeOfExplosion = 0.0F;
        GetComponentInParent<MeshRenderer>().enabled = false;
        parentCollider.enabled = false;
        GetComponent<CircleCollider2D>().enabled = true;
        exploding = true;
        audioSource.PlayOneShot(explodingSound);
        explosionAnimation.enabled = true;
        //temporal color setting
        //transform.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
        {
            if (isInvulnerable(col.transform.parent.gameObject))
            {
                return;
            }

            LifeScript lifeGO = col.transform.parent.gameObject.GetComponent<LifeScript>();
            lifeGO.currentHP -= 1;
            sendDamageSignal(col.transform.parent.gameObject);
        }
    }
}
