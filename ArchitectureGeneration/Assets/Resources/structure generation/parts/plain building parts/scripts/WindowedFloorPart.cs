using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowedFloorPart : PlainBuildingPart {


	void Start () {
		initData ();
		if (data.floorCount == 1) {
			myInstantiate (data.roofPrefab, transform.position, data.sizeX, 1, data.sizeZ);
		}
		instantiateWalls ();
		myInstantiate (data.roofPrefab, transform.position + Vector3.up * 3, data.sizeX, 1, data.sizeZ);
	}

	private void instantiateWalls(){
		Vector3 startPos = transform.position + (Vector3.left * data.sizeX / 2f) + (Vector3.forward * data.sizeZ / 2f) + (Vector3.back * 0.1f);
		instantiateWall (startPos, Vector3.right, data.sizeX, Vector3.back);
		startPos = transform.position + (Vector3.right * data.sizeX / 2f) + (Vector3.forward * data.sizeZ / 2f) + (Vector3.left * 0.1f);
		instantiateWall (startPos, Vector3.back, data.sizeZ, Vector3.right);
		startPos = transform.position + (Vector3.right * data.sizeX / 2f) + (Vector3.back * data.sizeZ / 2f) + (Vector3.forward * 0.1f);
		instantiateWall (startPos, Vector3.left, data.sizeX, Vector3.forward);
		startPos = transform.position + (Vector3.left * data.sizeX / 2f) + (Vector3.back * data.sizeZ / 2f) + (Vector3.right * 0.1f);
		instantiateWall (startPos, Vector3.forward, data.sizeZ, Vector3.right);
	}

	private void instantiateWall(Vector3 startPos, Vector3 stepDir, int stepNumber, Vector3 lookDir){
		List<bool> windowSequence = GenericUtils.windowSequence (stepNumber);
		Vector3 curPos = startPos + stepDir * 0.5f;
		GameObject obj;
		foreach (bool window in windowSequence) {
			if (window) {
				obj = data.windowPrefab;
			} else {
				obj = data.wallPrefab;
			}
			GameObject newObj = myInstantiate(obj, curPos, 1 , 3, 0.2f);
			newObj.transform.LookAt (newObj.transform.position + GenericUtils.rotateClockwise (stepDir));
			curPos += stepDir;
		}
	}
		
}
