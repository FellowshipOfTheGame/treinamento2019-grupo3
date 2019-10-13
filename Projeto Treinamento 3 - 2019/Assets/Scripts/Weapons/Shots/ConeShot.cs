using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeShot : MonoBehaviour{

    [SerializeField] private GameObject coneBullet;
    private GameObject bulletInstance;
    public Vector3 direction;
    private GameObject bulletSpawn;
    public int nBullets = 5;
    public float angleBetween = 30f;
    public float firstAngle = 60f;
    private float openingAngle;

    private bool canShoot = true;
    private float attackTimer;
    public float shotTimer;

    public float damageAmount = 10;

    // Start is called before the first frame update
    void Start(){
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
            openingAngle = firstAngle;

            //Instantiate 5 cone bullet objects
            for (int i = 0; i < nBullets; i++) {
                bulletInstance = Instantiate(coneBullet, bulletSpawn.transform.position, Quaternion.identity);
                bulletInstance.GetComponent<ConeBullet>().direction = direction;
                bulletInstance.GetComponent<ConeBullet>().angle = openingAngle;
                bulletInstance.layer = gameObject.layer;
                bulletInstance.GetComponent<DamageObjectCollision>().UpdateDamageAmount(damageAmount);
                openingAngle -= angleBetween;
            }

            canShoot = false;

        }

    }

    void SetDirection(Vector3 newDirection){
        direction = newDirection;
    }

    void SetBulletSpawn(GameObject bulletSpawn){
        this.bulletSpawn = bulletSpawn;
    }

    public void IncreaseDamage(float value){
        damageAmount += value;
    }

    public void SetInitialDamage(float value){
        damageAmount = value;
    }

}
