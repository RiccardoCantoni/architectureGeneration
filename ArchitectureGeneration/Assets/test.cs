using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	void Start () {
        GameObject o = GenericUtils.loadPrefab("generic","floorPrefab");
        Instantiate(o);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
