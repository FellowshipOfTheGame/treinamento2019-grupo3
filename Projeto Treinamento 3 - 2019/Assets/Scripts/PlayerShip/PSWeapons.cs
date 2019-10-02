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

    private GameObject currentWeapon;

    // Start is called before the first frame update
    void Start(){
        
        InstantiateWeapon(currentShot);

    }

    public void Shoot() {

        currentWeapon.GetComponent<Weapon>().Fire();

    }

    //method to change the type of the shot to simple
    public void ChangeShotToSimple(){
        currentShot = ShotType.SIMPLE;
        Destroy(currentWeapon);
        InstantiateWeapon(ShotType.SIMPLE);
    }

    //method to change the type of the shot to cone
    public void ChangeShotToCone(){
        currentShot = ShotType.CONE;
        Destroy(currentWeapon);
        InstantiateWeapon(ShotType.CONE);
    }

    //method to change the type of the shot to beam
    public void ChangeShotToLaser(){
        currentShot = ShotType.LASER;
        Destroy(currentWeapon);
        InstantiateWeapon(ShotType.LASER);
    }

    //method to change the type of the shot to missile
    public void ChangeShotToMissile(){
        currentShot = ShotType.MISSILE;
        Destroy(currentWeapon);
        InstantiateWeapon(ShotType.MISSILE);
    }

    public bool IsLaser(){
        return (currentShot == ShotType.LASER);
    }


    private void InstantiateWeapon(ShotType type){

        switch ((int)type) {

            case 0:
                currentWeapon = Instantiate(simpleWeapon, transform.position, Quaternion.identity);
                break;
            case 1:
                currentWeapon = Instantiate(coneWeapon, transform.position, Quaternion.identity);
                break;
            case 2:
                currentWeapon = Instantiate(laserWeapon, transform.position, Quaternion.identity);
                break;
            case 3:
                currentWeapon = Instantiate(missileWeapon, transform.position, Quaternion.identity);
                break;
        }

        //instantiate the weapon as a child of the shooter with his correspondent shot direction and bullet spawn position
        currentWeapon.transform.parent = gameObject.transform;
        currentWeapon.GetComponent<Weapon>().direction = transform.right;
        currentWeapon.GetComponent<Weapon>().bulletSpawn = transform.GetChild(0).gameObject;

    }

    public void StopShooting(){
        currentWeapon.GetComponent<Weapon>().StopShooting();
    }

}
