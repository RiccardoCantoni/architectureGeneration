using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPart : CourtyardPart {

	float baseHeight = 0.25f;
	float baseWidth = 0.3f;
	float shaftWidth = 0.2f;

	void Start () {
		initData ();
		myInstantiate (data.columnBasePrefab, transform.position, baseWidth, baseHeight);
		myInstantiate (data.columnShaftPrefab, transform.position, shaftWidth, 1.5f);
		myInstantiate (data.columnCapitalPrefab, transform.position + Vector3.up * 1.5f, baseWidth, baseHeight);
	}

}