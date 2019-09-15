using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ShotType{ SIMPLE, CONE, BEAM, MISSILE };

public class PSShoot : MonoBehaviour {

    private ShotType shotType;
    private bool[] canShoot = new bool[4];

    private SimpleShot simpleShot;
    private ConeShot coneShot;

    private float attackTimer;

    public float simpleShotTimer;
    public float coneShotTimer;
    public float beamTimer;
    public float missileTimer;
     

    // Start is called before the first frame update
    void Start(){

        simpleShot = GetComponent<SimpleShot>();
        simpleShot.direction = Vector3.right;

        coneShot = GetComponent<ConeShot>();
        coneShot.direction = Vector3.right;

        for (int i = 0; i < 4; i++) canShoot[i] = true;

        shotType = ShotType.CONE;

    }

    // Update is called once per frame
    void Update(){

        attackTimer += Time.deltaTime;
        if(shotType == ShotType.SIMPLE) {
            if (attackTimer > simpleShotTimer) {
                canShoot[(int)ShotType.SIMPLE] = true;
            }
        }
        else if(shotType == ShotType.CONE) {
            if (attackTimer > coneShotTimer) {
                canShoot[(int)ShotType.CONE] = true;
            }
        }
        //...

    }

    public void Shoot() {

        if (canShoot[(int)shotType]) {

            attackTimer = 0f;

            if (shotType == ShotType.SIMPLE) {
                simpleShot.Shoot();
                canShoot[(int)ShotType.SIMPLE] = false;
            }
            else if (shotType == ShotType.CONE) {
                coneShot.Shoot();
                canShoot[(int)ShotType.CONE] = false;
            }
            //...
        }

    }

}
