using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("Destruir", 5);
    }

    void Destruir()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true); // gambiarra
        Destroy(gameObject);
    }
}
