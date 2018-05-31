using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqueBasePart : MosquePart {

	public GameObject basePrefab;

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		myInstantiate (basePrefab, transform.position, data.size, data.baseHeight);
	}

}
