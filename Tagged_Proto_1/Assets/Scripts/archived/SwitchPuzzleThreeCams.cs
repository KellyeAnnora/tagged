using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzleThreeCams : MonoBehaviour {

	public bool switchWasFlipped;

	private bool switchPoweredOn = true;

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
	public GameObject camBeam3;

	//resetting switches from checkpoints
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

		//if switch resets, starting state
		if (switchHasReset == true) {
			print ("Switch has reset.");
			switchPoweredOn = true;
			camBeam1.SetActive (true);
			camBeam2.SetActive (true);
			camBeam3.SetActive (true);
		}

		//when switch is Flipped, play the change sequence
		if (switchWasFlipped) {
			SwitchChange ();
			switchWasFlipped = false;
		}
			
	}

	//only allow player to use switch if player is near switch
	void OnTriggerStay (Collider playerCollider) {
		if (playerCollider.gameObject.tag == "Player") {

			//if key is pressed, switch turns on and off/cameras turn on and off
			if (Input.GetKeyDown (keyToActivate)) {
				switchWasFlipped = true;
			}
		}
	}

	//when switch is flipped, on state switches and beam states switch
	void SwitchChange () {
		switchPoweredOn = !switchPoweredOn;
		camBeam1.SetActive (!camBeam1.activeSelf);
		camBeam2.SetActive (!camBeam2.activeSelf);
		camBeam3.SetActive (!camBeam3.activeSelf);
	}

}
