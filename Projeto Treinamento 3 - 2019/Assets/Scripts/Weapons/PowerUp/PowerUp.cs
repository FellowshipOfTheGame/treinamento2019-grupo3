using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour{

    public float damageIncrease;
    public ShotType powerUpType;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    
    /*private void OnCollisionEnter2D(Collision2D collision){
        
        PSWeapons weapons = collision.gameObject.GetComponent<PSWeapons>();
        if (weapons) {
            if (weapons.currentShot == powerUpType) {
                weapons.IncreaseDamage(damageIncrease);
            } else {
                weapons.ChangeWeapon(powerUpType);
            }

            Destroy(gameObject);
        }
         
    }*/

    private void OnTriggerEnter2D(Collider2D collision){

        PSWeapons weapons = collision.GetComponent<PSWeapons>();
        if (weapons) {
            if (weapons.currentShot == powerUpType) {
                weapons.IncreaseDamage(damageIncrease);
            } else {
                weapons.ChangeWeapon(powerUpType);
            }

            Destroy(gameObject);
        }

    }

}
