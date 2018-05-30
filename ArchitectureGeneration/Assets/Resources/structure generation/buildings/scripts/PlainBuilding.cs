using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainBuilding : Building {

	public PlainBuildingDataStruct data;

	protected override void build (){
		GameObject dataholder = GameObject.Find ("DataHolder");
		data = dataholder.GetComponent<PlainBuildingData> ().getDataStruct (foundation); 
		placePart<FullFloorPart>("fullFloor", foundation.center);
		placePart<WindowedFloorPart>("windowedFloor", foundation.center + Vector3.up*(data.floorCount-1)*3);
		placePart<PlainBuildingCrenellationsPart> ("crenellation", foundation.center + Vector3.up * (data.floorCount) * 3);
	}
}
