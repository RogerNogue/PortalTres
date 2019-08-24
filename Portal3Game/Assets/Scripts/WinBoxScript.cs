using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBoxScript : MonoBehaviour
{
    public GameManager GameManagerScript;

    private string winnerName;

    private void OnTriggerEnter2D(Collider2D col)
    {
        winnerName = col.transform.parent.name;
        if(winnerName == "Homeless_1")
        {
            GameManagerScript.SetWin(1);
        }
        else if(winnerName == "Homeless_2")
        {
            GameManagerScript.SetWin(2);
        }
    }
}
