using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private int directionMovement = -1; //-1 -> down, 1 -> up

    void Start()
    {
        //check if the tower was created on the bottom or top side ( transform.rotation.z = 0 = 0° = down  
        //                                                           transform.rotation.z = 1 = 180° = up)
        if (transform.rotation.z == 1f)
        {
            directionMovement = 1;
        }
    }
    void Update()
    {
        transform.Translate(directionMovement * speed * Time.deltaTime, 0, 0);
    }
}
