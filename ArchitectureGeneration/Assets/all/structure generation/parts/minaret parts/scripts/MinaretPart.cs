using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaretPart : Part {

	protected MinaretDataStruct data;

	protected void initData(){
		data = GameObject.Find ("DataHolder").GetComponent<MinaretData> ().getDataStruct ();
	}
}
