using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardData : MonoBehaviour {

	GameObject[] windowPrefabs;

	public CourtyardBuildingDataStruct getDataStruct(BuildingFoundation foundation){
		CourtyardBuildingDataStruct data = new CourtyardBuildingDataStruct();
		ArchData ad = gameObject.GetComponent<ArchData> ();
        windowPrefabs = GenericUtils.loadAllPrefabs("prefabs/windows");
		data.sizeX = foundation.lengthX;
		data.sizeZ = foundation.lengthZ;
		data.windowPrefab = windowPrefabs[Random.Range(0,windowPrefabs.Length)];
		data.columnBasePrefab = ad.getColumnBase ();
		data.columnShaftPrefab = ad.getColumnShaft ();
		data.columnCapitalPrefab = ad.getColumnCapital ();
		data.archPrefab = ad.getArch ();	
		return data;
	}

}
