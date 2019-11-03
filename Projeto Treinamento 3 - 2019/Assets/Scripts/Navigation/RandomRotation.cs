using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour{
    private float rotationSpeed;
    public float minRotationSpeed = 5f;
    public float maxRotationSpeed = 20f;
    public float GetRotationSpeed(){
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        return rotationSpeed;
    }
}
