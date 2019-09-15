using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour{

    public float speed;
    public float deactivateTimer;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start(){
        //prepare the object to be deactivated
        Destroy(gameObject, deactivateTimer);
    }

    // Update is called once per frame
    void Update(){
        Move();
    }


    void Move() {

        //Just go to the right direction in the screen
        transform.Translate(direction * Time.deltaTime * speed);

    }

}
