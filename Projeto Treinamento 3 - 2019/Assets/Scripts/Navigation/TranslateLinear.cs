using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateLinear : MonoBehaviour
{
    [SerializeField]
    private Vector3 translationVector = new Vector3(-5,0,0);
    
    void FixedUpdate()
    {
        transform.Translate(translationVector * Time.fixedDeltaTime);
    }
}
