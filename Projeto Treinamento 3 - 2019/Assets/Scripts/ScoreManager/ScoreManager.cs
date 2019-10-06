using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int[] scorePlayer = new int[4];

    void Awake () {
        if (instance == null) {

            instance = this;
            DontDestroyOnLoad (this.gameObject);

        } else {
            Destroy (gameObject);
        }
    }

    public void GameStartScore(){
        for(int i = 0; i<4; i++){
            scorePlayer[i] = 0;
        }
    }

    public void CalculateDamagePoints(string data){
        //Isso nao e comentario de codigo ainda
        //dependendo de como for a string vai dar mais ou menos pontos
        //AddScore(string data, int value) //data os dados de quem mandou e value e o valor a ser somado
    }

    public void CalculateKillPoints(string data){
        //Isso nao e comentario de codigo ainda
        //dependendo de como for a string vai dar mais ou menos pontos
        //AddScore(string data, int value) //data os dados de quem mandou e value e o valor a ser somado
    }

    public void AddScore(string data, int value){
        //Isso nao e comentario de codigo ainda
        //Com o data vc descobre o index do PlayerPrefs 
        //scorePlayer[index] += value;
    }
}
