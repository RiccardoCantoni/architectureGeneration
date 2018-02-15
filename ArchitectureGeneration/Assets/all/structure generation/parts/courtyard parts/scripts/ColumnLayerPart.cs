using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnLayerPart : CourtyardPart {

	public GameObject columnPart;

	int sizeX;
	int sizeZ;

	void Start () {
		initData ();
		sizeX = data.sizeX - 2;
		sizeZ = data.sizeZ - 2;
		Vector3 startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.left * sizeX / 2f);
		if (!instantiateColumns (startPos, Vector3.right, sizeX)) {
			startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.right * sizeX / 2f) + Vector3.left;
			instantiateColumns (startPos, Vector3.left, sizeX);
		}
		startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.right * sizeX / 2f);
		if (!instantiateColumns (startPos, Vector3.back, sizeZ)) {
			startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.right * sizeX / 2f) + Vector3.forward;
			instantiateColumns (startPos, Vector3.forward, sizeZ);
		}
		startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.right * sizeX / 2f);
		if (!instantiateColumns (startPos, Vector3.left, sizeX)) {
			startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.left * sizeX / 2f) + Vector3.right;
			instantiateColumns (startPos, Vector3.right, sizeX);
		}
		startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.left * sizeX / 2f);
		if (!instantiateColumns (startPos, Vector3.forward, sizeZ)) {
			startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.left * sizeX / 2f) + Vector3.back;
			instantiateColumns (startPos, Vector3.back, sizeZ);
		}

	}

	private bool instantiateColumns(Vector3 startPos, Vector3 stepDir, int maxSteps){
		Vector3 pos = startPos;
		GameObject newPart;
		for (int i =0; i<maxSteps; i++){
			newPart = placePart (columnPart, pos);
			newPart.transform.LookAt(pos + GenericUtils.rotateClockwise(stepDir));
			if (!Raycaster.stepClear(pos, stepDir)) {
				newPart = placePart (columnPart, pos);
				newPart.transform.LookAt(pos + GenericUtils.rotateClockwise(stepDir));
				return false;
			}
			pos += stepDir.normalized;
		}
		return true;
	}

}
