using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjectCollision : MonoBehaviour{

    private float damage;

    //AQUI VAI TER INFORMACOES DE DANO

    private void OnTriggerEnter2D(Collider2D collision){
        
        Destroy(gameObject);
        Debug.Log(collision.name);
        //try to find a HP component in the collided object
        /*
        lifeManager = collision.GetComponent<LifeManager>();
        if (lifeManager) {
            lifeManager.TakeDamage(damage);
        }*/
    }

    public void UpdateDamageAmount(float damage){
        this.damage = damage;
    }

}
