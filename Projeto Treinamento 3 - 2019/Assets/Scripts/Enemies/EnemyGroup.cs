using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour{

    private int n;

    void Start(){
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        for(int i=0; i<childTransforms.Length; i++) {
            childTransforms[i].parent = transform.parent;
        }
        //autodestroy
        Destroy(gameObject);
    }
}
