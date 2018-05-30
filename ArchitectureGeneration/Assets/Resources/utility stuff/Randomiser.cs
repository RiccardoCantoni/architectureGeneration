using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomiser{

	public static int intBetween(int min, int max){
		return Random.Range (min, max + 1);
	}

	public static int clampInRange(int value, int lowerBound, int upperBound){
		if (value < lowerBound) {
			return lowerBound;
		}else if (value > upperBound) {
			return upperBound;
		}
		return value;
	}

	public static Vector3 pointOnEdge(Edge edge){
		Vector3 midpoint = (edge.endpoints [0] + edge.endpoints [1]) / 2;
		int maxDisplacement = edge.length() / 3;
		Vector3 displacementAxis = GenericUtils.rotateClockwise (edge.axisDirection);
		float displacement = Randomiser.intBetween (maxDisplacement*-1, maxDisplacement);
		return midpoint + displacement * displacementAxis;
	}
		
	public static int measureDistance(Vector3 point, Vector3 direction, int maxDistance){
		direction.Normalize ();
		RaycastHit hit;
		if (Physics.Raycast(point, direction, out hit, maxDistance)){
			return (int)(hit.distance);
		}
		return maxDistance;
	}

	public static bool rollUnder(int chance){
		int roll = intBetween (1, 100);
		if (roll <= chance) {
			return true;
		}
		return false;
	}

	public static int intBetweenEven(int min, int max){
		int res = intBetween (min, max);
		if (res % 2 == 0)
			return res;
		return res+1;
	}

	public static float oneOf(float x, float y){
		if (Randomiser.rollUnder(50)) return x;
		return y;
	}

}
