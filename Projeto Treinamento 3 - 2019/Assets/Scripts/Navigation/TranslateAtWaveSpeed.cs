using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateAtWaveSpeed : MonoBehaviour
{
    private Vector3 translationVector;
    // Start is called before the first frame update
    void Start()
    {
        // TODO: get translationVector from the wave
        translationVector = new Vector3(-5,0,0);
    }

    void FixedUpdate()
    {
        transform.Translate(translationVector * Time.fixedDeltaTime);
    }
}
