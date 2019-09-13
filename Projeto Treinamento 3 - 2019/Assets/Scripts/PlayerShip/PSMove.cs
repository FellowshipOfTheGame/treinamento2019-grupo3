using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMove : MonoBehaviour{

    public float verticalSpeed, horizontalFrontSpeed, horizontalBackSpeed, diagonalSpeed;
    private float speed;
    public float minY, maxY, minX, maxX;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Move(Vector3 direction) {
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
        transform.Translate(speed * direction.normalized * Time.deltaTime);

        //make sure that the spaceship doesnt get out of the screen
        Vector3 aux_position = transform.position;
        aux_position.x = Mathf.Clamp(aux_position.x, minX, maxX);
        aux_position.y = Mathf.Clamp(aux_position.y, minY, maxY);
        transform.position = aux_position;
    }

}
