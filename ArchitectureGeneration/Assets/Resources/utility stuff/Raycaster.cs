using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Raycaster {

	public static bool notInAnything(Vector3 point){
		if (Physics.CheckSphere(point, 1.2f)){
			return false;
		}
		return true;
	}

	public static bool inGameObject(Vector3 point, GameObject self){
		RaycastHit hit;
		if (Physics.Raycast(point+Vector3.up*2, Vector3.down, out hit, 5f)){
			return (hit.transform.gameObject.GetInstanceID() == self.GetInstanceID());
		}
		return false;
	}

	public static bool isFreeCorner(Vector3 point, int maxCornerSize){	
		Collider[] hitColliders = Physics.OverlapSphere(point, maxCornerSize);
		if (hitColliders.Length > 1) {
			return false;
		}
		return true;
	}

	public static List<Vector3> sortByDistance(List<Vector3> unsorted, Vector3 point){
		IEnumerable<Vector3> sortAscendingQuery =
			from pos in unsorted
			orderby ((pos-point).sqrMagnitude) ascending
			select pos;
		List<Vector3> sorted = new List<Vector3>();
		foreach (Vector3 p in sortAscendingQuery) {
			sorted.Add(p);
		}
		return sorted;
	}

	public static float highestPoint(Vector3 pos, float maxheight){
		RaycastHit hit;
		if (Physics.Raycast (pos + maxheight*Vector3.up, Vector3.down, out hit, maxheight)) {
			return hit.point.y;
		}
		return 0;
	}

	public static bool stepClear(Vector3 start, Vector3 stepDir){
		
		if (Physics.Raycast (start + Vector3.up, stepDir, 1.2f)) {
			return false;
		}
		return true;
	}
}
