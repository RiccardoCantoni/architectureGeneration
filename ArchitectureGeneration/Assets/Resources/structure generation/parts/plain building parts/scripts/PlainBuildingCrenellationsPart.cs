using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainBuildingCrenellationsPart : PlainBuildingPart {

	public GameObject crenellationPrefab;

	void Start () {
        crenellationPrefab = GenericUtils.loadPrefab("generic", "crenellationPart");
		initData ();
		instantiateCrenellations ();
	}

	private void instantiateCrenellations(){
		Vector3 startPos = transform.position + (Vector3.left * data.sizeX / 2f) + (Vector3.forward * data.sizeZ / 2f) + (Vector3.back * 0.1f);
		instantiateCrenellation (startPos, Vector3.right, data.sizeX, Vector3.back);
		startPos = transform.position + (Vector3.right * data.sizeX / 2f) + (Vector3.forward * data.sizeZ / 2f) + (Vector3.left * 0.1f) ;
		instantiateCrenellation (startPos, Vector3.back, data.sizeZ, Vector3.right);
		startPos = transform.position + (Vector3.right * data.sizeX / 2f) + (Vector3.back * data.sizeZ / 2f) + (Vector3.forward * 0.1f);
		instantiateCrenellation (startPos, Vector3.left, data.sizeX, Vector3.forward);
		startPos = transform.position + (Vector3.left * data.sizeX / 2f) + (Vector3.back * data.sizeZ / 2f) + (Vector3.right * 0.1f);
		instantiateCrenellation (startPos, Vector3.forward, data.sizeZ, Vector3.right);
	}

	private void instantiateCrenellation(Vector3 startPos, Vector3 stepDir, int stepNumber, Vector3 lookDir){
		Vector3 curPos = startPos + stepDir * 0.5f;
		for (int i = 0; i < stepNumber; i++) {
			GameObject newObj = myInstantiate(crenellationPrefab, curPos, 1 , 0.5f, 0.2f);
			newObj.transform.LookAt (newObj.transform.position + GenericUtils.rotateClockwise (stepDir));
			curPos += stepDir;
		}
	}
}
