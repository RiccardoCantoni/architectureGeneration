using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAnimator : MonoBehaviour {

    float distance;

    public static float totalDistance, velocity, animationTime;

	// Use this for initialization
	void Start () {
        velocity = 100;
        animationTime = 1;
        totalDistance = velocity * animationTime;
        distance = 0;
	}
	
	
	void Update () {
        float d = velocity * Time.deltaTime;
        distance += d;
        if (distance >= totalDistance) this.enabled = false;
        transform.position += Vector3.down * d;	
	}
}
