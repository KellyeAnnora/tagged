using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffButton : MonoBehaviour {

	public Light cameraLight;

// This is what I had done to make the camera disable when I pressed "x".
//	void Update () {
//		if (Input.GetButtonDown("Action2")) {
//			DisableCamera ();
//		}
//	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("CamPowerControl")) {
			cameraLight.enabled = false;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag("CamPowerControl")) {
			cameraLight.enabled = true;
		}
	}
}
