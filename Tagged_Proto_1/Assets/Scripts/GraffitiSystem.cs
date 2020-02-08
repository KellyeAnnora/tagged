using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraffitiSystem : MonoBehaviour {

	public KeyCode keyToActivate;
	public GameObject graffiti;

	Animator anim;
	private bool inGraffitiRange = false;

	void Start () {
		anim = GetComponent<Animator>();
	}

	//checks if player is in range
	void OnTriggerEnter (Collider other) {

		if (other.gameObject.CompareTag ("Graffitiable")) {
			print ("Player has entered graffiti range.");
			inGraffitiRange = true;
		}

	}
		
	void OnTriggerExit (Collider other) {

		if (other.gameObject.CompareTag ("Graffitiable")) {
			print ("Player has exited graffiti range.");
			inGraffitiRange = false;
		}
		
	}

	//if player is in range and presses action key, initiate tagging sequence
	void Update () {

		if (inGraffitiRange) {
			if (Input.GetKeyDown (keyToActivate)) {
				print ("Tagging sequence initiated.");
				TaggingSequence ();
			}
		}
	}

	void TaggingSequence () {
		anim.SetBool ("IsTagging", true);
		print ("The animation should have played.");
		graffiti.SetActive (true);
//		anim.SetBool ("IsTagging", false);
	}
		
}
