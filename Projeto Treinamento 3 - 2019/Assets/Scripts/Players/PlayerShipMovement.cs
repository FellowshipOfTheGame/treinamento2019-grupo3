using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    public float speed = 1f;
    public float speedMultiplier = 1f;
    public Vector3 direction = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        transform.Translate(speed * speedMultiplier * direction.normalized * Time.fixedDeltaTime);
    }

    public void UpdateInputDirection(Vector3 input){
        direction = input;
    }
}
