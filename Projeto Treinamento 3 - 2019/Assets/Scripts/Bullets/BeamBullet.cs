using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBullet : MonoBehaviour{

    public float deactivateTimer;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start(){
        //prepare the object to be deactivated
        Destroy(gameObject, deactivateTimer);

    }

}
