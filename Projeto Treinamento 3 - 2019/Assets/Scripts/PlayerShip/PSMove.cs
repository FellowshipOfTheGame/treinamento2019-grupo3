using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMove : MonoBehaviour{

    public float verticalSpeed, horizontalFrontSpeed, horizontalBackSpeed, diagonalSpeed;
    private float speed;
    public float minY, maxY, minX, maxX;
    private float speedPercentage = 1;
    private Vector3 direction;
    public float reducedSpeedPercentage = 0.5f;

    private void Start(){
        direction.x = 0;
        direction.y = 0;
        direction.z = 0;
    }

    void FixedUpdate(){
        Move();
    }

    public void Move() {

        //Define the speed of the movement
        if (direction.x == 0f && direction.y != 0f) {
            speed = verticalSpeed;
        } else if (direction.x != 0f && direction.y == 0) {
            if (direction.x > 0) speed = horizontalFrontSpeed;
            else speed = horizontalBackSpeed;
        } else {
            speed = diagonalSpeed;
        }

        //move
        transform.Translate(speed * speedPercentage * direction.normalized * Time.fixedDeltaTime);

        //make sure that the spaceship doesnt get out of the screen
        Vector3 aux_position = transform.position;
        aux_position.x = Mathf.Clamp(aux_position.x, minX, maxX);
        aux_position.y = Mathf.Clamp(aux_position.y, minY, maxY);
        transform.position = aux_position;
    }
    
    public void UpdateInputDirection(Vector3 direction){
        this.direction = direction;
    }
    
    public void SetSlowSpeed(){
        speedPercentage = reducedSpeedPercentage;
    }

    public void SetNormalSpeed(){
        speedPercentage = 1;
    }

}
