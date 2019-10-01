using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType{ SIMPLE, CONE, BEAM, MISSILE };

public class PSWeapons : MonoBehaviour {

    public ShotType currentShot = ShotType.SIMPLE;

    private SimpleShot simpleShot;
    private ConeShot coneShot;
    private BeamShot beamShot;
    private HomingMissile missileShot;

    // Start is called before the first frame update
    void Start(){

        simpleShot = GetComponent<SimpleShot>();
        simpleShot.direction = Vector3.right;

        coneShot = GetComponent<ConeShot>();
        coneShot.direction = Vector3.right;

        beamShot = GetComponent<BeamShot>();
        beamShot.direction = Vector3.right;

        missileShot = GetComponent<HomingMissile>();
        missileShot.direction = Vector3.right;

    }

    public void Shoot() {

        switch((int)currentShot){

            case ((int)ShotType.SIMPLE):
                if(simpleShot.CanShoot()) simpleShot.Shoot();
                break;
            case ((int)ShotType.CONE):
                if (coneShot.CanShoot()) coneShot.Shoot();
                break;
            case ((int)ShotType.BEAM):
                beamShot.Shoot();
                break;
            case ((int)ShotType.MISSILE):
                if (missileShot.CanShoot()) missileShot.Shoot();
                break;
        }

    }

    //method to change the type of the shot to simple
    public void ChangeShotToSimple(){
        currentShot = ShotType.SIMPLE;
    }

    //method to change the type of the shot to cone
    public void ChangeShotToCone(){
        currentShot = ShotType.CONE;
    }

    //method to change the type of the shot to beam
    public void ChangeShotToBeam(){
        currentShot = ShotType.BEAM;
    }

    //method to change the type of the shot to missile
    public void ChangeShotToMissile(){
        currentShot = ShotType.MISSILE;
    }

    public bool isBeam(){
        return (currentShot == ShotType.BEAM);
    }

}
