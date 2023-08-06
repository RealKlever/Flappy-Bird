using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameInPlay = false; // Determines if the game is currently playing
    public static bool gameOver = false; // Determines if player hit pipe and if game should continue
    public static bool hitObject = false; // Determines if player has already hit an object
    public static GameManager instance;

    public GameObject startScreen; // FlappyBird Logo and PlayButton
    public GameObject endScreen; // GameOver Logo and ReplayButton
    public GameObject player;
    public Rigidbody2D playerRb;
    public Text scoreText;
    public Text startHighScore; // Highscore on start screen
    public Text endHighScore; // Highscore on end screen


    bool inIdle = false;
    int score;

    // Sets framerate and score
    void Awake()
    {
        Application.targetFrameRate = 144;

        instance = this;

        score = 0;

        startHighScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    // Checks to see if the spacebar was pressed if game is in idle
    void Update()
    {
        if (inIdle == true && Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }

    // Starts the game by putting player in idle
    public void Play()
    {
        inIdle = false;
        playerRb.constraints &= ~RigidbodyConstraints2D.FreezeAll;
        gameInPlay = true;
    }

    // Idles the player and waits for spacebar to be pressed
    public void Idle()
    {
        inIdle = true;
        playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
        player.GetComponent<Animator>().enabled = true;

        // Locks cursor
        Cursor.lockState = CursorLockMode.Locked;

        // Disables the flappy bird logo and play button
        startScreen.SetActive(false);

        // Puts score on the screen
        // Resets score
        score = 0;
        scoreText.text = score.ToString();

        // Changes the players position, unfreezes the y position of player's rigidbody, and sets gameInPlay to true
        player.transform.position = new Vector3(-2.22f, 0, -2);
    }

    // Restarts the game
    public void Replay()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Finds all objects with the tag "Full Pipe" and destroys them
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Full Pipe");
        foreach (GameObject pipe in pipes)
            Destroy(pipe);

        // Resets all bool variables
        gameOver = false;
        hitObject = false;

        // Disables GameOverLogo and ReplayButton
        endScreen.SetActive(false);

        Idle();
    }

    // Puts the game in gameover
    public void GameOver()
    {
        // Sets and outputs highscore
        SetHighScore();
        endHighScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");

        gameOver = true;
        gameInPlay = false;

        // Unlocks cursor
        Cursor.lockState = CursorLockMode.None;

        // Enables GameOverLogo and ReplayButton and stops the player's animation
        endScreen.SetActive(true);
        player.GetComponent<Animator>().enabled = false;
    }

    // Increases and updates score text
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // Sets highscore if it is greater than the previous one stored on the computer
    void SetHighScore()
    {
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
