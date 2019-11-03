using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomPlayerAsTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LockAim();
    }

    void LockAim(){
        PlayerShipInput[] players = Object.FindObjectsOfType<PlayerShipInput>();
        if (players != null){
            int numberOfPlayers = players.Length;
            int r = Random.Range(0,numberOfPlayers);
            SendMessage("SetTarget",players[r].gameObject);
        }   
    }
}
