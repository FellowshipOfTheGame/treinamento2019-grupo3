using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construtor : MonoBehaviour
{
    public string playerController;
	public string action1Key;	
	public string action2Key;

	public string upKey;
	public string downKey;
	public string leftKey;
	public string rightKey;

    public GridScript grid;
    public WaveManager waveManager;
    public float inputDelay = 0.1f;
    public float inputDelayTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (inputDelayTimer > 0){
            inputDelayTimer -= Time.deltaTime;
        }
        float horizontal = Input.GetAxisRaw(playerController + "Horizontal");        
        float vertical = Input.GetAxisRaw(playerController + "Vertical");
        bool up = (vertical > 0);
        bool down = (vertical < 0);
        bool left = (horizontal < 0);
        bool right = (horizontal > 0);
        if (up || down || left || right || inputDelayTimer <= 0) {
            inputDelayTimer = inputDelay;
            grid.CursorInput(up,down,left,right);
        }
        
        if (Input.GetButtonDown(playerController + action1Key)){
            waveManager.EnqueueEnemy();
        }
    }
}
