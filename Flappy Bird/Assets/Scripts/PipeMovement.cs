using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{

    public float moveSpeed = 4.5f; // Speed at which the pipe moves

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false) // Stops pipes from moving if game is over
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z); // Moves the pipe
        }
    }
}
