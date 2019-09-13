﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeBullet : MonoBehaviour{

    public float speed;
    public float deactivateTimer;
    public Vector3 direction;
    public float angle;

    // Start is called before the first frame update
    void Start() {
        //prepare the object to be deactivated
        Destroy(gameObject, deactivateTimer);
        Rotate();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Rotate() {
        transform.Rotate(new Vector3(0f, 0f, angle));
    }

    void Move() {

        //Just go to the right direction in the screen
        transform.Translate(direction * Time.deltaTime * speed);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.tag == "Enemy") {

            Destroy(gameObject);
            //make damage to enemy
        }

    }

}
