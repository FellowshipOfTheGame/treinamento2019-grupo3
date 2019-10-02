using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSimpleShot : MonoBehaviour{

    [SerializeField] private GameObject simpleBullet;
    private GameObject instance;
    public Vector3 direction;
    private GameObject bulletSpawn;

    private bool canShoot = true;
    private float attackTimer;
    public float shotTimer; 

    // Start is called before the first frame update
    void Start(){
        //get the bulletSpawn obkect
        bulletSpawn = transform.GetChild(0).gameObject;
        attackTimer = shotTimer;
    }

    void Update(){
        canShoot = ((attackTimer += Time.deltaTime) > shotTimer);
    }

    public bool CanShoot(){
        return canShoot;
    }

    public void Shoot() {

        attackTimer = 0f;

        //Instantiate the simple bullet object
        instance = Instantiate(simpleBullet, bulletSpawn.transform.position, Quaternion.identity);
        //set the direction of the bullet
        instance.GetComponent<SimpleBullet>().direction = direction;

        canShoot = false;
        
    }

}
