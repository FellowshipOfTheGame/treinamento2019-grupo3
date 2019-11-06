using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    public float speed = 1f;
    public float speedMultiplier = 1f;
    public Vector3 direction = new Vector3(0,0,0);
    private Animator animator;

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        animator.SetFloat("VelocityY", direction.y);
        transform.Translate(speed * speedMultiplier * direction.normalized * Time.fixedDeltaTime);
    }

    public void UpdateInputDirection(Vector3 input){
        direction = input;
    }
}
