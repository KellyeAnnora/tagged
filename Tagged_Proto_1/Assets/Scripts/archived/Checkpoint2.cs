using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour {

	//Player
	public GameObject playerSpawnPoint;
	public GameObject newSpawnTrans;

	//Switches
	public bool resetPuzzle;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Player has cleared the second checkpoint.");

			//moves the player spawnpoint up
			Vector3 newPlayerSpawn = newSpawnTrans.transform.position;
			playerSpawnPoint.transform.position = newPlayerSpawn;

			//sets player respawn rotation
			Quaternion newPlayerRot = newSpawnTrans.transform.rotation;
			playerSpawnPoint.transform.rotation = newPlayerRot;

			//resets switches
			resetPuzzle = true;
		}
	}
}
