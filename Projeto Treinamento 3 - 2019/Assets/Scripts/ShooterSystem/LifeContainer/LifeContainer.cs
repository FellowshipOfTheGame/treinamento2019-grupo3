using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to manage the life of the gameObject
public class LifeContainer : MonoBehaviour{

    private float life;
    public float maxLife;

    // Start is called before the first frame update
    void Start(){
        life = maxLife;
    }

    // Update is called once per frame
    void Update(){
        if(life <= 0) {
            Die();
        }
    }

    public void Die(){
        MeteorExplosion me = gameObject.GetComponent<MeteorExplosion>();
        if (me) me.Explosion();
        else Destroy(gameObject);
    }

    public void SetInitialLife(float l){
        maxLife = l;
        life = maxLife;
    }

    public void TakeDamage(float damageAmount){
        Debug.Log(gameObject.name + " took " + damageAmount + " damage");
        life -= damageAmount;
    }

    public void IncreaseLife(float lifeAmount){
        life += lifeAmount;
        if (life > maxLife) life = maxLife;
    }

    public void RestoreLife(){
        life = maxLife;
    }

    public float GetLifePercentage(){
        return life / maxLife;
    }

}
