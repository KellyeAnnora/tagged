using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint4 : MonoBehaviour {

	//Player
	public GameObject playerSpawnPoint;
	public GameObject newSpawnTrans;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Player has cleared the fourth checkpoint.");

			//moves the player spawnpoint up
			Vector3 newPlayerSpawn = newSpawnTrans.transform.position;
			playerSpawnPoint.transform.position = newPlayerSpawn;

			//sets player respawn rotation
			Quaternion newPlayerRot = playerSpawnPoint.transform.rotation;
			playerSpawnPoint.transform.rotation = newPlayerRot;

		}
	}
}
