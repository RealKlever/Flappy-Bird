using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLogic : MonoBehaviour
{

    public Rigidbody2D player = new Rigidbody2D(); // Gets the RigidBody of the player
    public float upForce = 6f; // The force that will be applied to the bird
    public float rotationSpeed = 8f; // The speed the bird rotates when it flaps

    public AudioSource flapSound; // Flap audio
    public AudioSource pointSound; // Point audio
    public AudioSource hitSound; // Hit audio
    public AudioSource dieSound; // Fall audio

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.gameOver == false)
        {
            player.velocity = Vector2.up * upForce; // Gives the bird an upward force when the spacebar is hit
            flapSound.Play(); // Play flap sound
        }
    }

    // Bird rotation
    void FixedUpdate()
    {
        player.transform.rotation = Quaternion.Euler(0, 0, player.velocity.y * rotationSpeed);
    }

    // Detects if player went through pipe
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "ScoreHitbox") // Detects if player hit score trigger in between a pipe
        {
            GameManager.instance.IncreaseScore();
            pointSound.Play();
        }
    }

    // Detects if player hit pipe or ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Half Pipe" || collision.gameObject.tag == "Ground") && GameManager.hitObject == false) // Detects if player collided with a top pipe or lower pipe
        {
            // Gets all objects with the tag "Half Pipe" and disbales their box collider
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Half Pipe");
            foreach (GameObject obst in obstacles)
                obst.GetComponent<BoxCollider2D>().enabled = false;

            FindObjectOfType<GameManager>().GameOver();

            hitSound.Play();

            // Plays falling sound after delay when bird hits a pipe
            if (collision.gameObject.tag == "Half Pipe")
            {
                dieSound.PlayDelayed(0.05f);
            }

            GameManager.hitObject = true;
        }
    }
}
