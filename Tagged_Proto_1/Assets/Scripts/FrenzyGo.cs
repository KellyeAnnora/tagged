using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenzyGo : MonoBehaviour {

	public GameObject laser;
	public Animator laserAnim;

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {
			print ("Player has entered frenzy.");
			laser.SetActive(true);
			laserAnim.SetTrigger ("frenzyIsGo");
		}
		
	}
}
