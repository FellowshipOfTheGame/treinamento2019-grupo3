using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    // TODO: create timer to shoot
    // Update is called once per frame
    void Update()
    {
        SendMessage("Shoot");
    }
}
