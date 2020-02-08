using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraPuzzle : MonoBehaviour {

	public bool switchPoweredOn = true;

	public KeyCode keyToActivate;

	//hooking up the lights on this switch and their on and off states
	public Renderer powerLight;
	public Renderer noPowerLight;
	public Material powerLightOn;
	public Material noPowerLightOn;
	public Material lightOff;

	//hooking up the lights on the cameras that we're controlling
	public GameObject camBeam1;
	public GameObject camBeam2;

	void Update () {

		//if switch is off, orange light, otherwise green light
		if (switchPoweredOn == false) {
			powerLight.material = lightOff;
			noPowerLight.material = noPowerLightOn;
		} else {
			powerLight.material = powerLightOn;
			noPowerLight.material = lightOff;
		}

		//if key is pressed, switch turns on and off
		if (Input.GetKey (keyToActivate)) {
			switchPoweredOn = !switchPoweredOn;
			camBeam1.SetActive (!camBeam1.activeSelf);
			camBeam2.SetActive (!camBeam2.activeSelf);
		}
	}
}
