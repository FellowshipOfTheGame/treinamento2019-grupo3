using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShot : MonoBehaviour{
    
    private GameObject instance;
    public Vector3 direction;
    private GameObject bulletSpawn;
    public LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start(){
        //get the bulletSpawn obkect
        bulletSpawn = transform.GetChild(0).gameObject;
    }

    public void Shoot() {

        RaycastHit2D hitInfo = Physics2D.Raycast(bulletSpawn.transform.position, direction);

        lineRenderer.SetPosition(0, bulletSpawn.transform.position);
        lineRenderer.SetPosition(1, bulletSpawn.transform.position + direction * 100);

        if (hitInfo){
            /*Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy){
                enemy.TakeDamage();
            }

            lineRenderer.SetPosition(0, bulletSpawn.transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            */
        }else{
            lineRenderer.SetPosition(0, bulletSpawn.transform.position);
            lineRenderer.SetPosition(1, bulletSpawn.transform.position + direction * 100);
        }

        
    }

}
