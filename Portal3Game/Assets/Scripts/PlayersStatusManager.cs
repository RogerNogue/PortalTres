using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersStatusManager : MonoBehaviour
{

    public Image player1Sprite;
    public Image player1HighLight;
    public Image player2Sprite;
    public Image player2HighLight;
    public Button loadNewSceneButton;
    public Text amountHomelessAwoken;

    public bool homelessReady = false;

    // Update is called once per frame
    void Update()
    {
        if (homelessReady)
        {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                player1Sprite.color = Color.green;
                amountHomelessAwoken.text = (int.Parse(amountHomelessAwoken.text) + 1).ToString();
                checkHomelessAwoken(int.Parse(amountHomelessAwoken.text));
            }
            else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                player1Sprite.color = Color.white;
                amountHomelessAwoken.text = (int.Parse(amountHomelessAwoken.text) - 1).ToString();
                checkHomelessAwoken(int.Parse(amountHomelessAwoken.text));
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                player2Sprite.color = Color.green;
                amountHomelessAwoken.text = (int.Parse(amountHomelessAwoken.text) + 1).ToString();
                checkHomelessAwoken(int.Parse(amountHomelessAwoken.text));
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                player2Sprite.color = Color.white;
                amountHomelessAwoken.text = (int.Parse(amountHomelessAwoken.text) - 1).ToString();
                checkHomelessAwoken(int.Parse(amountHomelessAwoken.text));
            }

        }
    }

    private void checkHomelessAwoken(int amount)
    {
        if (amount >= 2)
        {
            loadNewSceneButton.interactable = true;
        } else {
            loadNewSceneButton.interactable = false;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("LevelAA");
    }

}
