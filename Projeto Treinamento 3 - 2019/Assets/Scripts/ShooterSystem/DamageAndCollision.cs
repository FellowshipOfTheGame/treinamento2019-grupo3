using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAndCollision : MonoBehaviour
{
    public GameObject owner = null;
    public float damage = 0;

    private void SetOwner(GameObject _owner){
        owner =  _owner;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.isTrigger == false){
            if (owner.tag != collider.tag){
                Debug.Log(transform.name + " collided with " + collider.name);
                LifeContainer lifecontainer = collider.GetComponent<LifeContainer>();
                if (lifecontainer == null){
                    // collided with a object withot a life container
                    
                }else{
                    // collided with a object with a life conteiner
                    lifecontainer.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
