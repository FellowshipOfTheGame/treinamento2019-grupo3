using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour{

    public float speed;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start(){
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
