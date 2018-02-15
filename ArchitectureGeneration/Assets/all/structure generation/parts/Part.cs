using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour {

	protected GameObject myInstantiate(GameObject o, Vector3 pos, float dimXZ, float dimY){
		GameObject newObj = Instantiate (o, pos, transform.rotation);
		newObj.transform.parent = transform;
		newObj.transform.localScale = new Vector3 (dimXZ, dimY, dimXZ);
		return newObj;
	}

	protected GameObject myInstantiateExtended(GameObject o, Vector3 pos, float dimX, float dimY, float dimZ){
		GameObject newObj = Instantiate (o, pos, transform.rotation);
		newObj.transform.parent = transform;
		newObj.transform.localScale = new Vector3 (dimX, dimY, dimZ);
		return newObj;
	}

	protected GameObject placePart(GameObject part, Vector3 pos){ 
		GameObject obj = Instantiate (part, pos, transform.rotation);
		obj.transform.parent = transform;
		return obj;
	}
}
