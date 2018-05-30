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

	protected void placePart<T>(string name, Vector3 pos){
        GameObject obj = new GameObject(name);
        obj.AddComponent(typeof(T));
        obj.transform.position = pos;
		obj.transform.parent = transform;
	}		
}
