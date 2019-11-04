using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomSprite : MonoBehaviour{
    public GameObject[] spritesObjects;
    void Start(){
        Instantiate(spritesObjects[Random.Range(0, spritesObjects.Length-1)], transform);
        //transform.GetChild().gameObject.SetActive(true);
    }
}
