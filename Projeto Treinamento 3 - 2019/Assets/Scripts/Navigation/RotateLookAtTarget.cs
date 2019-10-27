using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLookAtTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private float lookSpeed = 1;

    void FixedUpdate()
    {
        
        Vector3 targetDirection = target.transform.position - gameObject.transform.position;
        float angleDiference = Vector3.SignedAngle(transform.right, targetDirection, Vector3.forward);
        transform.Rotate(0,0,angleDiference*lookSpeed*Time.fixedDeltaTime,Space.Self);
        /*
        // rotate to aling transform Y axis with target
        Vector3 targetDirection = target.transform.position - gameObject.transform.position;
        Vector3 rotateAxis = Vector3.Cross(transform.right, targetDirection);
        transform.RotateAround(transform.position, rotateAxis, rotateAxis.z * lookSpeed * Time.fixedDeltaTime); 
        */
    }
}
