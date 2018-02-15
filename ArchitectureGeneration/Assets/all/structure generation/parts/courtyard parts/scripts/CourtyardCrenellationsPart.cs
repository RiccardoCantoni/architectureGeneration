using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardCrenellationsPart : CourtyardPart {
	
	public GameObject crenellationPrefab;

	void Start () {
		initData ();
		Vector3 startPos = transform.position + (Vector3.forward * data.sizeZ / 2f) + (Vector3.left * data.sizeX / 2f);
		if (!instantiateCrenellation (startPos, Vector3.right, data.sizeX, Vector3.back)) {
			startPos = transform.position + (Vector3.forward * data.sizeZ / 2f) + (Vector3.right * data.sizeX / 2f);
			instantiateCrenellation (startPos, Vector3.left, data.sizeX-1, Vector3.back);
		}
		startPos = transform.position + (Vector3.forward * data.sizeZ / 2f) + (Vector3.right * data.sizeX / 2f);
		if (!instantiateCrenellation (startPos, Vector3.back, data.sizeZ, Vector3.left)) {
			startPos = transform.position + (Vector3.back * data.sizeZ / 2f) + (Vector3.right * data.sizeX / 2f);
			instantiateCrenellation (startPos, Vector3.forward, data.sizeZ-1, Vector3.left);
		}
		startPos = transform.position + (Vector3.back * data.sizeZ / 2f) + (Vector3.right * data.sizeX / 2f);
		if (!instantiateCrenellation (startPos, Vector3.left, data.sizeX, Vector3.forward)) {
			startPos = transform.position + (Vector3.back * data.sizeZ / 2f) + (Vector3.left * data.sizeX / 2f);
			instantiateCrenellation (startPos, Vector3.right, data.sizeX-1, Vector3.forward);
		}
		startPos = transform.position + (Vector3.back * data.sizeZ / 2f) + (Vector3.left * data.sizeX / 2f);
		if (!instantiateCrenellation (startPos, Vector3.forward, data.sizeZ, Vector3.right)) {
			startPos = transform.position + (Vector3.forward * data.sizeZ / 2f) + (Vector3.left * data.sizeX / 2f);
			instantiateCrenellation (startPos, Vector3.back, data.sizeZ-1, Vector3.right);
		}
	}

	private bool instantiateCrenellation(Vector3 startPos, Vector3 stepDir, int maxSteps, Vector3 lookdir){
		Vector3 pos = startPos+ 0.5f*stepDir;
		GameObject newPart;
		for (int i =0; i<maxSteps; i++){
			newPart = myInstantiateExtended (crenellationPrefab, pos + 0.1f*lookdir, 1, 1, 0.2f);
			newPart.transform.LookAt(newPart.transform.position + lookdir);
			if (!Raycaster.stepClear(pos, stepDir)) {
				return false;
			}
			pos += stepDir.normalized;
		}
		return true;
	}
		


}
