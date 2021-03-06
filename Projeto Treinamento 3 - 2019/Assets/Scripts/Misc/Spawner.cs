﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnList = null;    
    public GameObject[] spawnOnceList = null;
    public float timeBetweenSpawns = 1f;    
    private float spawnTimer = 0f;
    public float minY, maxY = 0f;

    void Start() {
        foreach (GameObject g in spawnOnceList){
            Instantiate(g , new Vector3(-25,0,0) , Quaternion.identity);
        }
        SoundManager.PlayMusic("gameplayMusic");
    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0){
            spawnTimer = timeBetweenSpawns;
            SpawnRandom();
        }
    }

    void SpawnRandom(){
        if (spawnList.Length != 0){
            int i = Random.Range(0, spawnList.Length);
            Vector3 pos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0);
            Instantiate(spawnList[i], pos, transform.rotation);
        }        
    }
}
