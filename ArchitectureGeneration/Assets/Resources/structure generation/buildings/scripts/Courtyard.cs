using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courtyard : Building {

	public CourtyardBuildingDataStruct data;

	protected override void build (){
		GameObject dataholder = GameObject.Find ("DataHolder");
		data = dataholder.GetComponent<CourtyardData> ().getDataStruct (foundation);
        placePart<FloorPart>("floorpart", foundation.center);
        placePart<FirstFloorPart>("firstFloorPart", foundation.center);
        placePart<CourtyardCrenellationsPart>("crenellationsPart", foundation.center + Vector3.up * 2.5f);
	}

}
