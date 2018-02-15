using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftPartM : MinaretPart {

	void Start () {
		initData ();
		myInstantiate (data.shaftPrefab, transform.position, data.shaftWidth, data.shaftHeight);
	}

}
