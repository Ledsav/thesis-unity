using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerTweet : MonoBehaviour
{
    public float timeRemaining = 50f;
    public float TimeSound = 5f;
    private AudioSource Audio;
    public GameObject bird;

    private void Start()
    {
        Audio = bird.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timeRemaining > 0 && TimeSound == 5f)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0 && TimeSound >0)
        {
            Audio.enabled = true;
            TimeSound -= Time.deltaTime;
        }
        else if (timeRemaining <= 0 && TimeSound <= 0)
        {
            Audio.enabled = false;
            timeRemaining = 50f;
            TimeSound = 5f;
        }
    }
}