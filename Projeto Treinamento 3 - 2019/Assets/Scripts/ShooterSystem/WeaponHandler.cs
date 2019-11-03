using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public GameObject attachedWeapon = null;
    public GameObject startingWeapon = null;
    // Start is called before the first frame update
    void Start()
    {
        if (startingWeapon != null && attachedWeapon == null){
            attachedWeapon = instantiateWeapon(startingWeapon);
        }
    }

    // input de teste, não deve ficar aqui
    void Update() {
        
    }

    // method to instantiate a weapon prefab
    GameObject instantiateWeapon(GameObject weapon){
        // instantiate the weapon as a child of this gameObject
        Transform thisTransform = gameObject.transform;
        GameObject w = Instantiate(weapon, thisTransform.position, thisTransform.rotation , thisTransform);
        return w;
    }
    
    // method to be used by the power-up system
    public void ChangeWeapon(GameObject newWeapon){
        attachedWeapon = instantiateWeapon(newWeapon);
    }

    public void Shoot(){
        if (attachedWeapon != null){
            attachedWeapon.SendMessage("Shoot");
        }        
    }
}
