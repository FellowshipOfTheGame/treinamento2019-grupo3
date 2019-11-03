using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnAxisRotation : MonoBehaviour{
    public float rotationSpeed = 0;
    public float baseRrotationSpeed = 20f;
    public float rotationRandomVariance = 0f;
    public bool possiblyRotateBackwards = true;

    void Start(){
        rotationSpeed = baseRrotationSpeed + Random.Range(-1.0f, 1.0f) * rotationRandomVariance;
        if (possiblyRotateBackwards && Random.value >= 0.5f){
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void FixedUpdate(){
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.fixedDeltaTime), Space.World);
    }
}
