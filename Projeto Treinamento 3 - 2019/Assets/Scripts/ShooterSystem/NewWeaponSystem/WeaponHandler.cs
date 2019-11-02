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
        if (startingWeapon != null){
            attachedWeapon = instantiateWeapon(startingWeapon);
        }
    }

    // method to instantiate a weapon prefab
    GameObject instantiateWeapon(GameObject weapon){
        GameObject w = Instantiate(weapon, gameObject.transform, gameObject);
        return w;
    }
    
    // method to be used by the power-up system
    public void ChangeWeapon(GameObject newWeapon){
        attachedWeapon = instantiateWeapon(newWeapon);
    }

    void Shoot(){
        attachedWeapon.SendMessage("Shoot");
    }
}
