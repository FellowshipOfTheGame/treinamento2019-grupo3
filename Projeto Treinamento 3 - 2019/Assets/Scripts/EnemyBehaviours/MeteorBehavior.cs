using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    public GameObject meteorPrefab = null;
    public float meteorAmount = 10f;
    public float minMeteorAmount = 2f;

    void Start() {
        // resize meteor
        // float scale = Mathf.Log(meteorAmount, 10);
        float scale = Mathf.Sqrt(meteorAmount);
        transform.localScale = new Vector3(scale,scale,1);
    }

    void SetMeteorAmount(float amount){
        meteorAmount = amount;
    }

    void OnDeath(){
        if (meteorAmount > 2*minMeteorAmount){
            Shatter();
        }else{
            DestroyThis();
        }
    }

    void Shatter(){
        // splits the meteor and its meteor amount into smaller meteors
        float splittedAmount = Random.Range(minMeteorAmount,meteorAmount-minMeteorAmount);
        GameObject m = null;
        m = Instantiate(meteorPrefab, transform.position, transform.rotation);
        m.SendMessage("SetMeteorAmount", splittedAmount);
        m = Instantiate(meteorPrefab, transform.position, transform.rotation);        
        m.SendMessage("SetMeteorAmount", meteorAmount - splittedAmount);
        DestroyThis();
    }

    void DestroyThis(){
        Destroy(gameObject);
    }
}
