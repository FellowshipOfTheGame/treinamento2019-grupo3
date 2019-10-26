using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShot : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    private float angle = 45f; //angle variation of each shot
    private Vector3 direction;

    private TurretTargets tt;
    private GameObject target;
    private Vector3 targetDirection;
    private float rotateAmount;

    public float shotTimer;
    public float rotateSpeed;

    void Start(){
        
        tt = GetComponent<TurretTargets>();
        direction = new Vector3(-1, 0, 0);
        InvokeRepeating("Shot", 0f, shotTimer);

    }

    void Shot(){

        target = tt.GetRandomTarget();

        if (target) {
            targetDirection = target.transform.position - gameObject.transform.position;

            targetDirection.Normalize();

            //uses cross product to get the angle between turret projectile direction and target direction
            rotateAmount = Vector3.Cross(direction, targetDirection).z;

            Instantiate(shoot, transform.position, Quaternion.Euler(0, 0, rotateSpeed * rotateAmount));
            
        }

    }
}
