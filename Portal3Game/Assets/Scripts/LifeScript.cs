using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject thirdHeart;

    public GameObject Player;

    public int maxHP;

    public int currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
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

        switch(currentHP)
        {
            case 0:
                firstHeart.SetActive(false);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;

        }
    }
}
