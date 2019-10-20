using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjectCollision : MonoBehaviour{

    public float damage;

    public List<string> colliders_tags;

    private Bullet bullet;

    //AQUI VAI TER INFORMACOES DE DANO

    private void Start(){
        bullet = gameObject.GetComponent<Bullet>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (colliders_tags.Contains(collision.tag)) {
            //verify if the object has life to not destroy it(example: Meteor has life and is also a damage object,
            //when it collides with the player ship, it do not has to autodestroy)
            LifeContainer selfLife = GetComponent<LifeContainer>();
            if (!selfLife) Destroy(gameObject);

            //try to find a Life Container component in the collided object        
            LifeContainer collidedLife = collision.GetComponent<LifeContainer>();
            if (collidedLife) {
                if (bullet) {
                    //if the damage object is a bullet
                    CustomizedDamage cd = collision.GetComponent<CustomizedDamage>();
                    if (cd) {
                        //if the collider has a customized damage script
                        cd.TakeDamage(damage, bullet.bulletType);
                    } else {
                        collidedLife.TakeDamage(damage);
                    }
                } else {
                    collidedLife.TakeDamage(damage);
                }
            }
        }
        
    }

    public void UpdateDamageAmount(float damage){
        this.damage = damage;
    }

}

/*private void OnCollisionEnter2D(Collision2D collision){

        //verify if the object has life to not destroy it(example: Meteor has life and is also a damage object,
        //when it collides with the player ship, it do not has to autodestroy)
        LifeContainer selfLife = GetComponent<LifeContainer>();
        if (!selfLife) Destroy(gameObject);
        
        //try to find a Life Container component in the collided object        
        LifeContainer collidedLife = collision.gameObject.GetComponent<LifeContainer>();
        if (collidedLife) {
            collidedLife.TakeDamage(damage);
        }
    }*/
