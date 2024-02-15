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


    public void Colour()
    {        
            Debug.Log("Change Key Colour!");
            material.color = new Color(0.849f, 0.715f, 0.205f);                              
    }



}
