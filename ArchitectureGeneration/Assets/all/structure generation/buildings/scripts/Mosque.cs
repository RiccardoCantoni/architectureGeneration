﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosque : Building {

	public MosqueDataStruct data;
	
	protected override void build (){
		GameObject dataholder = GameObject.Find ("DataHolder");
		data = dataholder.GetComponent<MosqueData> ().getDataStruct (foundation);
		placePart (data.mosqueBasePart, foundation.center);
		placePart (data.mosqueBodyPart, foundation.center);
		int cval;
		for (int i = 0; i < data.collarSequence.Count; i++) {
			cval = data.collarSequence [i];
			if (cval > 0) {
				placePart (data.archCollarPart, foundation.center + (data.size + i * data.collarHeight) * Vector3.up);
			} else {
				placePart (data.fullCollarPart, foundation.center + (data.size + i * data.collarHeight) * Vector3.up);
			}
		}
		placePart (data.topPart, foundation.center + Vector3.up * (data.size + data.collarSequence.Count * data.collarHeight));
	}
}
