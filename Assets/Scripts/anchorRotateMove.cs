using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorRotateMove : MonoBehaviour
{


    //physic

    [SerializeField] private GameObject followObject;
    [SerializeField] private float followspeed = 30f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;


    private Transform followTarget;
    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        //physics
        followTarget = followObject.transform;
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        //teleport hands
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
    }
    private void PhysicsMove()
        {

            //update position
            var positionWithOffset = followTarget.position + positionOffset;
            var distance = Vector3.Distance(positionWithOffset, transform.position);
            body.velocity = (positionWithOffset - transform.position).normalized * (followspeed * distance * Time.deltaTime);

            //rotation
            var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
            var q = rotationWithOffset * Quaternion.Inverse(transform.rotation);
            q.ToAngleAxis(out float angle, out Vector3 axis);
            body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotationSpeed * Time.deltaTime);

        }
    

    void Update()
    {
        PhysicsMove();
    }
}
