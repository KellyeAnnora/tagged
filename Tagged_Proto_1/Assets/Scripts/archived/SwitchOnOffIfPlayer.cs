using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOffIfPlayer : MonoBehaviour {

	//bool to say whether the switch is "on"
	public bool switchPoweredOn = true;

	//dropdown to select the key that turns the switch on and off
	public KeyCode keyToActivate;

	//hooking up the lights on this switch and their on and off states
	public Renderer powerLight;
	public Renderer noPowerLight;
	public Material powerLightOn;
	public Material noPowerLightOn;
	public Material lightOff;

	//hooking up the lights on the camera that we're controlling
	public GameObject poweredCameraBeam;

	private bool powerGridOn = true;

	//bool to display GUI, set message
	private bool showPlayerHint = false;
	public string playerHint;

	void Update () {

		//if switch is off, orange light, otherwise green light
		if (switchPoweredOn == false) {
			powerLight.material = lightOff;
			noPowerLight.material = noPowerLightOn;
		} else {
			powerLight.material = powerLightOn;
			noPowerLight.material = lightOff;
		}

		//if switch is off, camera turns off, otherwise camera is on
		if (powerGridOn == false) {
			poweredCameraBeam.SetActive (false);
		} else {
			poweredCameraBeam.SetActive (true);
		}
	}

	//only allow player to use switch if player is near switch
	void OnTriggerStay (Collider playerCollider) {
		if (playerCollider.gameObject.tag == "Player") {

//			//use this debug in case not sure that collider is picking up player
//			print ("Player is within range.");

			//allows message to be displayed to player
			showPlayerHint = true;

			//if key is pressed, switch turns on and off
			if (Input.GetKey (keyToActivate)) {
				switchPoweredOn = !switchPoweredOn;
				powerGridOn = !powerGridOn;

			}			
		}
	}

	//displays message to player
	void OnGUI () {

		if (showPlayerHint) {
			GUI.Label (new Rect (100, 300, Screen.width/2, Screen.height/2), playerHint);
		}
	}

	//stop showing message when Player is out of range
	void OnTriggerExit () {
		showPlayerHint = false;
	}
}
