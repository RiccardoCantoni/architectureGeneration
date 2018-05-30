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
		placePart <ColumnLayerPart> ("columnLayer", transform.position);
		placePart <ArchLayerPart> ("archLayer", transform.position);
		placePart <CornersPart> ("corners", transform.position);
		}
}
