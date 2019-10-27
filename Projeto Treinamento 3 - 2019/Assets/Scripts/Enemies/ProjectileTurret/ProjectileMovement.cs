using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    void FixedUpdate()
    {
        transform.Translate(-speed * Time.fixedDeltaTime, 0, 0);
    }
}
