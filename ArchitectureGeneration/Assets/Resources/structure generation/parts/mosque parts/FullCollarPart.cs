using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullCollarPart : MosquePart {

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		myInstantiate (data.fullCollarPrefab, transform.position, data.collarDiameter, data.collarHeight);
	}
	

}
