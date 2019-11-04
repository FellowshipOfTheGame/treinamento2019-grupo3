using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAnimator : MonoBehaviour{
    private float velocityY;    
    private Animator animator;
    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void UpdateVelocityY(float vel){
        animator.SetFloat("VelocityY", vel);
    }
}
