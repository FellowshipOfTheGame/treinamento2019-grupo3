using System.Collections;
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

    private RaycastHit2D hitInfo;

    // Start is called before the first frame update
    void Start(){
    }

    public void Shoot(){

        if (!isShooting) TurnOn();
        else {
            if (!reachedMaxWidht) IncreaseWidth();
            else TurnOff();
        }
    }
    public void TurnOn(){
        
        lineRenderer.startWidth = initialWidth;
        lineRenderer.endWidth = initialWidth;
        lineRenderer.enabled = true;

        UpdateLaserPosition();
        
        isShooting = true;
        
    }

    private void UpdateLaserPosition(){

        hitInfo = Physics2D.Raycast(bulletSpawn.transform.position, direction);

        lineRenderer.SetPosition(0, bulletSpawn.transform.position);

        if (hitInfo) {
            /*Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy){
                enemy.TakeDamage();
            }*/

            
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

    public void IncreaseWidth(){
        UpdateLaserPosition();
        if (lineRenderer.startWidth < maxWidth) {
            lineRenderer.startWidth += widthIncrement;
            lineRenderer.endWidth += widthIncrement;
        } else {
            reachedMaxWidht = true; 
            //Invoke("TurnOff", 0.5f);
        }        
    }

    void SetDirection(Vector3 newDirection){
        direction = newDirection;
    }


    void SetBulletSpawn(GameObject bulletSpawn){
        this.bulletSpawn = bulletSpawn;
    }

}
