using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquePart : Part {

	protected MosqueDataStruct data;

	protected void initData(){
		data = transform.root.GetComponent<Mosque> ().data;
	}
}
