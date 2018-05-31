using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topPart : MosquePart {

	GameObject cylinderPrefab;

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
        cylinderPrefab = GenericUtils.loadPrefab("generic", "cylinder12");
		myInstantiate (cylinderPrefab, transform.position, data.collarDiameter, 0.2f);
		GameObject topPrefab = myInstantiate (data.topPrefab, transform.position, data.collarDiameter, data.collarDiameter);
		GameObject mountpoint = topPrefab.transform.Find ("mountpoint").gameObject;
        placePart<DecorationPart>("decor", mountpoint.transform.position);
	}
	

}
