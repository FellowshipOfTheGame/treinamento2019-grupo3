using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnAxisRotation : MonoBehaviour{
    private RandomRotation rr;
    private float rotationSpeed;
    void Start(){
        rr = GetComponent<RandomRotation>();
        rotationSpeed = rr.GetRotationSpeed();
    }
    // Update is called once per frame
    void FixedUpdate(){
        //transform.RotateAround(transform.position, new Vector3(0,0,1), rotateSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.fixedDeltaTime), Space.World);
    }
}
