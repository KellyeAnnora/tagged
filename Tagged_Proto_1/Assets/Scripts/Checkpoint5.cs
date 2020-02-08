using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint5 : MonoBehaviour {

	//Player
	public GameObject playerSpawnPoint;
	public GameObject newSpawnTrans;

	//Bot
	public GameObject bot;
	public GameObject botStartPos;

	//Switches
	public GameObject switch701;
	public GameObject switch702;
	public GameObject switch703;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Player has cleared the fifth checkpoint.");

			//moves the player spawnpoint up
			Vector3 newPlayerSpawn = newSpawnTrans.transform.position;
			playerSpawnPoint.transform.position = newPlayerSpawn;

			//sets player's respawn rotation
			Quaternion newPlayerRot = newSpawnTrans.transform.rotation;
			playerSpawnPoint.transform.rotation = newPlayerRot;

			//resets bot position
			Vector3 newBotPos = botStartPos.transform.position;
			bot.transform.position = newBotPos;
			bot.GetComponent<BotPatrolPath> ().enabled = false;

			switch701.GetComponent<SwitchLaserSingle>().switchPoweredOn = true;
			switch702.GetComponent<SwitchLaser702>().switchPoweredOn = true;
			switch703.GetComponent<SwitchLaserSingle>().switchPoweredOn = true;
		}
	}
}
