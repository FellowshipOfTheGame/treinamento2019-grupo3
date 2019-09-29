using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {

	// Grid
	public float screenSizePercentX = 0.2f;
	public float screenSizePercentY = 1f;
	public float screenOffsetPercentX = 0.9f;
	public float screenOffsetPercentY = 0.5f;
	public int numberOfGridRows;
	public int numberOfGridColumns;

	public float[] gridRowsPositions;
	public float[] gridColumnsPositions;

	// Cursor e controles
	public GameObject cursor;
	public int cursorX = 0;
	public int cursorY = 0;
	public float cursorSpeed = 10;

	// Outros
	public Camera mainCamera;

    void Start(){
        
    }

    void Update(){
        AjustToScreenSize();
        
       	RefreshCursorPosition();
    }

    public void CursorInput(bool up, bool down, bool left, bool right){
    	if (up) cursorY++;
    	if (down) cursorY--;
    	if (left) cursorX--;
    	if (right) cursorX++;
    	cursorX = Mathf.Clamp(cursorX, 0, numberOfGridColumns-1);
    	cursorY = Mathf.Clamp(cursorY, 0, numberOfGridRows-1);
    }
    void RefreshCursorPosition(){
    	Vector3 posDiff = new Vector3(gridColumnsPositions[cursorX],gridRowsPositions[cursorY],0) - cursor.transform.position;
    	cursor.transform.Translate(cursorSpeed * posDiff * Time.deltaTime);
    }

    void AjustToScreenSize(){

        gridRowsPositions = new float[numberOfGridRows];
        gridColumnsPositions = new float[numberOfGridColumns];

    	int camPixelX = mainCamera.pixelWidth;
    	int camPixelY = mainCamera.pixelHeight;
    	
    	// for Rows 
    	for (int i = 0; i < numberOfGridRows; i++){
    		float pixelPos = camPixelY*(screenOffsetPercentY - (screenSizePercentY/2));
    		pixelPos += (camPixelY*screenSizePercentY)*(i+0.5f)/numberOfGridRows;
    		gridRowsPositions[i] = mainCamera.ScreenToWorldPoint(new Vector3(0,pixelPos,0)).y;
    	}

    	// for Columns
    	for (int i = 0; i < numberOfGridColumns; i++){
    		float pixelPos = camPixelX*(screenOffsetPercentX - (screenSizePercentX/2));
    		pixelPos += (camPixelX*screenSizePercentX)*(i+0.5f)/numberOfGridColumns;
    		gridColumnsPositions[i] = mainCamera.ScreenToWorldPoint(new Vector3(pixelPos,0,0)).x;
    	}
    }

    void OnDrawGizmos(){
    	Gizmos.color = Color.red;
    	for (int x = 0; x < gridRowsPositions.Length; x++){
    		for (int y = 0; y < gridColumnsPositions.Length; y++){
    			Gizmos.DrawSphere(new Vector3(gridColumnsPositions[y],gridRowsPositions[x],0),0.5f);
    		}
    	}
    }
}
