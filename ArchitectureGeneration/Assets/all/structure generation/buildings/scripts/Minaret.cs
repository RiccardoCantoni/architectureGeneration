using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minaret : Building {

	MinaretDataStruct data;

	protected override void build(){
		GameObject dataholder = GameObject.Find ("DataHolder");
		data = dataholder.GetComponent<MinaretData> ().getDataStruct ();
		placePart (data.basePart, foundation.center);
		placePart (data.shaftPart, foundation.center);
		for (int i = 0; i < data.ringNumber; i++) {
			placePart (data.ringPart, foundation.center + Vector3.up * (data.shaftHeight-i*(((data.shaftHeight/2f)/(float)data.ringNumber))));
		}
		placePart (data.galleryPart, foundation.center + Vector3.up * data.shaftHeight);
		placePart (data.topPart, foundation.center + Vector3.up*(data.shaftHeight+data.galleryHeight));
	}

}
