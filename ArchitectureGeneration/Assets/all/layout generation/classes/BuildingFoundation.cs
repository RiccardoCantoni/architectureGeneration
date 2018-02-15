using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFoundation {

	public Vector3[] corners;
	public Vector3 center;
	public int lengthX;
	public int lengthZ;
	public List<Junction> junctions = new List<Junction> ();
	protected GameObject myCube;

	public void delete(){
		MonoBehaviour.Destroy (myCube);
	}

	public List<Edge> getEdges(){
		List<Edge> edges = new List<Edge> ();
		Vector3[] endpoints = new Vector3[2];
		endpoints [0] = corners [0];
		endpoints [1] = corners [1];
		edges.Add(new Edge (endpoints, getAxisFromEndpoints(endpoints), this));
		endpoints = new Vector3[2];
		endpoints [0] = corners [1];
		endpoints [1] = corners [2];
		edges.Add(new Edge (endpoints, getAxisFromEndpoints(endpoints), this));
		endpoints = new Vector3[2];
		endpoints [0] = corners [2];
		endpoints [1] = corners [3];
		edges.Add(new Edge (endpoints, getAxisFromEndpoints(endpoints), this));
		endpoints = new Vector3[2];
		endpoints [0] = corners [3];
		endpoints [1] = corners [0];
		edges.Add(new Edge (endpoints, getAxisFromEndpoints(endpoints), this));
		return edges;
	}

	private Vector3 getAxisFromEndpoints(Vector3[] endpoints){
		return Vector3.Normalize (((endpoints [0] + endpoints [1]) / 2f) - center);
	}

	public bool containsPoint(Vector3 point){
		return (Raycaster.inGameObject (point, myCube));
	}
		
}
