using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uberMain : MonoBehaviour {

	public float loopTime;
	public bool takeScreenshots;

	void Start () {
		StartCoroutine (megaLoop ());
	}

	IEnumerator megaLoop(){
		yield return new WaitForSeconds (loopTime);
		if (takeScreenshots) {
			string s1 = Random.value.ToString ();
			string s2 = Random.value.ToString ();
			string s3 = Random.value.ToString ();
			ScreenCapture.CaptureScreenshot ("screenshots/"+s1 + s2 + s3 + ".png");
		}
		SceneManager.LoadSceneAsync (0);
	}
}
