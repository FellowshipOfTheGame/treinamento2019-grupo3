using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text[] ScoreUI = new Text[4];

    void Awake () {
        if (instance == null) {

            instance = this;
            DontDestroyOnLoad (this.gameObject);

        } else {
            Destroy (gameObject);
        }

        SceneManager.sceneLoaded += Loading;// search texts
    }

    void Loading(Scene scene, LoadSceneMode mode){
        for(int i = 0; i<4; i++){
            ScoreUI[i] = GameObject.Find("/*nome do text */" + i.ToString()).GetComponent<Text>();// search texts to enter score
        }
    }

    public void UpdateUI(){
        for(int i = 0; i<4; i++){
            ScoreUI[i].text = ScoreManager.instance.scorePlayer[i].ToString();//load score value into UI
        }
    }
}
