using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPart : CourtyardPart {

	public GameObject floorPrefab;

	void Start () {
		initData ();
		myInstantiateExtended (floorPrefab, transform.position, data.sizeX, 1, data.sizeZ);
	}

}
