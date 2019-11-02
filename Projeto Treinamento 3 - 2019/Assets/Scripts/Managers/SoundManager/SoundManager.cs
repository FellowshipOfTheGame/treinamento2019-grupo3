using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //music
    [SerializeField] private AudioClip[] ClipsMusic = null;
    [SerializeField] private AudioSource backGroundMusic = null;
    //sounds
    [SerializeField] private AudioClip[] ClipsSounds = null;
    [SerializeField] private AudioSource soundEffect = null;

    public static SoundManager instance = null;

    void Awake () {
        if (instance == null) {

            instance = this;
            DontDestroyOnLoad (this.gameObject);

        } else {
            Destroy (gameObject);
        }
    }

    void Update () {
        if (backGroundMusic.isPlaying) {
            backGroundMusic.clip = GetRandom ();
            backGroundMusic.Play ();
        }
    }

    AudioClip GetRandom () {
        return ClipsMusic[Random.Range (0, ClipsMusic.Length)];
    }

    public void PlaySound (int index) {
        soundEffect.clip = ClipsSounds[index];
        soundEffect.Play ();
    }
}
