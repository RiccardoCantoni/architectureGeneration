using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize > 1) { //zoom in
			Camera.main.orthographicSize--;
		}else if (Input.GetAxis ("Mouse ScrollWheel") < 0){
			Camera.main.orthographicSize++;
		}

		if (Input.GetKey(KeyCode.LeftShift)){
			transform.RotateAround(transform.position, Vector3.up, Input.GetAxis ("Horizontal")*3);
		}else{
			Camera.main.gameObject.transform.position += Camera.main.gameObject.transform.right*Input.GetAxis ("Horizontal");
			Camera.main.gameObject.transform.position += Camera.main.gameObject.transform.up*Input.GetAxis ("Vertical");
		}
	}
}
