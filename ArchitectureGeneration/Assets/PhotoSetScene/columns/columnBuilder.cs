using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnBuilder : MonoBehaviour {

	public GameObject bottom;
	public GameObject shaft;
	public GameObject top;

	float baseHeight = 0.25f;
	float baseWidth = 0.3f;
	float shaftWidth = 0.2f;

	void Start () {
		

	}

	public void build(){
		GameObject go;
		go = Instantiate (bottom, transform.position + Vector3.down*0.03f, transform.rotation, transform);
		go.transform.localScale = new Vector3 (baseWidth, baseHeight, baseWidth);
		go = Instantiate (shaft, transform.position  + Vector3.up*0.75f*transform.localScale.x, transform.rotation, transform);
		go.transform.localScale = new Vector3 (shaftWidth, 1.5f, shaftWidth);
		go = Instantiate (top, transform.position + Vector3.up * 1.53f*transform.localScale.x, transform.rotation, transform);
		go.transform.localScale = new Vector3 (baseWidth, baseHeight, baseWidth);
	}


}
