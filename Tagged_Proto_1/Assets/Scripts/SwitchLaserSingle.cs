using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLaserSingle : MonoBehaviour {

	//bool to say whether the switch is "on"
	public bool switchPoweredOn = true;

	//dropdown to select the key that turns the switch on and off
	public KeyCode keyToActivate;

	//hooking up the lights on this switch and their on and off materials
	public MeshRenderer powerLight;
	public MeshRenderer noPowerLight;
	public Material powerLightOn;
	public Material noPowerLightOn;
	public Material lightOff;

	//hooking up the lasers we're controlling
	public GameObject laser;

	void Update () {

		//if switch is off, orange light, otherwise green light
		if (switchPoweredOn == false) {
			powerLight.material = lightOff;
			noPowerLight.material = noPowerLightOn;
		} else {
			powerLight.material = powerLightOn;
			noPowerLight.material = lightOff;
		}

		//if switch is off, lasers turn off, otherwise lasers are on
		if (switchPoweredOn == false) {
			laser.GetComponent<LineRenderer>().enabled = false;
			laser.GetComponent<CapsuleCollider> ().enabled = false;
		} else {
			laser.GetComponent<LineRenderer>().enabled = true;
			laser.GetComponent<CapsuleCollider> ().enabled = true;
		}
	}

	//only allow player to use switch if player is near switch
	void OnTriggerStay (Collider playerCollider) {

		if (playerCollider.gameObject.tag == "Player") {

			//if key is pressed, switch turns on and off
			if (Input.GetKeyDown (keyToActivate)) {
				switchPoweredOn = false;
			}			
		}
	}

}
