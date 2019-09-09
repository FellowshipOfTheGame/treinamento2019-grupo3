using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour{

    public float verticalSpeed, horizontalFrontSpeed, horizontalBackSpeed, diagonalSpeed;
    private float speed;
    public float minY, maxY, minX, maxX;

    [SerializeField]
    private GameObject simpleBullet;

    [SerializeField]
    private Transform bulletSpawn;

    public float simpleBulletTimer;
    private float attackTimer;
    private bool canAttackSimple;

    //the player controller(Needs a controller selection manager later):
    //Test -> for testing, with keyboard
    //J1, J2, J3, J4 -> xbox controllers
    public string playerController;

    // Start is called before the first frame update
    void Start(){

        canAttackSimple = true;

    }

    // Update is called once per frame
    void Update(){

        MovePlayer();
        attackTimer += Time.deltaTime;
        if (attackTimer > simpleBulletTimer) {
            canAttackSimple = true;
        }
        ShootInput();

    }
    
    //
    void MovePlayer(){

        Vector3 direction = new Vector3(Input.GetAxisRaw(playerController + "Horizontal"), Input.GetAxisRaw(playerController + "Vertical"), 0f);

        //Define the speed of the movement
        if(direction.x == 0f && direction.y != 0f) {
            speed = verticalSpeed;
        }else if(direction.x != 0f && direction.y == 0) {
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

    void ShootInput() {
        
        if (Input.GetButton(playerController + "B")) {
            //if B button was pressed(also space key for testing)
            if (canAttackSimple) {
                ShootSimple();
            }
        }        

    }

    void ShootSimple() {
        canAttackSimple = false;
        attackTimer = 0f;
        //Instantiate the simple bullet object
        Instantiate(simpleBullet, bulletSpawn.position, Quaternion.identity);
    }

}


