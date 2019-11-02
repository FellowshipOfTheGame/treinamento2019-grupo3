using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLaserShooter : MonoBehaviour
{
    public GameObject shot = null;

    public float timeBetweenShots = 0.3f;
    private float shootingTimer = 0f;

    public Vector3 offset = new Vector3(0,0,0);

    // Update is called once per frame
    void Update()
    {
        shootingTimer -= Time.deltaTime;
    }

    void Shoot(){
        if (shootingTimer <= 0){
            shootingTimer = timeBetweenShots;
            InstantiateShot();
        }
    }

    void InstantiateShot(){
        Transform thisTransform = gameObject.transform;
        GameObject s = Instantiate(shot, thisTransform.position + offset, thisTransform.rotation);
        s.SendMessage("SetOwner", transform.parent.gameObject);
    }
}
