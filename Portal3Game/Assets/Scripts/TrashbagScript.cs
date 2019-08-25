using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbagScript : MonoBehaviour
{
    public GameObject closedGO;
    public GameObject openGO;
    public Player1MovementScript player1Script;
    public Player2MovementScript player2Script;
    public float slowDuration;
    public float slowAmount;

    private bool scriptUsed = false;
    private bool scriptActivated = false;
    private float timer = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if(scriptActivated)
        {
            timer += Time.deltaTime;
            if(timer > slowDuration)
            {
                player1Script.SetSlowAmount(0.0f);
                player2Script.SetSlowAmount(0.0f);

                scriptActivated = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if(!scriptUsed)
        {
            scriptActivated = true;
            player1Script.SetSlowAmount(slowAmount);
            player2Script.SetSlowAmount(slowAmount);
            closedGO.SetActive(false);
            openGO.SetActive(true);
        }
    }
}
