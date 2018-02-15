using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardPart : Part {

	protected CourtyardBuildingDataStruct data;

	protected void initData(){
		data = transform.root.GetComponent<Courtyard> ().data;
	}
}
