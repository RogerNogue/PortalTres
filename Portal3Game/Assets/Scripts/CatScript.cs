using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : EvilItemScript
{

    public CameraScript camScript;
    public float speedBoostAmount;
    public float boostDuration;
    private bool boostActivated;
    private bool scriptUsed = false;
    private float boostTimer;

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
        boostActivated = true;
        camScript.catSpeedBoost = true;
        camScript.speedBoostAmount = speedBoostAmount;
        scriptUsed = true;
            //Change Spritesomehow
        transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
