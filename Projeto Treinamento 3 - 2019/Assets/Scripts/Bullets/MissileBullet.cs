using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : MonoBehaviour{

    
    public float speed;
    public Vector3 direction;
    public GameObject target = null;
    public Vector3 targetDirection;
    public bool isRandom;

    public PSTargets targetManager;
    float rotateAmount;

    // Start is called before the first frame update
    void Start(){
        direction = transform.right;
        
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
            //Just go to the right direction in the screen
            transform.Translate(direction * Time.deltaTime * speed);

            transform.Rotate(0f, 0f, Random.Range(-5f, 5f));
        }
    }

    void MoveTeleguided(){

        if (target == null) {

            MoveRandomly();

        } else {
            targetDirection = target.transform.position - gameObject.transform.position;

            targetDirection.Normalize();
            rotateAmount = Vector3.Cross(direction, targetDirection).z;

            transform.Rotate(0f, 0f, rotateAmount/2f);
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    private void OnDestroy(){
        if (target != null) target.GetComponent<EnemyShip>().BecomeTarget(false);
    }

}
