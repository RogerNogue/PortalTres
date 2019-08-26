using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool cameraScrolling = true;
    public GameObject player1;
    public GameObject player2;

    public GameObject P1win;
    public GameObject P2win;
    public GameObject FateWin;
    public GameObject pauseMenu;

    public float gameFinishedWaitTime;

    public Sprite handsUpSprite1;
    public Sprite handsUpSprite2;
    public Sprite idleSprite1;
    public Sprite idleSprite2;

    private Player1MovementScript player1Script;
    private Player2MovementScript player2Script;
    private Animator player1Anim;
    private Animator player2Anim;
    private SpriteRenderer player1Renderer;
    private SpriteRenderer player2Renderer;
    private Color player1Color;
    private Color player2Color;
    private LifeScript player1Life;
    private LifeScript player2Life;

    private AudioSource audioSource;

    private bool player1Win = false;
    private bool player2Win = false;
    private bool GameFinished = false;
    private float gameFinishTimer = 0.0f;

    private bool paused = false;
    public GameObject countDown;
    public GameObject mainCamera;
    public SpriteRenderer redLight;
    public AudioSource sirensSound;
    private CameraScript camScript;
    private CountDownScript countScript;

    public void SetWin(int winner)
    {
        if(winner == 1)
        {
            player1Win = true;
        }
        else if(winner == 2)
        {
            player2Win = true;
        }   
    }

    public void SetGameFinished()
    {
        GameFinished = true;
    }

    public void ResumeGame()
    {
        paused = false;
        cameraScrolling = true;
        pauseMenu.SetActive(false);
        audioSource.UnPause();
        sirensSound.enabled = false;
        if (player1Life.currentHP > 0)
        {
            player1Script.enabled = true;
            player1Renderer.sprite = idleSprite1;
            player1Anim.enabled = true;
        }
        if (player2Life.currentHP > 0)
        {
            player2Script.enabled = true;
            player2Renderer.sprite = idleSprite2;
            player2Anim.enabled = true;
        }
    }

    void GameStop()
    {
        cameraScrolling = false;
        player1Script.enabled = false;
        player2Script.enabled = false;
        GameFinished = true;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void ManagePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            cameraScrolling = !paused;
            redLight.enabled = paused;
            sirensSound.enabled = paused;

            if (paused)
            {
                pauseMenu.SetActive(true);
                audioSource.Pause();
                if (player1Life.currentHP > 0)
                {
                    player1Script.enabled = false;
                    player1Renderer.sprite = handsUpSprite1;
                    player1Anim.enabled = false;
                }
                if (player2Life.currentHP > 0)
                {
                    player2Script.enabled = false;
                    player2Renderer.sprite = handsUpSprite2;
                    player2Anim.enabled = false;
                }
            }
            else
            {
                pauseMenu.SetActive(false);
                audioSource.UnPause();
                if (player1Life.currentHP > 0)
                {
                    player1Script.enabled = true;
                    player1Renderer.sprite = idleSprite1;
                    player1Anim.enabled = true;
                }
                if (player2Life.currentHP > 0)
                {
                    player2Script.enabled = true;
                    player2Renderer.sprite = idleSprite2;
                    player2Anim.enabled = true;
                }
            }
        }

        if (paused)
        {
            // Freeze Players / change sprites / etc
            // Trigger police sound
            // enable redLight
            // enable canvas
            redLight.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.6f));
        }
    }

    void ManageWin()
    {
        if(player1Life.currentHP <= 0 && player2Life.currentHP <= 0)
        {
            //Fate wins
            FateWin.SetActive(true);
            GameStop();
        }
        else if(player1Win)
        {
            //P1 wins
            P1win.SetActive(true);
            GameStop();
        }
        else if(player2Win)
        {
            //P2 wins
            P2win.SetActive(true);
            GameStop();
        }
           
        if(GameFinished)
        {
            audioSource.Pause();
            gameFinishTimer += Time.deltaTime;

            if(gameFinishTimer > gameFinishedWaitTime)
            {
                gameFinishTimer = 0.0f;
                GameFinished = false;
                SceneManager.LoadScene("MainMenu");
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
        player1Anim = player1.GetComponentInChildren<Animator>();
        player2Anim = player2.GetComponentInChildren<Animator>();
        player1Color = player1Renderer.color;
        player2Color = player2Renderer.color;
        player1Life = player1.GetComponent<LifeScript>();
        player2Life = player2.GetComponent<LifeScript>();
        countScript = countDown.GetComponent<CountDownScript>();
        countScript.startCountDown();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (countScript.start &&  cameraScrolling)//input
        {
            camScript.enabled = true;
        }
        else
        {
            camScript.enabled = false;
        }

        ManagePause();

        ManageWin();

        

    }
}
