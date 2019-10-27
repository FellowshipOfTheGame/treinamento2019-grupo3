using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESMovement : MonoBehaviour{

    public float speed;

    private void FixedUpdate(){
        transform.Translate(new Vector2(-speed, 0) * Time.fixedDeltaTime);
    }

}
