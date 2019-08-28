using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour{

    public float vertical_speed, horizontal_front_speed, horizontal_back_speed, diagonal_speed;
    private float speed;
    public float min_y, max_y, min_x, max_x;

    [SerializeField]
    private GameObject simple_bullet;

    [SerializeField]
    private Transform bullet_spawn;

    public float simple_bullet_timer;
    private float attack_timer;
    private bool can_attack_simple;

    // Start is called before the first frame update
    void Start(){

        can_attack_simple = true;

    }

    // Update is called once per frame
    void Update(){

        MovePlayer();
        Shoot();

    }

    void MovePlayer(){


        //Basic Input(need to change to xbox controllers later)
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        //Define the speed of the movement
        if(direction.x == 0f && direction.y != 0f) {
            speed = vertical_speed;
        }else if(direction.x != 0f && direction.y == 0) {
            if (direction.x > 0) speed = horizontal_front_speed;
            else speed = horizontal_back_speed;
        } else {
            speed = diagonal_speed;
        }

        //move
        transform.Translate(speed * direction.normalized * Time.deltaTime);

        //make sure that the spaceship doesnt get out of the screen
        Vector3 aux_position = transform.position; 
        aux_position.x = Mathf.Clamp(aux_position.x, min_x, max_x);
        aux_position.y = Mathf.Clamp(aux_position.y, min_y, max_y);
        transform.position = aux_position;

    }

    void Shoot() {

        attack_timer += Time.deltaTime;

        if(attack_timer > simple_bullet_timer) {
            can_attack_simple = true;
        }

        //Basic Input(need to change to xbox controllers later)
        if (Input.GetKey(KeyCode.Space)) {
            //if the space button was pressed
            if (can_attack_simple) {
                can_attack_simple = false;
                attack_timer = 0f;
                //Instantiate the simple bullet object
                Instantiate(simple_bullet, bullet_spawn.position, Quaternion.identity);        
            }
        }        

    }

}


