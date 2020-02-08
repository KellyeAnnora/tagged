using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour {

	//says whether the switch is "on"
	private bool switchPoweredOn = true;

	//confirms player is close enough to button
	private bool playerInRange = false;

	//for player to activate switch
	public KeyCode keyToActivate;
	public bool switchFlipped;

	//lights on this switch and their on and off states
	public Renderer powerLight;
	public Renderer noPowerLight;
	public Material powerLightOn;
	public Material noPowerLightOn;
	public Material lightOff;

	//lasers we're controlling
	public GameObject laser1;
	public GameObject laser2;
	public GameObject laser3;
	public GameObject laser4;

	//resetting switch from checkpoint
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

		//what happens when switch is flipped
		if (switchFlipped == true) {

			switchPoweredOn = false;

			if (laser1 != null) {
				laser1.GetComponent<LineRenderer>().enabled = false;
				laser1.GetComponent<CapsuleCollider>().enabled = false;
			}

			if (laser2 != null) {
				laser2.GetComponent<LineRenderer> ().enabled = false;
				laser2.GetComponent<CapsuleCollider>().enabled = false;
			}

			if (laser3 != null) {
				laser3.GetComponent<LineRenderer> ().enabled = false;
				laser3.GetComponent<CapsuleCollider>().enabled = false;
			}

			if (laser4 != null) {
				laser4.GetComponent<LineRenderer> ().enabled = false;
				laser4.GetComponent<CapsuleCollider> ().enabled = false;
			}

		} else {

			switchPoweredOn = true;

			if (laser1 != null) {
				laser1.GetComponent<LineRenderer>().enabled = true;
				laser1.GetComponent<CapsuleCollider>().enabled = true;
			}

			if (laser2 != null) {
				laser2.GetComponent<LineRenderer> ().enabled = true;
				laser2.GetComponent<CapsuleCollider>().enabled = true;
			}

			if (laser3 != null) {
				laser3.GetComponent<LineRenderer> ().enabled = true;
				laser3.GetComponent<CapsuleCollider>().enabled = true;
			}

			if (laser4 != null) {
				laser4.GetComponent<LineRenderer> ().enabled = true;
				laser4.GetComponent<CapsuleCollider> ().enabled = true;
			}
		}

		//reset
		switchHasReset = checkpoint.GetComponent<Checkpoint> ().resetPuzzle;

		if (switchHasReset == true) {
			print ("Laser switches have reset.");
			switchPoweredOn = true;
			switchFlipped = false;
			switchHasReset = false;
		}

	}

	//nearby player can flip switch
	void OnTriggerStay (Collider playerCollider) {

		if (playerCollider.gameObject.tag == "Player") {

			//if key is pressed, switch turns on and off
			if (Input.GetKeyDown (keyToActivate)) {
				switchPoweredOn = !switchPoweredOn;
				switchFlipped = true;
			}			
		}
	}

}
