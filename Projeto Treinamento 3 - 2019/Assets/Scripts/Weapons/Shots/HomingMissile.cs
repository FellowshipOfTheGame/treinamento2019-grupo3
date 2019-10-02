using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour{

    [SerializeField] private GameObject missileBullet;
    private GameObject instance;
    public Vector3 direction;
    private GameObject bulletSpawn;

    private GameObject target = null;
    private PSTargets targetManager;

    private bool canShoot = true;
    private float attackTimer;
    public float shotTimer; 

    // Start is called before the first frame update
    void Start(){
        targetManager = gameObject.GetComponent<PSTargets>();
        attackTimer = shotTimer;
    }

    void Update(){
        canShoot = ((attackTimer += Time.deltaTime) > shotTimer);
    }

    public bool CanShoot(){
        return canShoot;
    }

    public void Shoot() {

        if (CanShoot()) {

            attackTimer = 0f;

            //Instantiate the simple bullet object
            instance = Instantiate(missileBullet, bulletSpawn.transform.position, Quaternion.identity);
            target = targetManager.GetTarget();

            if (target != null) {

                instance.GetComponent<MissileBullet>().target = target;
                instance.GetComponent<MissileBullet>().isRandom = false;

            } else {

                instance.GetComponent<MissileBullet>().isRandom = true;

            }

            instance.GetComponent<MissileBullet>().direction = direction;
            instance.GetComponent<MissileBullet>().targetManager = targetManager;

            canShoot = false;

        }

    }

    void SetDirection(Vector3 newDirection){
        direction = newDirection;
    }

    void SetBulletSpawn(GameObject bulletSpawn){
        this.bulletSpawn = bulletSpawn;
    }

}
