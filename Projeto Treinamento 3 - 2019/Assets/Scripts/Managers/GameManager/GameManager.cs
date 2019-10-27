using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public string playerController;
    private bool lockUnlock = true; 
    public static GameManager instance;

    void Awake () {
        if (instance == null) {

            instance = this;
            DontDestroyOnLoad (this.gameObject);

        } else {
            Destroy (gameObject);
        }
    }

    void Start()
    {
        ScoreManager.instance.GameStartScore();
    }

    void Update () {
        StartPress();
        UIManager.instance.UpdateUI();
    }

    void ChangeScene () {

        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    void PauseGame(){
        if(Time.timeScale == 1){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }

    void StartPress(){
        float test = Input.GetAxisRaw (playerController + "Start");
        if (test != 0) {
            Scene m_Scene = SceneManager.GetActiveScene ();
            if (m_Scene.name == "initialScene") {
                ChangeScene ();
            } else {
                if(lockUnlock){
                    PauseGame();
                    lockUnlock = false;
                }
            }
        }else{
            lockUnlock = true;
        }
    }
}
