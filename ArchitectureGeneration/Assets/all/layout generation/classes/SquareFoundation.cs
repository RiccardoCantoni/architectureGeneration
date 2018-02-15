using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareFoundation : BuildingFoundation {

	public SquareFoundation(Vector3[] corners, Vector3 center, int l){
		this.corners = corners;
		this.lengthX = l;
		this.lengthZ = l;
		this.center = center;
		myCube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		myCube.tag = "temp";
		myCube.transform.position = center;
		myCube.transform.rotation = Quaternion.identity;
		myCube.transform.localScale = new Vector3 (lengthX,1f,lengthZ);
	}

	public bool isConsistent(int minL, int maxL){
		if (this.lengthX < minL)
			return false;

		if (this.lengthX > maxL)
			return false;

		if (this.lengthZ < minL)
			return false;

		if (this.lengthZ > maxL)
			return false;
		return true;
	}
}
