using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : MonoBehaviour{

    
    public float speed = 10;
    public Vector3 direction;
    public GameObject target = null;
    public Vector3 targetDirection;
    public bool isRandom;

    public PSTargets targetManager;
    private float rotateAmount;
    public float rotateSpeed;

    /*private Rigidbody2D rb;
    public float rotateSpeed = 20;*/

    // Start is called before the first frame update
    void Start(){
        direction = transform.right;
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (isRandom) MoveRandomly();
        else MoveTeleguided();
    }


    void MoveRandomly() {

        target = targetManager.GetTarget();

        if (target != null) MoveTeleguided();
        else {
            //Just go to the right direction rotating randomly in the screen
            transform.Translate(direction * Time.fixedDeltaTime * speed);
            transform.Rotate(0f, 0f, Random.Range(-1f, 1f) * rotateSpeed);
        }
    }

    void MoveTeleguided(){

        if (target == null) {

            MoveRandomly();

        } else {
            targetDirection = target.transform.position - gameObject.transform.position;

            targetDirection.Normalize();
            rotateAmount = Vector3.Cross(direction, targetDirection).z;

            /*rb.angularVelocity = rotateAmount * rotateSpeed;
            rb.velocity = speed * direction;*/

            transform.Rotate(0f, 0f, rotateAmount * rotateSpeed);
            //transform.Translate(targetDirection * Time.fixedDeltaTime * speed);
            transform.Translate(direction * Time.fixedDeltaTime * speed);

        }
    }

    private void OnDestroy(){
        if (target != null) target.GetComponent<EnemyShip>().BecomeTarget(false);
    }

}
