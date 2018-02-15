using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainBuildingPart : Part {

	protected PlainBuildingDataStruct data;

	protected void initData(){
		data = transform.root.GetComponent<PlainBuilding> ().data;
	}
}
