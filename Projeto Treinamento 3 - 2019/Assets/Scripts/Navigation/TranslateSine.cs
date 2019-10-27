using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSine : MonoBehaviour
{
    [SerializeField]
    private Vector3 sineAxis = new Vector3(2,3,0); // eixo (direção e amplitude) do movimento senoidal
    [SerializeField]
    private float sinePeriod = 1; // tempo em segundos de cada revolução

    void FixedUpdate()
    {
        float B = Mathf.PI / sinePeriod;
        transform.Translate(Time.fixedDeltaTime * B * sineAxis * Mathf.Sin(B * Time.time));
    }
}
