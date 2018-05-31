using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPartM : MinaretPart {

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
		GameObject topPrefab = myInstantiate (data.topPrefab, transform.position, data.topWidth, data.topHeight);
		GameObject mountpoint = topPrefab.transform.Find ("mountpoint").gameObject;
        placePart<DecorationPart>("decor", mountpoint.transform.position);
		//myInstantiate (data.decorPart ,mountpoint.transform.position, data.decorWidth, data.decorHeight);
	}
	
}
