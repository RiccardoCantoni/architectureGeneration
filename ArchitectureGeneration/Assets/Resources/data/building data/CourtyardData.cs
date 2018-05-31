using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardData : MonoBehaviour {

	public List<GameObject> windowPrefabs;

	public CourtyardBuildingDataStruct getDataStruct(BuildingFoundation foundation){
		CourtyardBuildingDataStruct data = new CourtyardBuildingDataStruct();
		ArchData ad = gameObject.GetComponent<ArchData> ();
		data.sizeX = foundation.lengthX;
		data.sizeZ = foundation.lengthZ;
		data.windowPrefab = windowPrefabs[Random.Range(0,windowPrefabs.Count)];
		data.columnBasePrefab = ad.getColumnBase ();
		data.columnShaftPrefab = ad.getColumnShaft ();
		data.columnCapitalPrefab = ad.getColumnCapital ();
		data.archPrefab = ad.getArch ();	
		return data;
	}

}
