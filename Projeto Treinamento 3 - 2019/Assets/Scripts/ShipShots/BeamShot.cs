using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShot : MonoBehaviour{

    [SerializeField] private GameObject beamBullet;
    private GameObject instance;
    public Vector3 direction;
    private GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start(){
        //get the bulletSpawn obkect
        bulletSpawn = transform.GetChild(0).gameObject;
    }

    public void Shoot() {
        //Instantiate the simple bullet object
        instance = Instantiate(beamBullet, bulletSpawn.transform.position, Quaternion.identity);
        //set the direction of the bullet
        instance.GetComponent<BeamBullet>().direction = direction;
    }

}
