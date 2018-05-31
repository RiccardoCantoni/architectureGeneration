using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MinaretDataStruct {

	public float baseWidth;
	public float baseHeight;
	public float shaftHeight;
	public float shaftWidth;
	public int ringNumber;
	public float ringWidth;
	public float ringHeight;
	public float galleryWidth;
	public float galleryHeight;
	public float topWidth;
	public float topHeight;
	public float decorHeight;
	public float decorWidth;
	public List<int> decorSequence;

	public GameObject basePrefab;
	public GameObject shaftPrefab;
	public GameObject ringPrefab;
	public GameObject galleryPrefab;
	public GameObject topPrefab;
	public GameObject decorPrefab;

	public GameObject columnBase;
	public GameObject columnShaft;
	public GameObject columnCapital;
	public GameObject arch;

}
