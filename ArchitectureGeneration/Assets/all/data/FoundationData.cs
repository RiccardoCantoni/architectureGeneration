using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationData : MonoBehaviour{

	public List<BuildingFoundation> rectangles = new List<BuildingFoundation> ();
	public List<BuildingFoundation> squares = new List<BuildingFoundation> ();
	public List<BuildingFoundation> minarets = new List<BuildingFoundation> ();
	public List<Junction> 	junctions = new List<Junction> ();
	public List<Edge> freeEdges = new List<Edge> ();
	public List<Edge> usedEdges = new List<Edge> ();
	public List<Vector3> allCorners = new List<Vector3> ();
	public List<Vector3> freeCorners = new List<Vector3> ();

	public void receiveData(FoundationGenerator source){
		rectangles = source.rectangles;
		squares = source.squares;
		minarets = source.minarets;
		junctions = source.junctions;
		freeEdges = source.freeEdges;
		usedEdges = source.usedEdges;
		allCorners = source.allCorners;
		freeCorners = source.freeCorners;
	}

}

