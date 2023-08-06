using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestruction : MonoBehaviour
{

    public GameObject pipe; // Gets the pipe object

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -12)
        {
            Destroy(pipe); // If the pipe passes x = -12 than the pipe is destroyed
        }
    }
}
