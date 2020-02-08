using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPuzzle : MonoBehaviour {

	//for player to activate switch
	public KeyCode keyToActivate;
	public bool switchFlipped;

	//to give switch on/off state
	private bool switchPoweredOn = true;

	//materials to show on/off stages of switch object
	public Renderer powerLight;
	public Renderer noPowerLight;
	public Material powerLightOn;
	public Material noPowerLightOn;
	public Material lightOff;

	//lights this switch controls
	public GameObject camera1;
	public GameObject camera2;

	//resetting switches from checkpoints
	public GameObject checkpoint;
	public bool switchHasReset = false;

	void Update () {

		//if switch is off, orange light, otherwise green light
		if (switchPoweredOn == false) {
			powerLight.material = lightOff;
			noPowerLight.material = noPowerLightOn;
		} else {
			powerLight.material = powerLightOn;
			noPowerLight.material = lightOff;
		}
	
		//when switch is flipped, do the thing
		if (switchFlipped) {
			SwitchFlip ();
			switchFlipped = false;
		}

		//if switch resets, starting state
		switchHasReset = checkpoint.GetComponent<Checkpoint>().resetPuzzle;

		if (switchHasReset == true) {
			print ("Puzzle switches have reset.");
			switchPoweredOn = true;
			switchHasReset = false;
		}

	}

	//allow player to use switch if player is near switch
	void OnTriggerStay (Collider playerCollider) {
		if (playerCollider.gameObject.tag == "Player") {
			if (Input.GetKeyDown (keyToActivate)) {
				switchFlipped = true;
			}
		}
	}

	//what happens when switch is flipped
	void SwitchFlip () {
		
		switchPoweredOn = !switchPoweredOn;

		if (camera1 != null) {
			camera1.SetActive (!camera1.activeSelf);
		}
		if (camera2 != null) {
			camera2.SetActive (!camera2.activeSelf);
		}
	}

}
