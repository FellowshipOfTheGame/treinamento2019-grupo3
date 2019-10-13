﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    private bool canShoot = true;
    public Vector3 direction;
    public GameObject bulletSpawn;
    public float initialDamage;

    // Start is called before the first frame update
    void Start(){
        SendMessage("SetDirection", direction);
        SendMessage("SetBulletSpawn", bulletSpawn);
        SendMessage("SetInitialDamage", initialDamage);
    }

    public void Fire(){
        SendMessage("Shoot");
    }

    public void StopShooting(){
        SendMessage("TurnOff");
        //SendMessageUpwards("SetNormalSpeed");
    }

    public void IncreaseDamageAmount(float value){
        SendMessage("IncreaseDamage", value);
    }

}
