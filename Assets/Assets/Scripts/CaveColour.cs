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
    public Material coffin;
    public Material vine;
    public Material rocks;

    public SpriteRenderer[] wallsSprites;


    // Start is called before the first frame update
    void Start()
    {
        keyDoor.color = Color.white;
        pPlate.color = Color.white;
        pPlateDoor.color = Color.white;
        rockBG.color = Color.white;
        coffin.color = Color.white;
        vine.color = Color.white;
        rocks.color = Color.white;


        wallsSprites[0].material.color = Color.white;
        wallsSprites[1].material.color = Color.white;
        wallsSprites[2].material.color = Color.white;
        wallsSprites[3].material.color = Color.white;
        wallsSprites[4].material.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("Return the Sections Colour!");
            wallsSprites[0].material.color = new Color(0.674f, 0.638f, 0.896f);
            wallsSprites[1].material.color = new Color(0.674f, 0.638f, 0.896f);
            wallsSprites[2].material.color = new Color(0.674f, 0.638f, 0.896f);
            wallsSprites[3].material.color = new Color(0.674f, 0.638f, 0.896f);
            wallsSprites[4].material.color = new Color(0.674f, 0.638f, 0.896f);

            keyDoor.color = new Color(1f, 0.748f, 0.833f);
            pPlate.color = new Color(0.905f, 0.260f, 0.287f);
            pPlateDoor.color = new Color(0.509f, 0.126f, 0.066f);
            rockBG.color = new Color(0.311f, 0.560f, 0.584f);
            coffin.color = new Color(0.915f, 0.707f, 0.332f);
            rocks.color = new Color(0.943f, 0.738f, 0.663f);
            vine.color = new Color(0.367f, 0.820f, 0.274f);
        }


    }






}
