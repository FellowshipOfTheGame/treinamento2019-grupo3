using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSelection : MonoBehaviour{

    private List<int> assigned_controllers = new List<int>(); 

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {

        for (int i = 1; i <= 4; i++) {

            if (assigned_controllers.Contains(i))
                continue;

            if (Input.GetButton("J" + i + "A")) {
                AddPlayerController(i);
                break;
            }

        }
    }
    
    //needs to add a UI later
    void AddPlayerController(int controller) {

        assigned_controllers.Add(controller);

        //............

    }

}
