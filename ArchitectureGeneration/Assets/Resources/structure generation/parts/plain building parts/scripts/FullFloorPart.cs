using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullFloorPart : PlainBuildingPart {

	void Start () {
		initData ();
		if (data.floorCount > 1) {
			myInstantiate (data.fullFloorPrefab, transform.position, data.sizeX, 3 * (data.floorCount - 1), data.sizeZ);
		}
	}
}
