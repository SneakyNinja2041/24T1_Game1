using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlate : MonoBehaviour
{
    public GameObject door;
    PPlateDoor plateDoor;


    private void Start()
    {
        plateDoor = door.GetComponent<PPlateDoor>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Haunt"))
        {
            plateDoor.moveDown = true;
            plateDoor.moveUp = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Haunt"))
        {
            plateDoor.moveUp = true;
            plateDoor.moveDown = false;
        }
    }

}
