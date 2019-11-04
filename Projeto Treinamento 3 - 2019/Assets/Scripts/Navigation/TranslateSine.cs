using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSine : MonoBehaviour
{
    [SerializeField]
    private Vector3 sineAxis = new Vector3(2,3,0); // eixo (direção e amplitude) do movimento senoidal
    [SerializeField]
    private float sinePeriod = 1; // tempo em segundos de cada revolução
    public float phaseDegree = 0f;
    private float startTime = 0f;
    private float B;

    void Start() {
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        B = Mathf.PI / sinePeriod;
        Vector3 translation = Time.fixedDeltaTime * B * sineAxis * Mathf.Sin(Mathf.PI / 2 + B * (Time.time - startTime) + Mathf.PI * phaseDegree / 180);
        transform.Translate(translation);
        EnemyShipAnimator anim = GetComponent<EnemyShipAnimator>();
        if (anim) {
            anim.UpdateVelocityY(translation.y);
        }
    }
}
