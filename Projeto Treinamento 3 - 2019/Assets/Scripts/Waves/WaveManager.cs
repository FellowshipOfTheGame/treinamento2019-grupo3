using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
	public GameObject enemyPrefab;

	private Queue<Wave> waves;
	private Wave waveBeingBuild;


	public KeyCode action1Key;	
	public KeyCode action2Key;

	void Start(){
		waveBeingBuild = new Wave();
	}

	void Update(){
		if (Input.GetKeyDown(action1Key)){
			EnqueueEnemy();
		}
		if (Input.GetKeyDown(action2Key)){
			SpawnWave();
		}
	}

	void EnqueueEnemy(){
		Enemy enemy = new Enemy(enemyPrefab);
		waveBeingBuild.AddEnemy(enemy);		
	}

	void SpawnWave(){
		while (waveBeingBuild.enemies.Count > 0){
			Enemy enemyToSpawn = waveBeingBuild.enemies.Dequeue();
			Debug.Log(enemyToSpawn);
		}
	}
}

public class Wave {

	public Queue<Enemy> enemies = new Queue<Enemy>();

	public void AddEnemy(Enemy enemy){
		enemies.Enqueue(enemy);
		Debug.Log("Enemy enqueued");
	}
}

public class Enemy {

	public GameObject prefab;

	public Enemy(GameObject pf) {
		prefab = pf;
	}
}

