using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLaserRotator : MonoBehaviour {

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
	public GameObject firstLaser;
	public GameObject secondLaser;
	public GameObject thirdLaser;
	public GameObject fourthLaser;
	private bool powerGridOn = true;

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
		if (powerGridOn == false) {
			firstLaser.GetComponent<LineRenderer>().enabled = false;
			secondLaser.GetComponent<LineRenderer>().enabled = false;
			thirdLaser.GetComponent<LineRenderer>().enabled = false;
			fourthLaser.GetComponent<LineRenderer>().enabled = false;
			firstLaser.GetComponent<CapsuleCollider>().enabled = false;
			secondLaser.GetComponent<CapsuleCollider>().enabled = false;
			thirdLaser.GetComponent<CapsuleCollider>().enabled = false;
			fourthLaser.GetComponent<CapsuleCollider>().enabled = false;
		} else {
			firstLaser.GetComponent<LineRenderer>().enabled = true;
			secondLaser.GetComponent<LineRenderer>().enabled = true;
			thirdLaser.GetComponent<LineRenderer>().enabled = true;
			fourthLaser.GetComponent<LineRenderer>().enabled = true;
			firstLaser.GetComponent<CapsuleCollider>().enabled = true;
			secondLaser.GetComponent<CapsuleCollider>().enabled = true;
			thirdLaser.GetComponent<CapsuleCollider>().enabled = true;
			fourthLaser.GetComponent<CapsuleCollider>().enabled = true;
		}
	}

	//only allow player to use switch if player is near switch
	void OnTriggerStay (Collider playerCollider) {

		if (playerCollider.gameObject.tag == "Player") {

			//if key is pressed, switch turns on and off
			if (Input.GetKey (keyToActivate)) {
				switchPoweredOn = !switchPoweredOn;
				powerGridOn = !powerGridOn;

			}			
		}
	}

}
