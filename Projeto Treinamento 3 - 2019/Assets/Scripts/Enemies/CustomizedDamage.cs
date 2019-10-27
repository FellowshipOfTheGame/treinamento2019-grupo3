using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedDamage : MonoBehaviour{

    private LifeContainer lc;

    public float simpleDamagePercentage;
    public float coneDamagePercentage;
    public float laserDamagePercentage;
    public float missileDamagePercentage;

    // Start is called before the first frame update
    void Start(){
        lc = gameObject.GetComponent<LifeContainer>();
    }

    //Customize the damage according to the type of the collided shot
    public void TakeDamage(float damage, ShotType t){

        switch (t) {
            case ShotType.SIMPLE:
                lc.TakeDamage(damage * simpleDamagePercentage);
                break;
            case ShotType.CONE:
                lc.TakeDamage(damage * coneDamagePercentage);
                break;
            case ShotType.LASER:
                lc.TakeDamage(damage * laserDamagePercentage);
                break;
            case ShotType.MISSILE:
                lc.TakeDamage(damage * missileDamagePercentage);
                break;

        }

    }
    

}
