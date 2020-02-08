using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

	public Transform assignedSpawnPoint;
	public Transform assignedCamSpawnPoint;

	public GameObject firstCheckpoint;
	public GameObject secondCheckpoint;
	public GameObject thirdCheckpoint;

	public Transform firstPlayerSpawn;
	public Transform firstCamSpawn;
	public Transform secondPlayerSpawn;
	public Transform secondCamSpawn;
	public Transform thirdPlayerSpawn;
	public Transform thirdCamSpawn;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			
		}
	}

}