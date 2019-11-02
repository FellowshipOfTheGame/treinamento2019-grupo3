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

    public List<string> colliders_tags;

    private RaycastHit2D hitInfo;

    // Start is called before the first frame update
    void Start(){
        lineRenderer = laser.GetComponent<LineRenderer>();
        
    }

    public void Shoot(){

        if (!isShooting) TurnOn();
            else {
                if (!reachedMaxWidht) IncreaseWidth();
                else UpdateLaserPosition();
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
        }

    }

    private void UpdateLaserPosition(){

        hitInfo = Physics2D.Raycast(bulletSpawn.transform.position, direction);

        lineRenderer.SetPosition(0, bulletSpawn.transform.position);

        if (hitInfo && colliders_tags.Contains(hitInfo.collider.tag)) {

            //try to find a Life Container component in the collided object        
            LifeContainer lifeContainer = hitInfo.collider.GetComponent<LifeContainer>();
            if (lifeContainer) {
                CustomizedDamage cd = hitInfo.collider.GetComponent<CustomizedDamage>();
                if (cd) {
                    cd.TakeDamage(damage, ShotType.LASER);
                } else {
                    lifeContainer.TakeDamage(damage);
                }
            }
            
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

    public void IncreaseDamage(float value){
        //it can be changed later, maybe with: damage += value;
        damageIncreasePerFrame += value;
    }

    public void SetInitialDamage(float value){
        //it can be changed later, maybe with: damage = value;
        damageIncreasePerFrame = value;
    }

}
