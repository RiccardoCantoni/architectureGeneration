using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPartM : MinaretPart {

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		myInstantiate (data.ringPrefab, transform.position, data.ringWidth, data.ringHeight);
	}

}
