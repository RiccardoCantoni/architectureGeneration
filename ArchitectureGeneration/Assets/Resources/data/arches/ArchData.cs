using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchData : MonoBehaviour{

	public List<GameObject> columnBases;
	public List<GameObject> columnShafts;
	public List<GameObject> columnCapitals;
	public List<GameObject> arches;
	public List<GameObject> simpleArches;

	public GameObject getColumnBase(){
		return columnBases[Random.Range(0,columnBases.Count)];
	}

	public GameObject getColumnShaft(){
		return columnShafts[Random.Range(0,columnShafts.Count)];
	}

	public GameObject getColumnCapital(){
		return columnCapitals [Random.Range (0, columnCapitals.Count)];
	}

	public GameObject getArch(){
		return arches[Random.Range(0,arches.Count)];
	}

	public GameObject getSimpleArch(){
		return simpleArches[Random.Range(0,simpleArches.Count)];
	}
}

