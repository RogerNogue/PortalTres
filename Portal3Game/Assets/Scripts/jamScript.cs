using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jamScript : MonoBehaviour
{
    public int healAmount = 1;
    public AudioClip audioSound;

    private bool scriptUsed = false;
    private AudioSource audioSource;
    private SpriteRenderer spriteGO;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!scriptUsed)
        {
            LifeScript lifeGO = col.gameObject.transform.parent.GetComponentInChildren<LifeScript>();
            lifeGO.currentHP += healAmount;
            audioSource.PlayOneShot(audioSound);
            spriteGO.enabled = false;
            scriptUsed = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteGO = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        
    }
}
