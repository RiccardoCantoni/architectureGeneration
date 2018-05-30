using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBuildingManager : MonoBehaviour {

	FoundationGenerator foundGen;
	FoundationData foundData;

	public GameObject minaretBuilding;
	public GameObject plainBuildingBuilding;
	public GameObject courtyardBuilding;
	public GameObject mosqueBuilding;
	public GameObject junctionPart;

	void Start () {
		foundData = GameObject.Find ("DataHolder").GetComponent<FoundationData> ();
		StartCoroutine (mainCoroutine ());
	}

	IEnumerator mainCoroutine(){
		foundGen= gameObject.GetComponent<FoundationGenerator>();
		yield return StartCoroutine (foundGen.generateImmediate ());
		foundData.receiveData (foundGen);

		foreach (BuildingFoundation b in foundData.rectangles) {
			GameObject newBuilding;
			if (Randomiser.rollUnder (50)) {
				newBuilding = Instantiate (plainBuildingBuilding, b.center, Quaternion.identity);

			} else {
				newBuilding = Instantiate (courtyardBuilding, b.center, Quaternion.identity);
			}
			Building script = newBuilding.GetComponent<Building> ();
			script.foundation = b;
			script.go ();
		}
			
		foreach (BuildingFoundation b in foundData.minarets) {
			GameObject newMinaret = Instantiate (minaretBuilding, b.center, Quaternion.identity);
			Building building = newMinaret.GetComponent<Building>();
			building.foundation = b;
			building.go ();
		}

		foreach (Junction j in foundData.junctions) {
			GameObject newJunction = Instantiate (junctionPart, j.position, Quaternion.identity);
			newJunction.transform.LookAt (newJunction.transform.position+j.axis);
		}

		foreach (BuildingFoundation m in foundData.squares) {
			GameObject newMosque = Instantiate (mosqueBuilding, m.center, Quaternion.identity);
			Building building = newMosque.GetComponent<Building> ();
			building.foundation = m;
			building.go ();
		}
	}
	

}
