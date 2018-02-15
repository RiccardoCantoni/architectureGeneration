using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge{
		
	public Vector3[] endpoints;
	public Vector3 axisDirection;
	public BuildingFoundation foundation;

	public Edge(Vector3[] endpoints, Vector3 axisDirection, BuildingFoundation foundation){
		this.endpoints = endpoints;
		this.axisDirection = axisDirection;
		this.foundation = foundation;
	}

	public int length(){
		return (int)((endpoints[0]-endpoints[1]).magnitude);
	}

	public Vector3 getMidpoint(){
		return (endpoints [0] + endpoints [1]) / 2f;
	}

}
