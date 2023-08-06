using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    MeshRenderer ground;

    public float groundSpeed = 0.3765f;

    // Start is called before the first frame update
    void Awake()
    {
        ground = GetComponent<MeshRenderer>(); // Gets mesh renderer of current object
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false) // Stops the floor if game is overs
        {
            // Gets the material from the mesh renderer and offsets it (moves it) by the groundSpeed
            ground.material.mainTextureOffset += new Vector2(groundSpeed * Time.deltaTime, 0);
        }
    }
}
