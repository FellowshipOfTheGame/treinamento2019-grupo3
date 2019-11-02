using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider){
        Destroy(collider.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(collision.transform.gameObject);
    }
}
