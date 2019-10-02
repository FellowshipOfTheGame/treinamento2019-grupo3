using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSLaserInput : MonoBehaviour{

    private PSWeapons shootPlayerShip;
    private LaserShot laser;
    
    //the player controller(Needs a controller selection manager later):
    //Test -> for testing, with keyboard
    //J1, J2, J3, J4 -> xbox controllers
    public string playerController;

    // Start is called before the first frame update
    void Start(){
        shootPlayerShip = GetComponent<PSWeapons>();
        laser = GetComponent<LaserShot>();
    }

    // Update is called once per frame
    void Update(){
        if (shootPlayerShip.isLaser() && Input.GetButtonDown(playerController + "B")) {
            shootPlayerShip.Shoot();
            GetComponent<PSInput>().enabled = false;
        }

        if (laser.isShooting) {
            if (Input.GetButtonUp(playerController + "B")) {
                //the beam shot is finished
                //if the beam reached its max width, then it will automatically call TurnOff method
                if(!laser.reachedMaxWidht) laser.TurnOff();
                laser.isShooting = false;
                GetComponent<PSInput>().enabled = true;
            } else {
                laser.IncreaseWidth();
            }
        }
    }
    
}


