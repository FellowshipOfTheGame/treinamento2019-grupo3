using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSTargets : MonoBehaviour{

    private GameObject[] target;

    // Start is called before the first frame update
    void Start(){
            
    }

    // Update is called once per frame
    void Update(){
        
    }

    public GameObject GetTarget(){

        target = GameObject.FindGameObjectsWithTag("EnemyShip");

        for(int i=0; i<target.Length; i++) {
            if (!target[i].GetComponent<EnemyShip>().IsTargeted()) {
                target[i].GetComponent<EnemyShip>().BecomeTarget(true);
                return target[i];
            }
        }

        return null;
    }

}
