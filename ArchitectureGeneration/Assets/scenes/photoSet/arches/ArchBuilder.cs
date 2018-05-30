using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchBuilder : MonoBehaviour {

	public GameObject arch;
	public GameObject column;
	public GameObject col_base;
	public GameObject col_shaft;
	public GameObject col_cap;

	float baseHeight = 0.25f;
	float baseWidth = 0.3f;
	float shaftWidth = 0.2f;

	void Start () {
		GameObject go;
		go = Instantiate (column, transform.position + Vector3.left, transform.rotation, transform);
		columnBuilder cb = go.GetComponent<columnBuilder> ();
		cb.bottom = col_base;
		cb.shaft = col_shaft;
		cb.top = col_cap;
		cb.build ();
		go = Instantiate (column, transform.position + Vector3.right, transform.rotation, transform);
		cb = go.GetComponent<columnBuilder> ();
		cb.bottom = col_base;
		cb.shaft = col_shaft;
		cb.top = col_cap;
		cb.build ();
		go = Instantiate (arch, transform.position + Vector3.up * 3, transform.rotation, transform);
		go.transform.localScale = new Vector3 (2, 2, 0.6f);
	}
}
