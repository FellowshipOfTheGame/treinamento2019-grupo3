using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construtor : MonoBehaviour
{
    public string playerController;
	public string action1Key;	
	public string action2Key;
	public string action3Key;	
	public string action4Key;

	public string upKey;
	public string downKey;
	public string leftKey;
	public string rightKey;

    public GridScript grid;
    public WaveManager waveManager;
    bool up, down, left, right = false;
    bool verticalButtonDown, horizontalButtonDown = false;

    public GameObject[] enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {        
        up = false;
        down = false;
        left = false;
        right = false;
        float horizontal = Input.GetAxisRaw(playerController + "Horizontal");        
        float vertical = Input.GetAxisRaw(playerController + "Vertical");

        if (vertical == 0){
            verticalButtonDown = false;
        }else{
            if (verticalButtonDown == false){
                up = (vertical > 0);
                down = (vertical < 0);                
                verticalButtonDown = true;
            }
        }

        if (horizontal == 0){
            horizontalButtonDown = false;
        }else{
            if (horizontalButtonDown == false){
                left = (horizontal < 0);
                right = (horizontal > 0);
                horizontalButtonDown = true;
            }
        }

        if (up || down || left || right) {
            grid.CursorInput(up,down,left,right);
        }
        
        // input to place enemy prefab in the wave being built
        if (Input.GetButtonDown(playerController + action1Key)){
            waveManager.EnqueueEnemy(enemyPool[0]);
        }
        if (Input.GetButtonDown(playerController + action2Key)){
            waveManager.EnqueueEnemy(enemyPool[1]);
        }
        if (Input.GetButtonDown(playerController + action3Key)){
            waveManager.EnqueueEnemy(enemyPool[2]);
        }
        if (Input.GetButtonDown(playerController + action4Key)){
            waveManager.EnqueueEnemy(enemyPool[3]);
        }
    }
}
