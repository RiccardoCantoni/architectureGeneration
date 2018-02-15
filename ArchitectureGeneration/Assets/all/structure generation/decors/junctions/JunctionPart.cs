using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionPart : Part {

	public GameObject junctionPrefab;

	void Start(){
		myInstantiateExtended (junctionPrefab, transform.position, 4, 5, 2.5f);
	}
}
