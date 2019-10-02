using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSInput : MonoBehaviour{

    private Vector3 inputDirection;
    private PSMove movePlayerShip;
    private PSWeapons shootPlayerShip;

    //the player controller(Needs a controller selection manager later):
    //Test -> for testing, with keyboard
    //J1, J2, J3, J4 -> xbox controllers
    public string playerController;


    // Start is called before the first frame update
    void Start(){
        movePlayerShip = GetComponent<PSMove>();
        shootPlayerShip = GetComponent<PSWeapons>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        MovementInput();
        ShootInput();
    }


    void MovementInput(){
        
        inputDirection = new Vector3(Input.GetAxisRaw(playerController + "Horizontal"),
                                     Input.GetAxisRaw(playerController + "Vertical"),
                                     0f);
        if (inputDirection.x != 0 || inputDirection.y != 0) movePlayerShip.Move(inputDirection);
        
    }

    void ShootInput(){
        if (Input.GetButton(playerController + "B")) {
            //if B button was pressed(also space key for testing)
            shootPlayerShip.Shoot();
        }
    }

}


