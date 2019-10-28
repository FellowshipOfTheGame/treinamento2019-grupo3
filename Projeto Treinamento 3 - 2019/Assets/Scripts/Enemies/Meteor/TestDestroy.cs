using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDestroy : MonoBehaviour
{
    void Start()
    {
        //Invoke("Destruir", 0.1f);
    }

    void Destruir()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true); // gambiarra
        Destroy(gameObject);
    }
}
