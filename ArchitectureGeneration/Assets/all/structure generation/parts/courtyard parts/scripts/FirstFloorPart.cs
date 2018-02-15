using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorPart : CourtyardPart {

	public GameObject columnLayerPart;
	public GameObject archLayerPart;
	public GameObject cornersPart;
	public GameObject roofPrefab;

	void Start(){
		initData ();
		placePart (columnLayerPart, transform.position);
		placePart (archLayerPart, transform.position);
		placePart (cornersPart, transform.position);
		}
}
