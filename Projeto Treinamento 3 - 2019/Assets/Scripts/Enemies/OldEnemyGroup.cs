using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEnemyGroup : MonoBehaviour{

    //the data structure used is a dictionary which has a key(that is a transform) 
    //that is associated to his value(GameObject of enemy)
    public Dictionary<Transform, GameObject> group;    

    public void AddEnemy(Transform t, GameObject go){
        group.Add(t, go);
    }

    public void SpawnGroup(){
        //Instantiate all the enemies in their respective transform.positions
        foreach (KeyValuePair<Transform, GameObject> enemy in group) {
            GameObject instance = Instantiate(enemy.Value, enemy.Key.position, Quaternion.identity);
            instance.transform.parent = transform.parent;
        }
        //autodestroy
        Destroy(gameObject);
    }

    /* in wave spawn...
    EnemyGroup eg;
    instance = Instantiate(eg);
    instance.AddEnemy(transform1, enemyPrefab1);
    instance.AddEnemy(transform2, enemyPrefab2);
    instance.SpawnGroup(); //now, instance is null
    instance = Instantiate(eg);
    ...
    */
}
