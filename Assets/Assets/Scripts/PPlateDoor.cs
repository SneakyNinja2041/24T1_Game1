using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlateDoor : MonoBehaviour
{

    private float moveSpeed = 6f;

    public bool moveUp;
    public bool moveDown;


    private void Update()
    {
        if(moveUp == true)
        {
            transform.position = transform.position + new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }

        if(moveDown == true)
        {
            transform.position = transform.position + new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }


 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Top"))
        {
            moveUp = false;
        }

        if (other.CompareTag("Bottom"))
        {
            moveDown = false;
        }


    }

}
