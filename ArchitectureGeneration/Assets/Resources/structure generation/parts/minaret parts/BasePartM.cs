using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePartM : MinaretPart{

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		myInstantiate (data.basePrefab, transform.position, data.baseWidth, data.baseHeight);
	}

}
