using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargets : MonoBehaviour{

    private GameObject[] target;
    private List<GameObject> list;

    /*Returns a reference to a target game object choosed randomly*/
    public GameObject GetRandomTarget(){
        
        target = GameObject.FindGameObjectsWithTag("PlayerShip");

        //try to get(in random sequence) a playership disponible to be a target
        List<int> indexList = new List<int>();
        do {
            int index = Random.Range(0, target.Length);
            if (!indexList.Contains(index)) {
                indexList.Add(index);
                if (target[index].transform.position.x < transform.position.x) {
                    //only get targets that are playerships in front of the turret
                    return target[index];
                }
            }
        } while (indexList.Count < target.Length);
        
        return null;
    }

}
