using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftPartM : MinaretPart {

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		myInstantiate (data.shaftPrefab, transform.position, data.shaftWidth, data.shaftHeight);
	}

}
