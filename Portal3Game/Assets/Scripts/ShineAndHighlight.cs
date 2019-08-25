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

    private Color originalColor;
    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteR.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!used && !mouseHovering)
        {
            spriteR.color = Color.Lerp(Color.white, shineColor, Mathf.PingPong(Time.time, 1.0f));
        }
    }

    private void OnMouseDown()
    {
        if(!used)
        {
            if(gameObject.name == "Sewer") {
                GetComponentInChildren<SewerCapOpening>().ActivateEvilItem();
                GetComponent<CircleCollider2D>().enabled = false;
            } else if (name == "BarrelRolling") {
                GetComponentInChildren<rollingBarrelScript>().clicked();
                //GetComponent<BoxCollider2D>().enabled = false;
                //colliderInside.enabled = true;
            }
            spriteR.color = originalColor;
            used = true;
        }
    }

    void OnMouseOver()
    {
        if(!used)
        {
            mouseHovering = true;
            spriteR.color = highLightedColor;
        }
    }

    void OnMouseExit()
    {
        if (!used)
        {
            mouseHovering = false;
            spriteR.color = originalColor;
        }
    }

}
