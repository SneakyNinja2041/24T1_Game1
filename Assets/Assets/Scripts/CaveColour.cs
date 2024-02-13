using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveColour : MonoBehaviour
{
    public Material walls;
    public Material keyDoor;
    public Material pPlate;
    public Material pPlateDoor;
    public Material rockBG;

    public SpriteRenderer[] wallsSprites;


    // Start is called before the first frame update
    void Start()
    {
        keyDoor.color = new Color(0.534f, 0.534f, 0.534f);
        pPlate.color = new Color(0.232f, 0.232f, 0.232f);
        pPlateDoor.color = new Color(0.616f, 0.616f, 0.616f);
        rockBG.color = new Color(0.820f, 0.820f, 0.820f);

        wallsSprites[0].material.color = new Color(0.377f, 0.377f, 0.377f);
        wallsSprites[1].material.color = new Color(0.377f, 0.377f, 0.377f);
        wallsSprites[2].material.color = new Color(0.377f, 0.377f, 0.377f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("Return the Sections Colour!");
            wallsSprites[0].material.color = new Color(0.295f, 0.254f, 0.183f);
            wallsSprites[1].material.color = new Color(0.295f, 0.254f, 0.183f);
            wallsSprites[2].material.color = new Color(0.295f, 0.254f, 0.183f);

            keyDoor.color = new Color(0.657f, 0.248f, 0.248f);
            pPlate.color = new Color(0.783f, 0.055f, 0.055f);
            pPlateDoor.color = new Color(0.773f, 0.265f, 0.307f);
            rockBG.color = new Color(0.792f, 0.703f, 0.525f);
        }


    }






}
