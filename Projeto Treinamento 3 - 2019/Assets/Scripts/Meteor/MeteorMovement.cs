using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
