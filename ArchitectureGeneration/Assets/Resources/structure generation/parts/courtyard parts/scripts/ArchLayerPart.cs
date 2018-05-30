using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchLayerPart : CourtyardPart {

	public GameObject wallPrefab;
	public GameObject ceilingPrefab;

	private int sizeX;
	private int sizeZ;

	void Start () {
		initData ();
		sizeX = data.sizeX - 2;
		sizeZ = data.sizeZ - 2;
		Vector3 startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.left * sizeX / 2f);
		if (!instantiateArches (startPos, Vector3.right, sizeX, Vector3.back)) {
			startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.right * sizeX / 2f);
			instantiateArches (startPos, Vector3.left, sizeX-1, Vector3.back);
		}
		startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.right * sizeX / 2f);
		if (!instantiateArches (startPos, Vector3.back, sizeZ, Vector3.left)) {
			startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.right * sizeX / 2f);
			instantiateArches (startPos, Vector3.forward, sizeZ-1, Vector3.left);
		}
		startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.right * sizeX / 2f);
		if (!instantiateArches (startPos, Vector3.left, sizeX, Vector3.forward)) {
			startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.left * sizeX / 2f);
			instantiateArches (startPos, Vector3.right, sizeX-1, Vector3.forward);
		}
		startPos = transform.position + (Vector3.back * sizeZ / 2f) + (Vector3.left * sizeX / 2f);
		if (!instantiateArches (startPos, Vector3.forward, sizeZ, Vector3.right)) {
			startPos = transform.position + (Vector3.forward * sizeZ / 2f) + (Vector3.left * sizeX / 2f);
			instantiateArches (startPos, Vector3.back, sizeZ-1, Vector3.right);
		}
	}

	private bool instantiateArches(Vector3 startPos, Vector3 stepDir, int maxSteps, Vector3 lookdir){
		Vector3 pos = startPos+ 0.5f*stepDir;
		GameObject newPart;
		for (int i =0; i<maxSteps; i++){
			newPart = myInstantiateExtended (data.archPrefab, pos -0.5f*lookdir, 1, 1, 1);
			newPart.transform.LookAt(newPart.transform.position + lookdir);
			if (!Raycaster.stepClear(pos, stepDir)) {
				return false;
			}
			pos += stepDir.normalized;
		}
		return true;
	}

}
