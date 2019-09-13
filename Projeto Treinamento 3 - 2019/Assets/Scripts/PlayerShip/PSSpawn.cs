using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSSpawn : MonoBehaviour{

    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start(){
        gameObject.transform.position = spawnPosition;
        
        //...

        this.enabled = false;
    }

    // Update is called once per frame
    void Update(){
        
    }
}
