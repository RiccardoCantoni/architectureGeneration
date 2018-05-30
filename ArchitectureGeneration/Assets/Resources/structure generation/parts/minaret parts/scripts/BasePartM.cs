using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePartM : MinaretPart{

	void Start () {
		initData ();
		myInstantiate (data.basePrefab, transform.position, data.baseWidth, data.baseHeight);
	}

}
