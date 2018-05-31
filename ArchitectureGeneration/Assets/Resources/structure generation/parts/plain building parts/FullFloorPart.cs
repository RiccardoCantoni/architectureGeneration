using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullFloorPart : PlainBuildingPart {

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		if (data.floorCount > 1) {
			myInstantiate (data.fullFloorPrefab, transform.position, data.sizeX, 3 * (data.floorCount - 1), data.sizeZ);
		}
	}
}
