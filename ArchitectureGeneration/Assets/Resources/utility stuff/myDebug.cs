using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myDebug {

	public static void drawEdges(List<Edge> edges, Color c){
		foreach (Edge e in edges) {
			Debug.DrawLine (e.endpoints [0] + Vector3.up*0.6f, e.endpoints [1] + Vector3.up*0.6f, c, 1000);
		}
	}

	public static void markWithSpheres(List<Vector3> pointList, float radius){
		foreach (Vector3 c in pointList) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.transform.position = c;
			sphere.transform.localScale = Vector3.one*radius;
		}
	}
}
