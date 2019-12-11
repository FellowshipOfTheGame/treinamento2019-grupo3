using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //music
    //[SerializeField] private AudioClip[] ClipsMusic = null;
    //[SerializeField] private AudioSource backGroundMusic = null;
    public static AudioClip menuMusic;
    public static AudioClip gameplayMusic;
    //sounds
    public static AudioClip beamShotSound;
    public static AudioClip simpleShotSound;
    public static AudioClip scatterShotSound;
    public static AudioClip missileShotSound;
    public static AudioClip playerDeathSound;
    public static AudioClip enemyShipExplosionSound;
    public static AudioClip turretExplosionSound;
    public static AudioClip meteorExplosionSound;
    public static AudioClip powerUpSound;

    static AudioSource sfx;
    static AudioSource musicAudio;

    public static SoundManager instance = null;

    void Awake () {
        if (instance == null) {

            instance = this;
            DontDestroyOnLoad (this.gameObject);

        } else {
            Destroy (gameObject);
        }
    }

    void Start(){
        //load all the sfx in resources folder
        beamShotSound = Resources.Load<AudioClip>("beamShot");
        simpleShotSound = Resources.Load<AudioClip>("simpleShot");
        scatterShotSound = Resources.Load<AudioClip>("scatterShot");
        missileShotSound = Resources.Load<AudioClip>("missileShot");
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        enemyShipExplosionSound = Resources.Load<AudioClip>("enemyShipExplosion");
        turretExplosionSound = Resources.Load<AudioClip>("turretExplosion");
        meteorExplosionSound = Resources.Load<AudioClip>("meteorExplosion");
        powerUpSound = Resources.Load<AudioClip>("powerUp");
        //load all the musics in resources folder
        menuMusic = Resources.Load<AudioClip>("idiotsinspace");
        gameplayMusic = Resources.Load<AudioClip>("e");
        //get AudioSource components
        AudioSource[] audioSrcs = GetComponents<AudioSource>();
        sfx = audioSrcs[0];
        musicAudio = audioSrcs[1];
    }

    /*void Update () {
        if (backGroundMusic && backGroundMusic.isPlaying) {
            backGroundMusic.clip = GetRandom ();
            backGroundMusic.Play ();
        }
    }*/

   /*AudioClip GetRandom () {
        return ClipsMusic[Random.Range (0, ClipsMusic.Length)];
    }*/

    //plays the respective clip
    public static void PlaySound(string clip){
        switch (clip) {
            case "beamShot":
                sfx.PlayOneShot(beamShotSound);
                break;
            case "simpleShot":
                sfx.PlayOneShot(simpleShotSound);
                break;
            case "scatterShot":
                sfx.PlayOneShot(scatterShotSound);
                break;
            case "missileShot":
                sfx.PlayOneShot(missileShotSound);
                break;
            case "playerDeath":
                sfx.PlayOneShot(playerDeathSound);
                break;
            case "enemyShipExplosion":
                sfx.PlayOneShot(enemyShipExplosionSound);
                break;
            case "turretExplosion":
                sfx.PlayOneShot(turretExplosionSound);
                break;
            case "meteorExplosion":
                sfx.PlayOneShot(meteorExplosionSound);
                break;
            case "powerUp":
                sfx.PlayOneShot(powerUpSound);
                break;
        }
    }

    public static void PlayMusic(string music){
        switch (music) {
            case "menuMusic":
                musicAudio.clip = menuMusic;
                musicAudio.Play();
                break;
            case "gameplayMusic":
                musicAudio.clip = gameplayMusic;
                musicAudio.Play();
                break;
        }
    }

    /*public void PlaySound (int index) {
        soundEffect.clip = ClipsSounds[index];
        soundEffect.Play ();
    }*/
}
