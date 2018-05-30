using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornersPart : CourtyardPart {

	public GameObject cornerPrefab;

	void Start () {
		initData ();
        cornerPrefab = GenericUtils.loadPrefab("generic", "cornerPrefab");
		Vector3 pos;
		GameObject corner;
		pos = transform.position + (Vector3.forward * data.sizeZ / 2f) + (Vector3.left * data.sizeX / 2f);
		corner = myInstantiate(cornerPrefab, pos, 1, 1);
		corner.transform.LookAt(corner.transform.position+ Vector3.right);
		pos = transform.position + (Vector3.forward * data.sizeZ / 2f) + (Vector3.right * data.sizeX / 2f);
		corner = myInstantiate(cornerPrefab, pos, 1, 1);
		corner.transform.LookAt(corner.transform.position+ Vector3.back);
		pos = transform.position + (Vector3.back * data.sizeZ / 2f) + (Vector3.right * data.sizeX / 2f);
		corner = myInstantiate(cornerPrefab, pos, 1, 1);
		corner.transform.LookAt(corner.transform.position+ Vector3.left);
		pos = transform.position + (Vector3.back * data.sizeZ / 2f) + (Vector3.left * data.sizeX / 2f);
		corner = myInstantiate(cornerPrefab, pos, 1, 1);
		corner.transform.LookAt(corner.transform.position+ Vector3.forward);
	}
	

}
