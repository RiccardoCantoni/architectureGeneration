using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minaret : Building {

	MinaretDataStruct data;

	protected override void build(){
		GameObject dataholder = GameObject.Find ("DataHolder");
		data = dataholder.GetComponent<MinaretData> ().getDataStruct ();
		placePart<BasePartM> ("base", foundation.center);
        placePart<ShaftPartM>("shaft", foundation.center);
		for (int i = 0; i < data.ringNumber; i++) {
			placePart <RingPartM>("ring", foundation.center + Vector3.up * (data.shaftHeight-i*(((data.shaftHeight/2f)/ data.ringNumber))));
		}
		placePart <GalleryPart>("gallery",foundation.center + Vector3.up * data.shaftHeight);
		placePart <TopPartM>("top", foundation.center + Vector3.up*(data.shaftHeight+data.galleryHeight));
	}

}
