using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipInput : MonoBehaviour
{
    public WeaponHandler weaponHandler = null;
    public PlayerShipMovement shipMovement = null;
    
    //Test -> for testing, with keyboard
    //J1, J2, J3, J4 -> xbox controllers
    public string playerController = "J1";

    // Start is called before the first frame update
    void Start()
    {
        weaponHandler = GetComponent<WeaponHandler>();
        shipMovement = GetComponent<PlayerShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        ShootingInput();
    }

    void MovementInput(){
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(playerController + "Horizontal"),
                                             Input.GetAxisRaw(playerController + "Vertical"),
                                             0f);
        shipMovement.UpdateInputDirection(inputDirection);
    }
    void ShootingInput(){
        if (Input.GetButton(playerController + "A")){
            weaponHandler.Shoot();
        }
    }
}
