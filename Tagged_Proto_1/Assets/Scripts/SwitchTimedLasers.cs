using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTimedLasers : MonoBehaviour {

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

	//hooking up the lasers we're turning off (temporarily)
	public GameObject Emitter1;
	public GameObject Emitter2;

	//bool to disable lasers
	public bool lasersAreDisabled;

	//timer
	private float timer;
	public float timeLimit = 2f;
	public bool timerIsRunning;

	void Start () {
		timerIsRunning = false;
	}

	void Update () {

		//if switch is off, orange light, otherwise green light
		if (switchPoweredOn == false) {
			powerLight.material = lightOff;
			noPowerLight.material = noPowerLightOn;
		} else {
			powerLight.material = powerLightOn;
			noPowerLight.material = lightOff;
		}

		//if switch is off, timer starts
		if (switchPoweredOn == false) {
			timerIsRunning = true;
		}
	}

	void FixedUpdate () {

		if (timerIsRunning) {
			lasersAreDisabled = true;
			timer += Time.deltaTime;
		}

		if (timer >= timeLimit) {
			timerIsRunning = false;
			lasersAreDisabled = false;
			timer = 0f;
		}

		if (lasersAreDisabled) {
			Emitter1.GetComponent<LineRenderer> ().enabled = false;
			Emitter1.GetComponent<Collider> ().enabled = false;
			Emitter1.GetComponent<AudioSource> ().enabled = false;
			Emitter2.GetComponent<LineRenderer> ().enabled = false;
			Emitter2.GetComponent<Collider> ().enabled = false;
			Emitter2.GetComponent<AudioSource> ().enabled = false;

		} else {
			Emitter1.GetComponent<LineRenderer> ().enabled = true;
			Emitter1.GetComponent<Collider> ().enabled = true;
			Emitter1.GetComponent<AudioSource> ().enabled = true;
			Emitter2.GetComponent<LineRenderer> ().enabled = true;
			Emitter2.GetComponent<Collider> ().enabled = true;
			Emitter2.GetComponent<AudioSource> ().enabled = true;
	
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
