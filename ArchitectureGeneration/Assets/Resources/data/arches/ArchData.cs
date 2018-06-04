using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchData : MonoBehaviour{

	GameObject[] columnBases;
    GameObject[] columnShafts;
    GameObject[] columnCapitals;
    GameObject[] arches;
    GameObject[] simpleArches;

    bool data = false;

    void getData()
    {
        if (data) return;
        columnBases = GenericUtils.loadAllPrefabs("prefabs/columns/base");
        columnShafts = GenericUtils.loadAllPrefabs("prefabs/columns/shaft");
        columnCapitals = GenericUtils.loadAllPrefabs("prefabs/columns/capital");
        arches = GenericUtils.loadAllPrefabs("prefabs/arches/composite");
        simpleArches = GenericUtils.loadAllPrefabs("prefabs/arches/simple");
        data = true;
    }

    public GameObject getColumnBase(){
        getData();
		return columnBases[Random.Range(0,columnBases.Length)];
	}

	public GameObject getColumnShaft(){
        getData();
        return columnShafts[Random.Range(0,columnShafts.Length)];
	}

	public GameObject getColumnCapital(){
        getData();
        return columnCapitals [Random.Range (0, columnCapitals.Length)];
	}

	public GameObject getArch(){
        getData();
        return arches[Random.Range(0,arches.Length)];
	}

	public GameObject getSimpleArch(){
        getData();
        return simpleArches[Random.Range(0,simpleArches.Length)];
	}
}

