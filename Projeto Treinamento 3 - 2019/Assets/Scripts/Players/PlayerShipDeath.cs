using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipDeath : MonoBehaviour{
    public void OnDeath(){
        SoundManager.PlaySound("playerDeath");
    }
}
