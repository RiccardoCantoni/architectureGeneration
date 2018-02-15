using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullCollarPart : MosquePart {

	void Start () {
		initData ();
		myInstantiate (data.fullCollarPrefab, transform.position, data.collarDiameter, data.collarHeight);
	}
	

}
