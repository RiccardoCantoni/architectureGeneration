using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBuildingManager : MonoBehaviour {

	FoundationGenerator foundGen;
	FoundationData foundData;


	void Start () {
		foundData = GameObject.Find ("DataHolder").GetComponent<FoundationData> ();
		StartCoroutine (mainCoroutine ());
	}

	IEnumerator mainCoroutine(){
        Building building;
        GameObject newBuilding;
		foundGen= gameObject.GetComponent<FoundationGenerator>();
		yield return StartCoroutine (foundGen.generateImmediate ());
		foundData.receiveData (foundGen);

		foreach (BuildingFoundation b in foundData.rectangles) {
			if (Randomiser.rollUnder (50)) {
                newBuilding = Part.placeRootPart<PlainBuilding>("plain building", b.center);

			} else {
				newBuilding = Part.placeRootPart<Courtyard>("plain building", b.center);
            }
			building = newBuilding.GetComponent<Building> ();
			building.foundation = b;
			building.go ();
		}
			
		foreach (BuildingFoundation b in foundData.minarets) {
            newBuilding = Part.placeRootPart<Minaret>("minaret", b.center);
			building = newBuilding.GetComponent<Building>();
			building.foundation = b;
			building.go ();
		}

		foreach (Junction j in foundData.junctions) {
            newBuilding = Part.placeRootPart<JunctionPart>("junction", j.position);
			newBuilding.transform.LookAt (newBuilding.transform.position+j.axis);
		}

		foreach (BuildingFoundation m in foundData.squares) {
            newBuilding = Part.placeRootPart<Mosque>("mosque", m.center);
			building = newBuilding.GetComponent<Building> ();
			building.foundation = m;
			building.go ();
		}
	}	

}
