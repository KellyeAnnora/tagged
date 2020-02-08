using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSingleCamera : MonoBehaviour {

	//bool to say whether the switch is "on"
	private bool switchPoweredOn = true;

	//bool to confirm player is close enough to button
	private bool playerInRange = false;

	//dropdown to select the key that turns the switch on and off
	public KeyCode keyToActivate;

	//hooking up the lights on this switch and their on and off states
	public Renderer powerLight;
	public Renderer noPowerLight;
	public Material powerLightOn;
	public Material noPowerLightOn;
	public Material lightOff;

	//hooking up the lights on the camera that we're controlling
	public GameObject camera;

	//resetting switches from checkpoints
	public GameObject checkpoint;
	public bool switchHasReset;

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
		if (switchPoweredOn == false) {
			camera.SetActive (false);
		} else {
			camera.SetActive (true);
		}

		//checks if player is in range, allows player to turn switch on and off
		if (playerInRange && Input.GetKeyDown (keyToActivate)) {
			switchPoweredOn = !switchPoweredOn;
		}

		//state to return to when reset from checkpoint
		switchHasReset = checkpoint.GetComponent<Checkpoint>().resetPuzzle;

		if (switchHasReset == true) {
			print ("Single camera switches have reset.");
			switchPoweredOn = true;
			switchHasReset = false;
		}

	}

	//determines when player is in range
	void OnTriggerEnter (Collider playerCollider) {
		if (playerCollider.gameObject.tag == "Player") {
			print ("Player is in range of camera switch.");
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider playerCollider) {
		print ("Player has left camera switch range.");
		playerInRange = false;
	}
		
}
