using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSkybox : MonoBehaviour
{
    
    public float multiplier;
    void Start()
    {
        multiplier = -0.1f; 
    }
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * multiplier);
        //To set the speed, just multiply Time.time with whatever amount you want.
    }
}
