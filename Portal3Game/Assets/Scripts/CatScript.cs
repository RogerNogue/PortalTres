using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : EvilItemScript
{

    public CameraScript camScript;
    public float speedBoostAmount;
    public float boostDuration;
    public AudioClip[] audioClips;

    private AudioSource audioSource;
    private bool boostActivated;
    private bool scriptUsed = false;
    private float boostTimer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boostActivated)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer > boostDuration)
            {
                camScript.catSpeedBoost = false;
                boostActivated = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if(!scriptUsed)
        {
            int randomInt = Random.Range(0, audioClips.Length);
            audioSource.PlayOneShot(audioClips[randomInt]);
            boostActivated = true;
            camScript.catSpeedBoost = true;
            camScript.speedBoostAmount = speedBoostAmount;
            scriptUsed = true;
            transform.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }
}
