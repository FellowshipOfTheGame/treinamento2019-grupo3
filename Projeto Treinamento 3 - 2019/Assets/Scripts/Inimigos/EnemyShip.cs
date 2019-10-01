using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    private bool targeted = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2 (-5,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BecomeTarget(bool b){
        targeted = b;
    }

    public bool IsTargeted(){
        return targeted;
    }
}
