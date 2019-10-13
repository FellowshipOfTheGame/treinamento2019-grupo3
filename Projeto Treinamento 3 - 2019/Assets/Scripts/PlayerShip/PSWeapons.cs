using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType{ SIMPLE, CONE, LASER, MISSILE };

public class PSWeapons : MonoBehaviour {

    public ShotType currentShot = ShotType.SIMPLE;

    public GameObject simpleWeapon;
    public GameObject coneWeapon;
    public GameObject laserWeapon;
    public GameObject missileWeapon;

    private GameObject currentWeapon = null;

    public float initialDamageSimple = 10;
    public float initialDamageCone = 10;
    public float initialDamageLaser = 0.1f;
    public float initialDamageMissile = 10;

    private float initialDamage = 0f;

    // Start is called before the first frame update
    void Start(){
        
        ChangeWeapon(currentShot);

    }

    public void Shoot() {

        currentWeapon.GetComponent<Weapon>().Fire();

    }

    public void ChangeWeapon(ShotType type) {

        if (currentWeapon != null) Destroy(currentWeapon);

        switch ((int)type) {

            case 0:
                ChangeToSimpleWeapon();
                break;
            case 1:
                ChangeToConeWeapon();
                break;
            case 2:
                ChangeToLaserWeapon();
                break;
            case 3:
                ChangeToMissileWeapon();
                break;
        }

        //instantiate the weapon as a child of the shooter with his correspondent shot direction and bullet spawn position
        currentWeapon.transform.parent = gameObject.transform;
        currentWeapon.GetComponent<Weapon>().direction = transform.right;
        currentWeapon.GetComponent<Weapon>().initialDamage = initialDamage;
        currentWeapon.GetComponent<Weapon>().bulletSpawn = transform.GetChild(0).gameObject;
        currentWeapon.layer = LayerMask.NameToLayer("PlayerShip");

    }

    //method to change the type of the shot to simple
    public void ChangeToSimpleWeapon(){
        currentShot = ShotType.SIMPLE;
        currentWeapon = Instantiate(simpleWeapon, transform.position, Quaternion.identity);
        initialDamage = initialDamageSimple;
    }

    //method to change the type of the shot to cone
    public void ChangeToConeWeapon(){
        currentShot = ShotType.CONE;
        currentWeapon = Instantiate(laserWeapon, transform.position, Quaternion.identity);
        initialDamage = initialDamageLaser;
    }

    //method to change the type of the shot to beam
    public void ChangeToLaserWeapon(){
        currentShot = ShotType.LASER;
        currentWeapon = Instantiate(laserWeapon, transform.position, Quaternion.identity);
        initialDamage = initialDamageLaser;
    }

    //method to change the type of the shot to missile
    public void ChangeToMissileWeapon(){
        currentShot = ShotType.MISSILE;
        currentWeapon = Instantiate(missileWeapon, transform.position, Quaternion.identity);
        initialDamage = initialDamageMissile;
    }

    public bool IsLaser(){
        return (currentShot == ShotType.LASER);
    }


    public void StopShooting(){
        currentWeapon.GetComponent<Weapon>().StopShooting();
    }

    public void IncreaseDamage(float value){
        currentWeapon.GetComponent<Weapon>().IncreaseDamageAmount(value);
    }

}
