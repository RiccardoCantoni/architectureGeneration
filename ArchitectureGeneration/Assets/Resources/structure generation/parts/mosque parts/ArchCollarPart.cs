using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchCollarPart : MosquePart {

	public GameObject cylinderBlack;

	List<Vector3> mountPoints;

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
        cylinderBlack = GenericUtils.loadPrefab("generic", "cylinderBlack");
		mountPoints = calculateMountpoints (transform.position, data.collarDiameter / 2f);
		Vector3 p1, p2;
		GameObject newArch;
		for (int i = 0; i < mountPoints.Count; i++) {
			p1 = mountPoints [i];
			if (i == mountPoints.Count - 1) {
				p2 = mountPoints[0];
			}else{
				p2 = mountPoints[i+1];
			}
			newArch = myInstantiate (data.archPrefab, (p1 + p2) / 2f, Vector3.Distance (p1, p2), data.collarHeight, 0.3f);
			newArch.transform.LookAt(transform.position);
		}
		myInstantiate (cylinderBlack, transform.position, data.collarDiameter - 0.4f, data.collarHeight);
	}

	List<Vector3> calculateMountpoints(Vector3 center, float radius){
		int pointNumber = (int)(radius*2*Mathf.PI);
		float angleDelta = 360f / (float)pointNumber;
		List<Vector3> res = new List<Vector3>();
		Vector3 dir = Vector3.forward;
		for (int i = 0; i < pointNumber; i++) {
			dir = Quaternion.Euler (0, angleDelta, 0) * dir;			
			res.Add (center + dir * (radius-0.2f));
		}
		return res;
	}



}
