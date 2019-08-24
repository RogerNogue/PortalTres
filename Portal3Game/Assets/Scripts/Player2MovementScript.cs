using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MovementScript : MonoBehaviour
{

    public float playerSpeed;
    public float sprintSpeedBonus;
    public float sprintDuration;
    public float invulnerabilityDurationOnHit;
    public float blinkSwitchTimer;

    private GameObject playerTrail;
    private LifeScript lifeGO;
    private Vector3 orientationPosition;
    private bool moving;
    private float sprintTimer = 0.0f;
    private bool sprinting = false;
    private float totalSpeed;
    private bool invulnerable;//can be consulted via function
    private float hitTime;
    private float lastBlinkTime;

    void calculateMovementAndDirection()
    {
        if (Input.GetKeyDown("right shift") && !sprinting)
        {
            sprinting = true;
            lifeGO.currentHP -= 1;
            playerTrail.SetActive(true);
        }

        if (sprinting && sprintTimer < sprintDuration)
        {
            totalSpeed = playerSpeed + sprintSpeedBonus;
            sprintTimer += Time.deltaTime;
        }
        else
        {
            totalSpeed = playerSpeed;
            sprintTimer = 0.0f;
            playerTrail.SetActive(false);
            sprinting = false;
        }

        //going through input detection modifying the position of the player
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f, totalSpeed * Time.deltaTime, 0.0f);
            orientationPosition.y += 1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-totalSpeed * Time.deltaTime, 0.0f, 0.0f);
            orientationPosition.x -= 1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -totalSpeed * Time.deltaTime, 0.0f);
            orientationPosition.y -= 1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(totalSpeed * Time.deltaTime, 0.0f, 0.0f);
            orientationPosition.x += 1;
            moving = true;
        }
        if (moving)
        {

            transform.rotation = Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1.0f), new Vector3(-orientationPosition.y, orientationPosition.x, orientationPosition.z));

            orientationPosition.x = orientationPosition.y = orientationPosition.z = 0.0f;
            moving = false;

            //maybe later need for lerping: https://answers.unity.com/questions/36255/lookat-to-only-rotate-on-y-axis-how.html
        }

    }
    public bool isInvulnerable()
    {
        return invulnerable;
    }

    void blink()
    {
        transform.GetComponentInChildren<SpriteRenderer>().enabled = !transform.GetComponentInChildren<SpriteRenderer>().enabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        orientationPosition = transform.position;
        lifeGO = GetComponent<LifeScript>();
        playerTrail = GetComponentInChildren<TrailRenderer>().gameObject;
        transform.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    //Player got hit
    public void gotDamaged()
    {
        //make invulnerable
        invulnerable = true;
        //store the hit time
        hitTime = 0.0F;
        //make disappear to start making it blink
        transform.GetComponentInChildren<SpriteRenderer>().enabled = false;
        //store blink timer
        lastBlinkTime = hitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeGO.currentHP > 0)
        {
            calculateMovementAndDirection();
        }
        //if got hit and is invulnerable, we make the necessary calculations
        if (invulnerable)
        {
            hitTime += Time.deltaTime;
            //check invulnerable timer and make sprite blink if is invulnerable
            if (hitTime < invulnerabilityDurationOnHit)
            {
                lastBlinkTime += Time.deltaTime;
                if (lastBlinkTime > blinkSwitchTimer)
                {
                    lastBlinkTime = 0.0F;
                    blink();
                }
            }
            //ensure sprite is active if not blinking
            else
            {
                invulnerable = false;
                transform.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }

        }
    }
}