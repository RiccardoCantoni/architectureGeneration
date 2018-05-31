using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionPart : Part {

	GameObject junctionPrefab;

	void Start(){
        junctionPrefab = GenericUtils.loadPrefab("generic", "junctionPrefab");
		myInstantiate (junctionPrefab, transform.position, 4, 5, 2.5f);
	}
}
