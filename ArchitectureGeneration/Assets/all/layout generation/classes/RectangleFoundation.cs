using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleFoundation : BuildingFoundation{

	public RectangleFoundation(Vector3[] corners, Vector3 center, int lX, int lZ){
		this.corners = corners;
		this.lengthX = lX;
		this.lengthZ = lZ;
		this.center = center;
		myCube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		myCube.tag = "temp";
		myCube.transform.position = center;
		myCube.transform.rotation = Quaternion.identity;
		myCube.transform.localScale = new Vector3 (lengthX,1f,lengthZ);
	}
		
	public bool isConsistent(int minL, int maxL, float minR, float maxR){
		if (this.lengthX < minL)
			return false;
		
		if (this.lengthX > maxL)
			return false;
		
		if (this.lengthZ < minL)
			return false;
		
		if (this.lengthZ > maxL)
			return false;
		
		if ((this.lengthX / (float)this.lengthZ) < minR)
			return false;

		if ((this.lengthX / (float)this.lengthZ) > maxR)
			return false;

		return true;
	}
		
}
