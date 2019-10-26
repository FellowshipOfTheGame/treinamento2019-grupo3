using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESShot : MonoBehaviour{

    public float shotTimer;
    public GameObject weapon;
    private Weapon w;

    // Start is called before the first frame update
    void Start(){
        w = weapon.GetComponent<Weapon>();
        InvokeRepeating("Shot", 0f, shotTimer);
    }

    void Shot(){
        w.Fire();
    }
}
