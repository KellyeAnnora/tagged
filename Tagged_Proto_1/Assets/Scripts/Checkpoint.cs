using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	//Player
	public GameObject playerSpawnPoint;
	public GameObject newSpawnTrans;

	//Bool to be accessed by other objects
	public bool resetPuzzle = false;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Player has cleared a checkpoint.");

			//reset bool for other objects
			resetPuzzle = true;

			//moves the player spawnpoint up
			Vector3 newPlayerSpawn = newSpawnTrans.transform.position;
			playerSpawnPoint.transform.position = newPlayerSpawn;

			//sets player respawn rotation
			Quaternion newPlayerRot = newSpawnTrans.transform.rotation;
			playerSpawnPoint.transform.rotation = newPlayerRot;

		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
			resetPuzzle = false;
		}
	}
}
