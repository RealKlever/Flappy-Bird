using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{

    public GameObject pipe; // Gets the pipe GameObject
    public float spawnRate = 1.15f;
    public float timer = 0f;
    public float offset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) // Increases timer
        {
            timer += Time.deltaTime;
        }
        else // Spawns pipe and resets timer
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float upperOffset = transform.position.y + offset;
        float lowerOffset = transform.position.y - offset;

        if (GameManager.gameInPlay == true && GameManager.gameOver == false) // Stops pipes from spawning if game is over
        {
            // Spawns pipe at a random y range
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowerOffset, upperOffset), transform.position.z), transform.rotation);
        }
    }
}
