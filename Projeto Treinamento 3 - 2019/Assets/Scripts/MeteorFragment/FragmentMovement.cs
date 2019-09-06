using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 2;

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
