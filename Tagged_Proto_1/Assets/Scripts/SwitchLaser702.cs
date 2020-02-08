using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLaser702 : MonoBehaviour {

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

	//hooking up the laser and bot we're controlling
	public GameObject laser1;
	public GameObject laser2;
	public GameObject bot;

	void Update () {

		//if switch is off, orange light, otherwise green light
		if (switchPoweredOn == false) {
			powerLight.material = lightOff;
			noPowerLight.material = noPowerLightOn;
		} else {
			powerLight.material = powerLightOn;
			noPowerLight.material = lightOff;
		}

		//if switch is off, laser and bot turn ON, otherwise laser and bot stay OFF
		if (switchPoweredOn == false) {
			laser1.GetComponent<LineRenderer>().enabled = true;
			laser1.GetComponent<CapsuleCollider> ().enabled = true;
			laser2.GetComponent<LineRenderer>().enabled = false;
			laser2.GetComponent<CapsuleCollider>().enabled = false;
			bot.GetComponent<BotPatrolPath> ().enabled = true;
		} else {
			laser1.GetComponent<LineRenderer>().enabled = false;
			laser1.GetComponent<CapsuleCollider> ().enabled = false;
			laser2.GetComponent<LineRenderer>().enabled = true;
			laser2.GetComponent<CapsuleCollider> ().enabled = true;
			bot.GetComponent<BotPatrolPath> ().enabled = false;
		}
	}

	//only allow player to use switch if player is near switch
	void OnTriggerStay (Collider playerCollider) {

		if (playerCollider.gameObject.tag == "Player") {

			//if key is pressed, switch turns on and off
			if (Input.GetKeyDown (keyToActivate)) {
				switchPoweredOn = !switchPoweredOn;
			}			
		}
	}

}
