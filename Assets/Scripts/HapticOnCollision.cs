using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticOnCollision : MonoBehaviour
{

    // Adding the SerializeField attribute to a field will make it appear in the Inspector window
    // where a developer can drag a reference to the controller that you want to send haptics to.
    [SerializeField]
    XRBaseController controller;


    [Range(0, 1)] public float amplitude;

    public float duration=0.1f;

    protected void Start()
    {
        if (controller == null)
            Debug.LogWarning("Reference to the Controller is not set in the Inspector window, this behavior will not be able to send haptics. Drag a reference to the controller that you want to send haptics to.", this);

        
    }

    void OnCollisionEnter(Collision collision)
    {

        SendHaptics();
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}
        //if (collision.relativeVelocity.magnitude > 2)
        //    audioSource.Play();
    }

    void SendHaptics()
    {
        if (controller != null)
            controller.SendHapticImpulse(amplitude, duration);
    }
}