using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWall : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag != "Beam"){
            Destroy(collision.gameObject);
        }
    }    
}
