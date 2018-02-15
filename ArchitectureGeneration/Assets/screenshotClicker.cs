using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenshotClicker : MonoBehaviour {


	void Update () {
		if (Input.GetMouseButtonDown(0)){
			ScreenCapture.CaptureScreenshot("screenshot.png");
			print("click");
		}
	}
}
