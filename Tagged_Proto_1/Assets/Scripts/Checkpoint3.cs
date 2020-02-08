using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint3 : MonoBehaviour {

	//Player
	public GameObject playerSpawnPoint;
	public GameObject newSpawnTrans;

	//Switches
	public GameObject switch501;

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Player has cleared the third checkpoint.");

			//moves the player spawnpoint up
			Vector3 newPlayerSpawn = newSpawnTrans.transform.position;
			playerSpawnPoint.transform.position = newPlayerSpawn;

			//sets player respawn rotation
			Quaternion newPlayerRot = newSpawnTrans.transform.rotation;
			playerSpawnPoint.transform.rotation = newPlayerRot;

			switch501.GetComponent<SwitchLaserRotator>().switchPoweredOn = true;

		}
	}
}
