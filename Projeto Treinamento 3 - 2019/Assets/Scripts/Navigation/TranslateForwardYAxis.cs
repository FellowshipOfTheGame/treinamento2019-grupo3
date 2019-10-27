using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateForwardYAxis : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    void FixedUpdate()
    {
        transform.Translate(speed * transform.right * Time.fixedDeltaTime);
    }
}
