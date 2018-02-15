using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryPart : MinaretPart {

	public GameObject columnPart;
	public GameObject cylinderTop;
	public GameObject cylinderCenter;

	void Start () {
		initData ();
		List<Vector3> columnPoints = getMountpoints ();
		GameObject col;
		foreach (Vector3 p in columnPoints) {
			col = placePart (columnPart, p);
			col.transform.LookAt (transform.position);
		}
		Vector3 p1, p2;
		GameObject newArch;
		for (int i = 0; i < columnPoints.Count; i++) {
			p1 = columnPoints [i] + Vector3.up*2;
			if (i == columnPoints.Count - 1) {
				p2 = columnPoints[0] + Vector3.up*2;
			}else{
				p2 = columnPoints[i+1] + Vector3.up*2;
			}
			newArch = myInstantiateExtended (data.arch, (p1 + p2) / 2f, Vector3.Distance (p1, p2), 1.5f, 0.3f);
			newArch.transform.LookAt(transform.position + Vector3.up*2f);
		}
		myInstantiate (cylinderTop, transform.position + Vector3.up * 3.5f, 4, 0.2f);
		myInstantiate (cylinderCenter, transform.position, 2f, 3.5f);
	}

	private List<Vector3> getMountpoints(){
		List<Vector3> res = new List<Vector3> ();
		res = new List<Vector3> ();
		res.Add (transform.position + new Vector3 (-1.85f, 0, 0));
		res.Add (transform.position + new Vector3 (-1.3f, 0, 1.3f));
		res.Add (transform.position + new Vector3 (0, 0, 1.85f));
		res.Add (transform.position + new Vector3 (1.3f, 0, 1.3f));
		res.Add (transform.position + new Vector3 (1.85f, 0, 0));
		res.Add (transform.position + new Vector3 (1.3f, 0, -1.3f));
		res.Add (transform.position + new Vector3 (0, 0, -1.85f));
		res.Add (transform.position + new Vector3 (-1.3f, 0, -1.3f));
		return res;
	}
	

}
