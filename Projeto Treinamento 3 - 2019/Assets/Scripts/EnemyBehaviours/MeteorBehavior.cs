using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    public GameObject meteorPrefab = null;
    public float maxMeteorAmount = 10f;
    public float meteorAmount = 10f;
    public float minMeteorAmount = 2f;
    public float maxScale = 1f;

    void Start() {
        // resize meteor
        // float scale = Mathf.Log(meteorAmount, 10);
        float scale = (meteorAmount/maxMeteorAmount) * maxScale;
        transform.localScale = new Vector3(scale,scale,1);
    }

    void SetMeteorAmount(float amount){
        meteorAmount = amount;
    }

    void SetMaxMeteorAmount(float amount){
        maxMeteorAmount = amount;
    }

    void SetMaxScale(float amount){
        maxScale = amount;
    }

    void OnDeath(){
        if (meteorAmount > minMeteorAmount){
            Shatter();
        }else{
            DestroyThis();
        }
        SoundManager.PlaySound("meteorExplosion");
    }

    void Shatter(){
        // splits the meteor and its meteor amount into smaller meteors
        float splittedAmount = Random.Range(minMeteorAmount,meteorAmount-minMeteorAmount);
        GameObject m = null;
        m = Instantiate(meteorPrefab, transform.position, transform.rotation);
        m.SendMessage("SetMeteorAmount", splittedAmount);
        m.SendMessage("SetMaxMeteorAmount", maxMeteorAmount);
        m.SendMessage("SetMaxScale", maxScale);
        m = Instantiate(meteorPrefab, transform.position, transform.rotation);        
        m.SendMessage("SetMeteorAmount", meteorAmount - splittedAmount);
        m.SendMessage("SetMaxMeteorAmount", maxMeteorAmount);
        m.SendMessage("SetMaxScale", maxScale);
        DestroyThis();
    }

    void DestroyThis(){
        Destroy(gameObject);
    }
}
