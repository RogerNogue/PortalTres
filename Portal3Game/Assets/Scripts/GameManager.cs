using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool cameraScrolling = true;
    public GameObject player1;
    public GameObject player2;

    private Player1MovementScript player1Script;
    private Player2MovementScript player2Script;
    private SpriteRenderer player1Renderer;
    private SpriteRenderer player2Renderer;
    private Color player1Color;
    private Color player2Color;
    private LifeScript player1Life;
    private LifeScript player2Life;

    public GameObject mainCamera;
    public SpriteRenderer redLight;
    private CameraScript camScript;
    private bool paused = false;

    void ManagePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            cameraScrolling = !paused;
            redLight.enabled = paused;

            if (paused)
            {
                if (player1Life.currentHP > 0)
                {
                    player1Script.enabled = false;
                    player1Renderer.color = Color.black;
                }
                if (player2Life.currentHP > 0)
                {
                    player2Script.enabled = false;
                    player2Renderer.color = Color.black;
                }
            }
            else
            {
                if (player1Life.currentHP > 0)
                {
                    player1Script.enabled = true;
                    player1Renderer.color = player1Color;
                }
                if (player2Life.currentHP > 0)
                {
                    player2Script.enabled = true;
                    player2Renderer.color = player2Color;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        camScript = mainCamera.GetComponent<CameraScript>();
        player1Script = player1.GetComponent<Player1MovementScript>();
        player2Script = player2.GetComponent<Player2MovementScript>();
        player1Renderer = player1.GetComponentInChildren<SpriteRenderer>();
        player2Renderer = player2.GetComponentInChildren<SpriteRenderer>();
        player1Color = player1Renderer.color;
        player2Color = player2Renderer.color;
        player1Life = player1.GetComponent<LifeScript>();
        player2Life = player2.GetComponent<LifeScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraScrolling)//input
        {
            camScript.enabled = true;
        }
        else
        {
            camScript.enabled = false;
        }

        ManagePause();

        if(paused)
        {
            // Freeze Players / change sprites / etc
            // Trigger police sound
            // enable redLight
            // enable canvas
            redLight.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.6f));
        }

    }
}
