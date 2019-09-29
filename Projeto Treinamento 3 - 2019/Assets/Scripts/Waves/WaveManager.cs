using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
	// enemies that will be available to be placed on the waves
	public GameObject enemyPrefab;

	// Objects to store the waves of enemies
	public Queue<Wave> waves = new Queue<Wave>();
	public Wave[] wavesBeingBuild;

	private GridScript grid;

	public int wavesQueued;
    
	public float timeToAutoEnqueueWaves = 5;
	public float autoEnqueueTimer = 0;
	public float timeToSpawnWave = 7;
	public float spawnWaveTimer = 0;

	void Start(){
		grid = gameObject.GetComponent<GridScript>();
		wavesBeingBuild = new Wave[grid.numberOfGridColumns];
		RenewWavesBeingBuild();
	}

	void RenewWavesBeingBuild(){
		for (int i = 0; i < grid.numberOfGridColumns; i++){
			wavesBeingBuild[i] = new Wave();
		}
	}

	void Update(){
		wavesQueued = waves.Count;
		autoEnqueueTimer += Time.deltaTime;		
		spawnWaveTimer += Time.deltaTime;
		if (autoEnqueueTimer >= timeToAutoEnqueueWaves){
			autoEnqueueTimer = 0;
			EnqueueWavesBeingBuilt();
		}
		if (spawnWaveTimer >= timeToSpawnWave){
			spawnWaveTimer = 0;
			SpawnWave();
		}
	}
	public void EnqueueWavesBeingBuilt (){
		for (int i = 0; i < grid.numberOfGridColumns; i++){
			Wave wave = wavesBeingBuild[i];
			waves.Enqueue(wave);
		}
		RenewWavesBeingBuild();
		Debug.Log("Waves enqueued");
	}


	public void EnqueueEnemy(){
		Enemy enemy = new Enemy(enemyPrefab,grid.gridRowsPositions[grid.cursorY]);
		wavesBeingBuild[grid.cursorX].AddEnemy(enemy);
	}

	void SpawnWave(){
		Debug.Log(grid.cursorX);
		Wave waveBeingSpawned = waves.Dequeue();
		while (waveBeingSpawned.enemies.Count > 0){
			Enemy enemyToSpawn = waveBeingSpawned.enemies.Dequeue();
			Debug.Log(enemyToSpawn);
			Instantiate(enemyToSpawn.prefab, new Vector3(20,enemyToSpawn.verticalPosition,0), Quaternion.identity);
		}
		Debug.Log("Wave spawned");
	}
}

[System.Serializable]
public class Wave {
	public Queue<Enemy> enemies = new Queue<Enemy>();
	public void AddEnemy(Enemy enemy){
		enemies.Enqueue(enemy);
		Debug.Log("Enemy enqueued");
	}
}

public class Enemy {
	public GameObject prefab;
	public float verticalPosition;
	public Enemy(GameObject pf, float vP) {
		prefab = pf;
		verticalPosition = vP;
	}
}

