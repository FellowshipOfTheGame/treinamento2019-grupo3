using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDeathBehavior : MonoBehaviour{
    public void OnDeath(){
        Destroy(gameObject);
    }
}
