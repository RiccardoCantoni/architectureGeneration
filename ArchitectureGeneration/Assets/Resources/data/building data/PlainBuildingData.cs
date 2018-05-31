﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainBuildingData : MonoBehaviour {

	public List<GameObject> windowPrefabs;
	public GameObject wallPrefab;
	public GameObject fullFloorPrefab;
	public GameObject roofPrefab;

	public PlainBuildingDataStruct getDataStruct(BuildingFoundation foundation){
		PlainBuildingDataStruct data = new PlainBuildingDataStruct ();
		data.sizeX = foundation.lengthX;
		data.sizeZ = foundation.lengthZ;
		data.floorCount = Randomiser.intBetween (2, 3);
		data.windowPrefab = windowPrefabs [Random.Range (0, windowPrefabs.Count)];
		data.wallPrefab = wallPrefab;
		data.fullFloorPrefab = fullFloorPrefab;
		data.roofPrefab = roofPrefab;
		return data;
	}

}
