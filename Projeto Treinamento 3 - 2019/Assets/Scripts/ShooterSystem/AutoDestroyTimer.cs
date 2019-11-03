using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyTimer : MonoBehaviour{
    public float timer = 5f;
    // Start is called before the first frame update
    void Start(){
        Invoke("AutoDestroy", timer);        
    }
    private void AutoDestroy(){
        Destroy(gameObject);
    }
}
