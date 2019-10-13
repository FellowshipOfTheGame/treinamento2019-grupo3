using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to manage the life of the gameObject
public class LifeContainer : MonoBehaviour{

    private float life;
    public float initialLife = 1;

    // Start is called before the first frame update
    void Start(){
        life = initialLife;
    }

    // Update is called once per frame
    void Update(){
        if(life == 0) {
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
    }

    public void SetInitialLife(float l){
        initialLife = l;
        life = initialLife;
    }

    public void takeDamage(float damageAmount){
        life -= damageAmount;
    }

    public void IncreaseLife(float lifeAmount){
        life += lifeAmount;
        if (life > initialLife) life = initialLife;
    }

    public void RestoreLife(){
        life = initialLife;
    }

    public float getLifePercentage(){
        return life / initialLife;
    }

}
