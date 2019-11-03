using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLookAtTarget : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    private float lookSpeed = 1;
    private float angleDiference;
    private Vector3 targetDirection;

    void FixedUpdate()
    {
        if (target != null){
            targetDirection = target.transform.position - gameObject.transform.position;
            angleDiference = Vector3.SignedAngle(transform.right, targetDirection, Vector3.forward);
            transform.Rotate(0, 0, angleDiference * lookSpeed * Time.fixedDeltaTime, Space.Self);
        }
    }
    void SetTarget(GameObject g){
        target = g;
    }
}
