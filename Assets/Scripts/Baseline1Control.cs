using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Baseline1Control : MonoBehaviour
{

    public float time = 0;
    public GameObject cam;
    public bool b2 = false;

 

    private void Start()
    {

    }


    void Update()
    {
        if (time >= 300)
            time += Time.deltaTime;
        {

        }
        
    }
}