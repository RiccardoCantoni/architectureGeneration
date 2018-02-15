using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junction{

	public Vector3 position;
	public Vector3 axis;
	public int height;
	public BuildingFoundation[] adjacentFoundations = new BuildingFoundation[2];

	public Junction(Vector3 pos, Vector3 axis){
		position = pos;
		this.axis = axis;
		height = 0;
	}

	public void updateHeight(){
		//
	}


		
}
