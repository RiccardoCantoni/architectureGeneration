using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqueBodyPart : MosquePart {

	void Start () {
		initData ();
		myInstantiate (data.mosqueBodyPrefab, transform.position, data.size, data.size);
	}

}
