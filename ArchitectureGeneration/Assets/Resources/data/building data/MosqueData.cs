using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqueData : MonoBehaviour {

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
		dataStruct.mosqueBodyPrefab = mosqueBodyPrefabs[Random.Range (0,mosqueBodyPrefabs.Count)];
		dataStruct.fullCollarPrefab = fullCollarPrefab;
        GameObject[] arches = GenericUtils.loadAllPrefabs("prefabs/arches/simple");
		dataStruct.archPrefab = arches [Random.Range (0, arches.Length)];
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
