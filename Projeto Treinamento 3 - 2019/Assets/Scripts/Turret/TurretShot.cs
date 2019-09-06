using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShot : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    private float angle = 45f; //angle variation of each shot
    private int directionShooting = -1; //-1 -> down, 1 up
    void Start()
    {
        InvokeRepeating("Shot", 0f, 2.5f);

        //check if the tower was created on the bottom or top side ( transform.rotation.z = 0 = 0° = down  
        //                                                           transform.rotation.z = 1 = 180° = up)
        if (transform.rotation.z == 1f)
        {
            directionShooting = 1;
        }

    }

    void Shot()
    {
        //fire 5 shots with varying angle
        for (int i = 0; i < 5; i++)
            Instantiate(shoot, transform.position, Quaternion.Euler(0, 0, directionShooting * angle * i));
    }
}
