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

    /*Returns a reference to a target game object*/
    public GameObject GetTarget(){

        target = GameObject.FindGameObjectsWithTag("EnemyShip");

        for(int i=0; i<target.Length; i++) {
            //only get targets that are enemy ships in front of the player ship
            if (target[i].GetComponent<EnemyShip>() != null && (target[i].transform.position.x > transform.position.x)) {
                return target[i];
            }
        }

        return null;
    }

}
