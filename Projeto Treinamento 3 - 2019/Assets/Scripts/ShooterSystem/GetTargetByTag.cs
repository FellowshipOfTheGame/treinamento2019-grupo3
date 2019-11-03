using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetByTag : MonoBehaviour
{
    public string targetTag = "PlayerShip";
    // Start is called before the first frame update
    void Start()
    {
        LockAim();
    }

    void LockAim(){
        GameObject[] players = GameObject.FindGameObjectsWithTag(targetTag);
        if (players != null){
            int numberOfPlayers = players.Length;
            int r = Random.Range(0,numberOfPlayers);
            SendMessage("SetTarget",players[r].gameObject);
        }   
    }
}
