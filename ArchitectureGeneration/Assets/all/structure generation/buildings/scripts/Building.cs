using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	public BuildingFoundation foundation;
	public float buildDelay;
	public int buildingHeight;

	public void go () {
		StartCoroutine (buildCoroutine (0.3f+Random.value*0.7f));
	}
	
	IEnumerator buildCoroutine(float timer){
		yield return new WaitForSeconds(timer);
		build();
	}

	virtual protected void build(){
	}

	protected void placePart(GameObject part, Vector3 pos){ 
		GameObject obj = Instantiate (part, pos, Quaternion.identity);
		obj.transform.parent = transform;
	}		
}
