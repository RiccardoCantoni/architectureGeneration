using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaretData : MonoBehaviour{

	private MinaretDataStruct dataStruct;
    bool generated = false;

	public MinaretDataStruct getDataStruct(){
        if (generated)
		    return dataStruct;
        generateDataStruct();
        generated = true;
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

        GameObject[] basePrefabs = GenericUtils.loadAllPrefabs("prefabs/minaret/base_M");
        dataStruct.basePrefab = basePrefabs [Random.Range (0, basePrefabs.Length)];
        GameObject[] shaftPrefabs = GenericUtils.loadAllPrefabs("prefabs/minaret/shaft_M");
        dataStruct.shaftPrefab = shaftPrefabs [Random.Range (0, shaftPrefabs.Length)];
        GameObject[] ringPrefabs = GenericUtils.loadAllPrefabs("prefabs/minaret/ring_M");
        dataStruct.ringPrefab = ringPrefabs [Random.Range(0,ringPrefabs.Length)];
        GameObject[] galleryPrefabs = GenericUtils.loadAllPrefabs("prefabs/minaret/gallery_M");
        dataStruct.galleryPrefab = galleryPrefabs [Random.Range (0, galleryPrefabs.Length)];
        GameObject[] topPrefabs = GenericUtils.loadAllPrefabs("prefabs/minaret/top_M");
        dataStruct.topPrefab = topPrefabs [Random.Range (0, topPrefabs.Length)];
        GameObject[] decorPrefabs = GenericUtils.loadAllPrefabs("prefabs/minaret/decoration_M");
        dataStruct.decorPrefab = decorPrefabs [Random.Range (0, decorPrefabs.Length)];
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

