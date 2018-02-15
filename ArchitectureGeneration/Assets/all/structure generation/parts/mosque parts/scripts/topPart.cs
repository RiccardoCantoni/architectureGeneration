using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topPart : MosquePart {

	public GameObject cylinderPrefab;

	void Start () {
		initData ();
		myInstantiate (cylinderPrefab, transform.position, data.collarDiameter, 0.2f);
		GameObject topPrefab = myInstantiate (data.topPrefab, transform.position, data.collarDiameter, data.collarDiameter);
		GameObject mountpoint = topPrefab.transform.Find ("mountpoint").gameObject;
		myInstantiate (data.decorPart ,mountpoint.transform.position, 1, 1);
	}
	

}
