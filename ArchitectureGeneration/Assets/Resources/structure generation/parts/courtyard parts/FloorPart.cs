using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPart : CourtyardPart {

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
        GameObject p = GenericUtils.loadPrefab("generic","floorPrefab");
		myInstantiate (p, transform.position, data.sizeX, 1, data.sizeZ);
	}

}
