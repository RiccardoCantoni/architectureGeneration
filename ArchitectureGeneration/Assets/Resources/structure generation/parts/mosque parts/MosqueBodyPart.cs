using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqueBodyPart : MosquePart {

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		myInstantiate (data.mosqueBodyPrefab, transform.position, data.size, data.size);
	}

}
