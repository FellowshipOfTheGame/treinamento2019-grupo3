using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
	public GameObject enemyToken;

	// Objects to store the waves of enemies
	public Queue<Wave> wavesQueued = new Queue<Wave>();
	public Wave[] wavesBeingBuild;

	private GridScript grid;
    
	public float timeToAutoEnqueueWaves = 5;
	public float autoEnqueueTimer = 0;
	public float timeToSpawnWave = 7;
	public float spawnWaveTimer = 8;

	void Start(){
		grid = gameObject.GetComponent<GridScript>();
		wavesBeingBuild = new Wave[grid.numberOfGridColumns];
		RenewWavesBeingBuild(); // first call to instantiate the waves being built
	}

	// update called once a frame	
	void Update(){
		ShowTokenOnWavesBeingBuilt();
		autoEnqueueTimer += Time.deltaTime;
		if (wavesQueued.Count > 0){
			spawnWaveTimer += Time.deltaTime;
		}
		if (autoEnqueueTimer >= timeToAutoEnqueueWaves){
			autoEnqueueTimer = 0;
			EnqueueWavesBeingBuilt();
		}
		if (spawnWaveTimer >= timeToSpawnWave){
			spawnWaveTimer = 0;
			SpawnWave();
		}
	}

	// put the waves being built in the queue of waves to be spawned, then clear the waves being built
	public void EnqueueWavesBeingBuilt (){
		for (int i = 0; i < grid.numberOfGridColumns; i++){
			Wave wave = wavesBeingBuild[i];
			wavesQueued.Enqueue(wave);
		}
		RenewWavesBeingBuild();
		Debug.Log("Waves enqueued");
	}

	// add the argument enemy prefab to the current wave being built, in the cursor position
	public void EnqueueEnemy(GameObject enemyPrefab){
		Enemy enemy = new Enemy(enemyPrefab,grid.gridRowsPositions[grid.cursorY]);
		wavesBeingBuild[grid.cursorX].AddEnemy(enemy, grid.cursorY);
	}

	// gets the next wave in queue and spawns the enemies in it
	void SpawnWave(){
		Wave waveBeingSpawned = wavesQueued.Dequeue();
		if (waveBeingSpawned != null){
			for (int i = 0; i < waveBeingSpawned.enemies.Length; i++){
				Enemy enemyToSpawn = waveBeingSpawned.enemies[i];
				if (enemyToSpawn != null){
					Debug.Log(enemyToSpawn);
					Instantiate(enemyToSpawn.prefab, new Vector3(20,enemyToSpawn.verticalPosition,0), Quaternion.identity);
				}
			}
			Debug.Log("Wave spawned");
		}
	}
	
	// clear the objects used in the waves being built
	void RenewWavesBeingBuild(){
		for (int i = 0; i < grid.numberOfGridColumns; i++){
			wavesBeingBuild[i] = new Wave(grid.numberOfGridRows);
		}
	}

	// instantiate objects to show tokens of enemies placed in the waves being built
	public void ShowTokenOnWavesBeingBuilt(){
		for (int w = 0; w < wavesBeingBuild.Length; w++){
			for (int e = 0; e < wavesBeingBuild[w].enemies.Length; e++){
				// e = row
				// w = column
				if (wavesBeingBuild[w].enemies[e] != null){
					if (grid.tokens[w,e] == null) {
						Vector3 tokenPosition = new Vector3(grid.gridColumnsPositions[w],grid.gridRowsPositions[e],0);
						grid.tokens[w,e] = Instantiate(enemyToken, tokenPosition,  Quaternion.identity);
					}
				}
				else{
					if (grid.tokens[w,e] != null){
						Destroy(grid.tokens[w,e]);
					}
				}
			}
		}
	}
}


// class to store the enemies that will be spawned at the same time (wave = 1 column of the grid)
[System.Serializable]
public class Wave {
	public Enemy[] enemies;
	public Wave(int waveEnemySize){
		enemies = new Enemy[waveEnemySize];
	}
	public void AddEnemy(Enemy enemy, int inWaveIndex){
		if (enemies[inWaveIndex] == null){
			enemies[inWaveIndex] = enemy;
			Debug.Log("Enemy enqueued");
		}
	}
}

// class to store the enemy prefab and the vertical position in which it will be spawned
public class Enemy {
	public GameObject prefab;
	public float verticalPosition;
	public Enemy(GameObject pf, float vP) {
		prefab = pf;
		verticalPosition = vP;
	}
}

