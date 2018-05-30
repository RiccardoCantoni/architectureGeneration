using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqueBasePart : MosquePart {

	public GameObject basePrefab;

	void Start () {
		initData ();
		myInstantiate (basePrefab, transform.position, data.size, data.baseHeight);
	}

}
