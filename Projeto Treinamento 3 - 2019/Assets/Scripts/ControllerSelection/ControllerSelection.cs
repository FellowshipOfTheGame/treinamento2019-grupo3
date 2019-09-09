using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSelection : MonoBehaviour{

    private List<int> assignedControllers = new List<int>(); 

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {

        for (int i = 1; i <= 4; i++) {

            if (assignedControllers.Contains(i))
                continue;

            if (Input.GetButton("J" + i + "A")) {
                AddPlayerController(i);
                break;
            }

        }
    }
    
    //needs to add a UI later
    void AddPlayerController(int controller) {

        assignedControllers.Add(controller);

        //............

    }

}
