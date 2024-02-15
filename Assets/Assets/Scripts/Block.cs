using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Material material;
    public SpriteRenderer sprite;

    void Start()
    {
        material.color = Color.white;
    }

    public void Colour()
    {
        Debug.Log("Change Block Colour!");

        this.GetComponent<Renderer>().material.color = new Color(1, 0.955f, 0.268f);    

    }
}
