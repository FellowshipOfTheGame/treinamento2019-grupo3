using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeShot : MonoBehaviour{

    [SerializeField] private GameObject coneBullet;
    private GameObject bulletInstance;
    public Vector3 direction;
    private GameObject bulletSpawn;
    private float openingAngle;

    private bool canShoot = true;
    private float attackTimer;
    public float shotTimer;

    // Start is called before the first frame update
    void Start(){
        bulletSpawn = transform.GetChild(0).gameObject;
    }

    void Update(){
        canShoot = ((attackTimer += Time.deltaTime) > shotTimer);
    }

    public bool CanShoot(){
        return canShoot;
    }

    public void Shoot() {

        attackTimer = 0f;
        openingAngle = 60;

        //Instantiate 5 cone bullet objects
        for (int i=0; i<5; i++) {
            bulletInstance = Instantiate(coneBullet, bulletSpawn.transform.position, Quaternion.identity);
            bulletInstance.GetComponent<ConeBullet>().direction = direction;
            bulletInstance.GetComponent<ConeBullet>().angle = openingAngle;
            openingAngle -= 30f;
        }

        canShoot = false;
    }

}
