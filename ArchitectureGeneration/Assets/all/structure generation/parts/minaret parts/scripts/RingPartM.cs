using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPartM : MinaretPart {

	void Start () {
		initData ();
		myInstantiate (data.ringPrefab, transform.position, data.ringWidth, data.ringHeight);
	}

}
