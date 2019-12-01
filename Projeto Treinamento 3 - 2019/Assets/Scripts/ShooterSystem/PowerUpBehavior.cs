using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public GameObject weapon = null;
    
    private void OnTriggerEnter2D(Collider2D collision){
        // TODO: avoid enemes picking up powerUps
        WeaponHandler weaponHandler = collision.GetComponent<WeaponHandler>();
        if (weaponHandler == null){
            // collided with a object withot a weaponHandler

        }else{
            // collided with a object with a weaponHandler
            weaponHandler.ChangeWeapon(weapon);
            Destroy(gameObject);
            SoundManager.PlaySound("powerUp");
        }
    }
}
