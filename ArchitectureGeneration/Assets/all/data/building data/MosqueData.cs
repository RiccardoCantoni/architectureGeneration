using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqueData : MonoBehaviour {

	public GameObject mosqueBasePart;
	public GameObject mosqueBodyPart;
	public GameObject fullCollarPart;
	public GameObject archCollarPart;
	public GameObject topPart;
	public GameObject decorPart;

	public List<GameObject> mosqueBodyPrefabs;
	public GameObject fullCollarPrefab;
	public List<GameObject> topPrefabs;
	public GameObject decorPrefab;

	public MosqueDataStruct getDataStruct(BuildingFoundation foundation){
		MosqueDataStruct dataStruct = new MosqueDataStruct ();
		dataStruct.size = foundation.lengthX;
		dataStruct.collarDiameter = dataStruct.size * 0.9f;
		dataStruct.collarHeight = 1.5f;
		int collars = Randomiser.intBetween (0, 3);
		dataStruct.collarSequence = new List<int> ();
		for (int i = 0; i < collars; i++) {
			dataStruct.collarSequence.Add ((int)Randomiser.oneOf (0, 1.5f));  //0 -> full collar, 1 -> arch collar
		}
		dataStruct.baseHeight = 5;
		dataStruct.decorSequence = generateDecorSequence ();
		dataStruct.mosqueBasePart = mosqueBasePart;
		dataStruct.mosqueBodyPart = mosqueBodyPart;
		dataStruct.fullCollarPart = fullCollarPart;
		dataStruct.archCollarPart = archCollarPart;
		dataStruct.topPart = topPart;
		dataStruct.decorPart = decorPart;
		dataStruct.mosqueBodyPrefab = mosqueBodyPrefabs[Random.Range (0,mosqueBodyPrefabs.Count)];
		dataStruct.fullCollarPrefab = fullCollarPrefab;
		List<GameObject> arches = GameObject.Find ("DataHolder").GetComponent<ArchData> ().simpleArches;
		dataStruct.archPrefab = arches [Random.Range (0, arches.Count)];
		dataStruct.topPrefab = topPrefabs [Random.Range (0, topPrefabs.Count)];
		dataStruct.decorPrefab = decorPrefab;
		return dataStruct;
	}

	private List<int> generateDecorSequence(){
		List<int> res = new List<int> ();
		int itemCount = Randomiser.intBetween (1, 5);
		for (; itemCount>1; itemCount--) {
			res.Add (Randomiser.intBetween (2, 5));
		}
		res.Add (Randomiser.intBetween (4, 8));
		foreach (int i in res) {
		}
		return res;
	}
}
