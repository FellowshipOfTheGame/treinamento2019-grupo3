using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ShotType{ SIMPLE, CONE, BEAM, MISSILE };

public class PSWeapons : MonoBehaviour {

    private ShotType currentShot;

    private SimpleShot simpleShot;
    private ConeShot coneShot;
  
    // Start is called before the first frame update
    void Start(){

        simpleShot = GetComponent<SimpleShot>();
        simpleShot.direction = Vector3.right;

        coneShot = GetComponent<ConeShot>();
        coneShot.direction = Vector3.right;
        
        currentShot = ShotType.CONE;

    }
    
    public void Shoot() {

        switch((int)currentShot){

            case ((int)ShotType.SIMPLE):
                if(simpleShot.CanShoot()) simpleShot.Shoot();
                break;
            case ((int)ShotType.CONE):
                if (coneShot.CanShoot()) coneShot.Shoot();
                break;
            //...
        }

    }

}
