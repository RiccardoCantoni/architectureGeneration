using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPartM : MinaretPart{

	float baseHeight = 0.4f;
	float baseWidth = 0.3f;
	float shaftWidth = 0.2f;

	void Start () {
		initData ();
		myInstantiate (data.columnBase, transform.position, baseWidth, baseHeight);
		myInstantiate (data.columnShaft, transform.position, shaftWidth, 2f);
		myInstantiate (data.columnCapital, transform.position + Vector3.up * 2f, baseWidth, baseHeight);
	}
}
