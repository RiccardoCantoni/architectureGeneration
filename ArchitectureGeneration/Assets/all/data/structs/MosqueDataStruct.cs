using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MosqueDataStruct {

	public int size;
	public float collarDiameter;
	public List<int> collarSequence;
	public float collarHeight;
	public int totalHeight;
	public int baseHeight;
	public List<int> decorSequence;

	public GameObject mosqueBasePart;
	public GameObject mosqueBodyPart;
	public GameObject fullCollarPart;
	public GameObject archCollarPart;
	public GameObject topPart;
	public GameObject decorPart;

	public GameObject mosqueBodyPrefab;
	public GameObject fullCollarPrefab;
	public GameObject archPrefab;
	public GameObject topPrefab;
	public GameObject decorPrefab;

}
