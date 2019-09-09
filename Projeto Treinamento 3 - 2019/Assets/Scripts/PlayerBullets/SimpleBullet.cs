using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour{

    public float speed;
    public float deactivateTimer;

    // Start is called before the first frame update
    void Start(){
        //prepare the object to be deactivated
        Invoke("DeactivateGameObject", deactivateTimer);
    }

    // Update is called once per frame
    void Update(){
        Move();
    }


    void Move() {

        //Just go to the right direction in the screen
        transform.Translate(Vector3.right * Time.deltaTime * speed);

    }

    void DeactivateGameObject() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.tag == "Enemy") {

            gameObject.SetActive(false);
            //make damage to enemy
        }

    }

}
