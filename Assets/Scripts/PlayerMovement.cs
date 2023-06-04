using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 11, 0);
        }
    }
}
