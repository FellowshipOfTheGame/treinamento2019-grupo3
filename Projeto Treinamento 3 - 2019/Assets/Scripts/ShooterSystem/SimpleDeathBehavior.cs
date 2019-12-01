using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDeathBehavior : MonoBehaviour{
    public bool playSound = false;
    public string audioClipName;
    public void OnDeath(){
        Destroy(gameObject);
        if(playSound)
            SoundManager.PlaySound(audioClipName);
    }
}
