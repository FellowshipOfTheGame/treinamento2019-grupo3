using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour{

    public float damageIncrease;
    public ShotType powerUpType;
    public Vector3 direction = new Vector3(-1, 0, 0);
    public float speed = 5;

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

    private void FixedUpdate(){
        Move();
    }

    public void Move(){
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

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
