using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSBeamInput : MonoBehaviour{

    private PSWeapons shootPlayerShip;
    private BeamShot beam;
    
    //the player controller(Needs a controller selection manager later):
    //Test -> for testing, with keyboard
    //J1, J2, J3, J4 -> xbox controllers
    public string playerController;

    // Start is called before the first frame update
    void Start(){
        shootPlayerShip = GetComponent<PSWeapons>();
        beam = GetComponent<BeamShot>();
    }

    // Update is called once per frame
    void Update(){
        if (shootPlayerShip.isBeam() && Input.GetButtonDown(playerController + "B")) {
            shootPlayerShip.Shoot();
            GetComponent<PSInput>().enabled = false;
        }

        if (beam.isShooting) {            
            if(Input.GetButtonUp(playerController + "B")) {
                //the beam shot is finished
                beam.isShooting = false;
                beam.TurnOff();
                GetComponent<PSInput>().enabled = true;
            } else{
                beam.IncreaseWidth();
            }
        }       
    }
    
}


