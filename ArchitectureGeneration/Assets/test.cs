using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	void Start () {
        GameObject[] objects = GenericUtils.loadAllPrefabs("generic");
        foreach (GameObject go in objects)
        {
            Debug.Log(go.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
