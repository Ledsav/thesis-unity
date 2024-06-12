using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    //animation COMMENTED FOR BODY RIG
    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float currentGrip;
    private float currentTrigger;
    public float animationspeed;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";


    //physic

    [SerializeField] private GameObject followObject;
    [SerializeField] private float followspeed = 30f ;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    

    private Transform followTarget;
    private Rigidbody body;
    


    void Start()
    {
        //animation COMMENTED FOR BODY RIG
        animator = GetComponent<Animator>();

        //physics
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        //teleport hands
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
    }

    

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
        PhysicsMove();
    }

    private void PhysicsMove() {

        //update position
        //var positionWithOffset = followTarget.position + positionOffset;
        var positionWithOffset = followTarget.TransformPoint(positionOffset);
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized * (followspeed * distance*Time.deltaTime);

        //rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity =  axis * (angle * Mathf.Deg2Rad * rotationSpeed*Time.deltaTime);
    
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {

        if (currentGrip != gripTarget)
        {
            currentGrip = Mathf.MoveTowards(currentGrip, gripTarget, Time.deltaTime * animationspeed);
            animator.SetFloat(animatorGripParam, currentGrip);
        }
        if (currentTrigger != triggerTarget)
        {
            currentTrigger = Mathf.MoveTowards(currentTrigger, triggerTarget, Time.deltaTime * animationspeed);
            animator.SetFloat(animatorTriggerParam, currentTrigger);
        }


    }
}
