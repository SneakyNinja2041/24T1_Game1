using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Material material;

    private void Start()
    {
        material.color = Color.white;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Change Key Colour!");
            material.color = Color.red;
        }
    }



}
