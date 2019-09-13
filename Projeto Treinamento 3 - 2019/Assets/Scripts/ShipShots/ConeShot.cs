using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeShot : MonoBehaviour{

    [SerializeField] private GameObject coneBullet;
    private GameObject instance;
    public Vector3 direction;
    private GameObject bulletSpawn;
    private float openingAngle;

    // Start is called before the first frame update
    void Start(){
        bulletSpawn = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Shoot() {

        openingAngle = 60;

        //Instantiate the cone bullet object
        for (int i=0; i<5; i++) {
            instance = Instantiate(coneBullet, bulletSpawn.transform.position, Quaternion.identity);
            instance.GetComponent<ConeBullet>().direction = direction;
            instance.GetComponent<ConeBullet>().angle = openingAngle;
            openingAngle -= 30f;
        }
    }

}
