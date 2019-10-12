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

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (!isRandom) {
            MoveTeleguided();    
        } else {
            MoveRandomly();
        }
        
    }

    //Just go to the right direction rotating randomly in the screen
    void MoveRandomly() {

        rb.angularVelocity = Random.Range(-1f, 1f) * rotateSpeed;

        transform.Translate(direction * Time.fixedDeltaTime * speed);
        
    }

    void MoveTeleguided(){

        if (target == null) {

            TryToFindOtherTarget();

        } else {

            //if target is not in front of the missile anymore, then moves randomly
            if ((direction.x > 0 && target.transform.position.x < gameObject.transform.position.x) ||
                (direction.x < 0 && target.transform.position.x > gameObject.transform.position.x)) {
                isRandom = true;
                return;
            }

            targetDirection = target.transform.position - gameObject.transform.position;

            targetDirection.Normalize();

            rotateAmount = Vector3.Cross(direction, targetDirection).z;

            rb.angularVelocity = rotateAmount * rotateSpeed;

            transform.Translate(direction * Time.fixedDeltaTime * speed);
            
        }
    }

    private void TryToFindOtherTarget(){

        target = targetManager.GetTarget();
        if (target != null) {
            isRandom = false;
        } else isRandom = true;

    }

}
