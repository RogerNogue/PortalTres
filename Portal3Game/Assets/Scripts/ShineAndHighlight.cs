using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineAndHighlight : MonoBehaviour
{
    public bool used = false;
    public bool mouseHovering = false;
    public Color shineColor;
    public Color highLightedColor;

    public BoxCollider2D colliderInside;
    public Material materialInside;
    private Color originalColor;
    private SpriteRenderer spriteR;


    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponentInChildren<SpriteRenderer>();
        if (name != "ExplodingBarrel")
        {
            originalColor = spriteR.color;
        } else
        {
            originalColor = materialInside.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!used && !mouseHovering)
        {
            if (name != "ExplodingBarrel") {
                spriteR.color = Color.Lerp(Color.white, shineColor, Mathf.PingPong(Time.time, 1.0f));
            } else {
                materialInside.color = Color.Lerp(Color.white, shineColor, Mathf.PingPong(Time.time, 1.0f));
            }
            
        }
    }

    private void OnMouseDown()
    {
        if(!used)
        {
            if(gameObject.name == "Sewer") {
                GetComponentInChildren<SewerCapOpening>().ActivateEvilItem();
                GetComponent<CircleCollider2D>().enabled = false;
                spriteR.color = originalColor;
            } else if (name == "BarrelRolling") {
                GetComponentInChildren<rollingBarrelScript>().clicked();
                spriteR.color = originalColor;
            } else if (name == "ExplodingBarrel") {
                GetComponentInChildren<explodingBarrel>().clicked();
            }

            
            used = true;
        }
    }

    void OnMouseOver()
    {
        if(!used)
        {
            mouseHovering = true;
            if (name != "ExplodingBarrel") {
                spriteR.color = highLightedColor;
            } else {
                materialInside.color = highLightedColor;
            }
        }
    }

    void OnMouseExit()
    {
        if (!used)
        {
            if (name != "ExplodingBarrel")
            {
                mouseHovering = false;
                spriteR.color = originalColor;
            } else {
                materialInside.color = Color.white;
            }
        }
    }

}
