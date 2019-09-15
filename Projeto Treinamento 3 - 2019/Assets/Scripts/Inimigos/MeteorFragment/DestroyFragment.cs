using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFragment : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField] private float time = 4f;
    void Start()
    { 
        Destroy(gameObject, time);
    }
}
