using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform rootObject, followObject ;
    [SerializeField] private Vector3 positionOffest, RotationOffset, headBodyOffest;

    

    // Update is called once per frame
    private void LateUpdate()
    {
        rootObject.position = transform.position + headBodyOffest;
        rootObject.forward = Vector3.ProjectOnPlane(followObject.up, Vector3.up).normalized;

        transform.position = followObject.TransformPoint(positionOffest);
        transform.rotation = followObject.rotation * Quaternion.Euler(RotationOffset);
    }
}
