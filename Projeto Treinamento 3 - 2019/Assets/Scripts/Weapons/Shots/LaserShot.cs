using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

    private GameObject instance;
    public Vector3 direction;
    private GameObject bulletSpawn;
    public GameObject laser;
    private LineRenderer lineRenderer;
    [HideInInspector] public bool isShooting = false;
    [HideInInspector] public bool reachedMaxWidht = false;

    public float initialWidth;
    public float widthIncrement;
    public float maxWidth;

    public float initialDamage = 0.1f;
    public float damageIncreasePerFrame = 0.1f;
    private float damage;

    private RaycastHit2D hitInfo;

    // Start is called before the first frame update
    void Start(){
        lineRenderer = laser.GetComponent<LineRenderer>();
        laser.layer = gameObject.layer;
        //Debug.Log(gameObject.layer);
        if(LayerMask.LayerToName(laser.layer) == "PlayerShip") {
            laser.tag = "PSLaser";
        }
    }

    public void Shoot(){

        if (!isShooting) TurnOn();
        else {
            if (!reachedMaxWidht) IncreaseWidth();
            else TurnOff();
        }
    }
    public void TurnOn(){

        damage = initialDamage;
        lineRenderer.startWidth = initialWidth;
        lineRenderer.endWidth = initialWidth;
        lineRenderer.enabled = true;

        UpdateLaserPosition();
        
        isShooting = true;
        
    }

    public void IncreaseWidth(){

        damage += damageIncreasePerFrame;
        UpdateLaserPosition();
        if (lineRenderer.startWidth < maxWidth) {
            lineRenderer.startWidth += widthIncrement;
            lineRenderer.endWidth += widthIncrement;
        } else {
            reachedMaxWidht = true;
            //Invoke("TurnOff", 0.5f);
        }

    }

    private void UpdateLaserPosition(){

        hitInfo = Physics2D.Raycast(bulletSpawn.transform.position, direction);

        lineRenderer.SetPosition(0, bulletSpawn.transform.position);

        if (hitInfo && hitInfo.collider.tag != "PlayerShip" && hitInfo.collider.tag != "PSLaser") {

            //try to find a HP component in the collided object
            /*
            collidedHP = hitInfo.collider.GetComponent<HP>();
            if (collidedHP) {
                collidedHP.TakeDamage(damage);
            }*/

            Debug.Log(hitInfo.collider.name);
            
            lineRenderer.SetPosition(1, hitInfo.point);

        } else {
            lineRenderer.SetPosition(1, bulletSpawn.transform.position + (direction * 100));
        }

    }

    public void TurnOff(){
        lineRenderer.enabled = false;
        reachedMaxWidht = false;
        isShooting = false;
    }

    void SetDirection(Vector3 newDirection){
        direction = newDirection;
    }


    void SetBulletSpawn(GameObject bulletSpawn){
        this.bulletSpawn = bulletSpawn;
    }

}
