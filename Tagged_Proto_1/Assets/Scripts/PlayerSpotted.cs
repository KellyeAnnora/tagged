using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotted : MonoBehaviour {

	//variables used for player health and alive/dead status
	public int playerHP = 10;
	public int damage = 10;
	private bool playerIsDead;

	//variables for player death sequence
	private Animation deathAnim;
	private AudioSource deathSFX;

	//variables for player respawn sequence
//	public GameObject followCamera;
	public Transform assignedSpawnPoint;
//	public Transform assignedCamSpawnPoint;

	//variables for hiding mechanics
	private bool playerIsHidden = false;

	void Start () {

		//player is not dead
		playerIsDead = false;

		//initializations for death sequence
		deathAnim = GetComponent<Animation> ();
		deathSFX = GetComponent<AudioSource> ();

	}
		
	void Update () {

		//player dies when HP drops to 0
		if (playerHP <= 0) {
			PlayerDies();
		}

	}

	//death sequence
	void PlayerDies () {
		if (playerIsDead == false) {
			playerIsDead = true;
			print ("The player is dead.");
			deathAnim.Play ();
			deathSFX.Play ();
			PlayerRespawn ();
		}
	}

	//if player dies, player goes back to current respawn point
	void PlayerRespawn () {
		if (playerIsDead == true) {
			playerHP = 10;
			this.transform.position = assignedSpawnPoint.position;
			this.transform.rotation = assignedSpawnPoint.rotation;
//			followCamera.transform.position = assignedCamSpawnPoint.position;
//			followCamera.transform.rotation = assignedCamSpawnPoint.rotation;
			playerIsDead = false;
		}
	}

	//hiding
	void OnTriggerEnter (Collider other) {

		if (other.gameObject.CompareTag ("outOfSight")) {
			playerIsHidden = true;
		}
		if (playerIsHidden == false) {
			if (other.gameObject.CompareTag("enemySight")) {
				playerHP -= damage;
			}
		}

	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("outOfSight")) {
			playerIsHidden = false;
		}
	}
}
