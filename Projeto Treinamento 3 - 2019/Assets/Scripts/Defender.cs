using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
	public float[] gridRelativeX;
	public float[] gridRelativeY;
	public GameObject cursor;
	private int cursorX = 0;
	private int cursorY = 0;	
	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode action1Key;

	public GameObject enemyShipPrefab;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
    	CursorInput();
    	RefreshCursorPosition();
    	ActionInput();
    }

    void ActionInput(){
    	if (Input.GetKeyDown(action1Key)){
    		Instantiate (enemyShipPrefab, CursorPosition(), Quaternion.identity);
    	}
    }

    private Vector3 CursorPosition(){
    	return transform.position + new Vector3(gridRelativeX[cursorX],gridRelativeY[cursorY],0);
    } 

    void CursorInput(){
    	if (Input.GetKeyDown(upKey)){
    		cursorY--;
    	}
    	if (Input.GetKeyDown(downKey)){
    		cursorY++;
    	}
    	if (Input.GetKeyDown(leftKey)){
    		cursorX--;
    	}
    	if (Input.GetKeyDown(rightKey)){
    		cursorX++;
    	}
    	if (cursorX < 0){
    		cursorX = gridRelativeX.Length-1;
    	}
    	if (cursorX > gridRelativeX.Length-1){
    		cursorX = 0;
    	}
    	if (cursorY < 0){
    		cursorY = gridRelativeY.Length-1;
    	}
    	if (cursorY > gridRelativeY.Length-1){
    		cursorY = 0;
    	}
    }

    void RefreshCursorPosition(){
    	cursor.transform.position = transform.position + new Vector3(gridRelativeX[cursorX],gridRelativeY[cursorY],0);
    }

    void OnDrawGizmos(){
    	Gizmos.color = Color.red;
    	for (int x = 0; x < gridRelativeX.Length; x++){
    		for (int y = 0; y < gridRelativeY.Length; y++){
    			Gizmos.DrawSphere(transform.position + new Vector3(gridRelativeX[x],gridRelativeY[y],0),0.5f);
    		}
    	}
    }
}
