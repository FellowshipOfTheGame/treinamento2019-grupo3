﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

    private GameObject instance;
    public Vector3 direction;
    private GameObject bulletSpawn;
    public LineRenderer lineRenderer;
    [HideInInspector] public bool isShooting = false;
    [HideInInspector] public bool reachedMaxWidht = false;

    public float initialWidth;
    public float widthIncrement;
    public float maxWidth;

    // Start is called before the first frame update
    void Start(){
    }

    public void Shoot(){
        //if(CanShoot()) TurnOn();
        TurnOn();
    }
    
    public void TurnOn(){
        RaycastHit2D hitInfo = Physics2D.Raycast(bulletSpawn.transform.position, direction);
        
        lineRenderer.startWidth = initialWidth;
        lineRenderer.endWidth = initialWidth;
        lineRenderer.enabled = true;

        if (hitInfo){
            /*Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy){
                enemy.TakeDamage();
            }*/

            lineRenderer.SetPosition(0, bulletSpawn.transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            
        } else{
            lineRenderer.SetPosition(0, bulletSpawn.transform.position);
            lineRenderer.SetPosition(1, bulletSpawn.transform.position + (direction * 100));
        }

        isShooting = true;
        
    }

    public void TurnOff(){
        lineRenderer.enabled = false;
        reachedMaxWidht = false;
    }

    public void IncreaseWidth(){
        if(lineRenderer.startWidth < maxWidth) {
            lineRenderer.startWidth += widthIncrement;
            lineRenderer.endWidth += widthIncrement;
        } else {
            reachedMaxWidht = true;
            Invoke("TurnOff", 0.5f);
        }        
    }

    void SetDirection(Vector3 newDirection){
        direction = newDirection;
    }


    void SetBulletSpawn(GameObject bulletSpawn){
        this.bulletSpawn = bulletSpawn;
    }

}
