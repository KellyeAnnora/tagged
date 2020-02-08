using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour {

	//Player
	public GameObject playerSpawnPoint;
	public GameObject newPlayerSpawn;

	//Bots
	public GameObject bot302;
	public GameObject bot302ResetPos;
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Player has cleared the first checkpoint.");

			//moves the player spawnpoint up
			Vector3 playerReset = newPlayerSpawn.transform.position;
			playerSpawnPoint.transform.position = playerReset;

			//sets player's respawn rotation
			Quaternion playerResetRot = newPlayerSpawn.transform.rotation;
			playerSpawnPoint.transform.rotation = playerResetRot;

			Vector3 botReset = bot302ResetPos.transform.position;
			bot302.transform.position = botReset;
		}
	}
}
