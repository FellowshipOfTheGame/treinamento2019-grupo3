using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{

    //list of connected joysticks
    private List<int> connectedControllers = new List<int>();
    
    private bool[] shipChoosed = new bool[3];
    private bool constructorChoosed;

    private string[] shipController = new string[3];
    private string constructorController;

    // Start is called before the first frame update
    void Start(){
        
        //initialization of variables
        for (int i=0; i<3; i++)
            shipChoosed[i] = false;
        constructorChoosed = false;

    }

    // Update is called once per frame
    void Update() {

        //remember to add a button to reset the choosing...

        for (int i = 1; i <= 4; i++) {

            if (connectedControllers.Contains(i)){

                if (Input.GetButton("J" + i + "Start")
                    && (shipChoosed[0] || shipChoosed[1] || shipChoosed[2])
                    && constructorChoosed){
                    //start the game
                    //Instantiate the players passing the joysticks designed for each one of them to their respective PlayerInput scripts
                    //and oassing the position to the spawn script...
                }

                continue;
            }
            
            if(Input.GetButton("J" + i + "A")) {
                AddPlayerController(i);
                break;
            }

        }
    }

    //needs to add a UI later
    void AddPlayerController(int controller) {

        connectedControllers.Add(controller);

        //............ choose one ship or the constructor verifying if its not chosen yet
        //set the correspondent controller string for the new player

    }

}



// For detecting connected/disconnected joysticks:

/*
    ** run it every 2 seconds **:
   
   //Get Joystick Names
   string[] temp = Input.GetJoystickNames();

   //Check whether array contains anything

   if (temp.Length > 0) {
       //Iterate over every element
       for (int i = 0; i < temp.Length; ++i) {
           //Check if the string is empty or not
           if (!string.IsNullOrEmpty(temp[i])) {
               //Not empty, controller temp[i] is connected
               Debug.Log("Controller " + i + " is connected using: " + temp[i]);
           } else {
               //If it is empty, controller i is disconnected
               //where i indicates the controller number
               Debug.Log("Controller: " + i + " is disconnected.");

           }
       }
   }*/
