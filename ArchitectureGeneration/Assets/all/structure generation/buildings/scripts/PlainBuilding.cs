using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainBuilding : Building {

	public PlainBuildingDataStruct data;

	protected override void build (){
		GameObject dataholder = GameObject.Find ("DataHolder");
		data = dataholder.GetComponent<PlainBuildingData> ().getDataStruct (foundation); 
		placePart(data.fullFloorPart, foundation.center);
		placePart(data.windowedFloorPart, foundation.center + Vector3.up*(data.floorCount-1)*3);
		placePart (data.crenellationsPart, foundation.center + Vector3.up * (data.floorCount) * 3);
	}
}
