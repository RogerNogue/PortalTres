using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject thirdHeart;

    public GameObject Player;

    private BoxCollider2D playerCollider;
    private SpriteRenderer playerSprite;

    public int maxHP;
    private int lastHP;
    public int currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        playerCollider = Player.GetComponentInChildren<BoxCollider2D>();
        playerSprite = Player.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        else if(currentHP < 0)
        {
            //dead idk
        }

        if (lastHP != currentHP) // this will only trigger when gaining health or taking damage. Very useful to have for the death event
        {
            switch (currentHP)
            {
                case 0:
                    firstHeart.SetActive(false);
                    secondHeart.SetActive(false);
                    thirdHeart.SetActive(false);

                    playerSprite.color = Color.green;
                    playerSprite.sortingOrder = -1; //So it paints below the other guy alive
                    playerCollider.enabled = false;
                    break;
                case 1:
                    firstHeart.SetActive(true);
                    secondHeart.SetActive(false);
                    thirdHeart.SetActive(false);
                    break;
                case 2:
                    firstHeart.SetActive(true);
                    secondHeart.SetActive(true);
                    thirdHeart.SetActive(false);
                    break;
                case 3:
                    firstHeart.SetActive(true);
                    secondHeart.SetActive(true);
                    thirdHeart.SetActive(true);
                    break;
            }
        }

        lastHP = currentHP;
    }
}
