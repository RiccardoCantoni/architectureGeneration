using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaretData : MonoBehaviour{

	public List<GameObject> basePrefabs;
	public List<GameObject> shaftPrefabs;
	public List<GameObject> ringPrefabs;
	public List<GameObject> galleryPrefabs;
	public List<GameObject> topPrefabs;
	public List<GameObject> decorPrefabs;

	private MinaretDataStruct dataStruct;

    void Start(){
		generateDataStruct ();
	}

	public MinaretDataStruct getDataStruct(){
		return dataStruct;
	}

	private void generateDataStruct(){
		dataStruct = new MinaretDataStruct ();
		dataStruct.baseWidth = 7;
		dataStruct.baseHeight = 3;
		dataStruct.shaftHeight = Randomiser.intBetween (25, 40);
		dataStruct.shaftWidth = 5;
		dataStruct.ringNumber = Randomiser.intBetween (1, 3);
		dataStruct.ringWidth = 6;
		dataStruct.ringHeight = 1.5f;
		dataStruct.galleryWidth = 4;
		dataStruct.galleryHeight = 3.5f;
		dataStruct.topWidth = dataStruct.galleryWidth;
		dataStruct.topHeight = dataStruct.galleryWidth;
		dataStruct.decorHeight = 1;
		dataStruct.decorWidth = 1;

		dataStruct.basePrefab = basePrefabs [Random.Range (0, basePrefabs.Count)];
		dataStruct.shaftPrefab = shaftPrefabs [Random.Range (0, shaftPrefabs.Count)];
		dataStruct.ringPrefab = ringPrefabs [Random.Range(0,ringPrefabs.Count)];
		dataStruct.galleryPrefab = galleryPrefabs [Random.Range (0, galleryPrefabs.Count)];
		dataStruct.topPrefab = topPrefabs [Random.Range (0, topPrefabs.Count)];
		dataStruct.decorPrefab = decorPrefabs [Random.Range (0, decorPrefabs.Count)];
		dataStruct.decorSequence = generateDecorSequence ();

		ArchData ad = gameObject.GetComponent<ArchData> ();
		dataStruct.columnBase = ad.getColumnBase ();
		dataStruct.columnShaft = ad.getColumnShaft ();
		dataStruct.columnCapital = ad.getColumnCapital ();
		dataStruct.arch = ad.getSimpleArch ();
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

