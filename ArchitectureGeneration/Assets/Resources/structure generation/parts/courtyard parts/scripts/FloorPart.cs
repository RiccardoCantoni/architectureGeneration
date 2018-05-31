using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPart : CourtyardPart {

	void Start () {
		initData ();
        GameObject p = GenericUtils.loadPrefab("generic","floorPrefab");
		myInstantiate (p, transform.position, data.sizeX, 1, data.sizeZ);
	}

}
