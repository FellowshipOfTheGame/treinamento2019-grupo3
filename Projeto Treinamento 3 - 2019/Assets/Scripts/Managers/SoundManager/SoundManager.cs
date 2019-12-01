using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //music
    [SerializeField] private AudioClip[] ClipsMusic = null;
    [SerializeField] private AudioSource backGroundMusic = null;
    //sounds
    //[SerializeField] private AudioClip[] ClipsSounds = null;
    //[SerializeField] private AudioSource soundEffect = null;
    public static AudioClip beamShotSound;
    public static AudioClip simpleShotSound;
    public static AudioClip scatterShotSound;
    public static AudioClip missileShotSound;
    public static AudioClip playerDeathSound;
    public static AudioClip enemyShipExplosionSound;
    public static AudioClip turretExplosionSound;
    public static AudioClip meteorExplosionSound;
    public static AudioClip powerUpSound;

    static AudioSource audioSrc;

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
        //get AudioSource component
        audioSrc = GetComponent<AudioSource>();
    }

    void Update () {
        if (backGroundMusic && backGroundMusic.isPlaying) {
            backGroundMusic.clip = GetRandom ();
            backGroundMusic.Play ();
        }
    }

    AudioClip GetRandom () {
        return ClipsMusic[Random.Range (0, ClipsMusic.Length)];
    }

    //plays the respective clip
    public static void PlaySound(string clip){
        switch (clip) {
            case "beamShot":
                audioSrc.PlayOneShot(beamShotSound);
                break;
            case "simpleShot":
                audioSrc.PlayOneShot(simpleShotSound);
                break;
            case "scatterShot":
                audioSrc.PlayOneShot(scatterShotSound);
                break;
            case "missileShot":
                audioSrc.PlayOneShot(missileShotSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "enemyShipExplosion":
                audioSrc.PlayOneShot(enemyShipExplosionSound);
                break;
            case "turretExplosion":
                audioSrc.PlayOneShot(turretExplosionSound);
                break;
            case "meteorExplosion":
                audioSrc.PlayOneShot(meteorExplosionSound);
                break;
            case "powerUp":
                audioSrc.PlayOneShot(powerUpSound);
                break;
        }
    }

    /*public void PlaySound (int index) {
        soundEffect.clip = ClipsSounds[index];
        soundEffect.Play ();
    }*/
}
