using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;

    void Awake () {
        if (instance == null) {

            instance = this;
            DontDestroyOnLoad (this.gameObject);

        } else {
            Destroy (gameObject);
        }
    }

    public int StartLifeValue(string data){

        int value =0;
        //Isso nao e comentario de codigo ainda
        //Dependendo do data returna um valor diferente de vida

        return value ; 
    }

    public int DamageLife(string data){
        int value =0;
        //Isso nao e comentario de codigo ainda
        //Dependendo do data returna um valor diferente para o dano aplicado

        return value ;
    }
}
