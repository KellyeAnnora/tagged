using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotChasePlayer : MonoBehaviour {

	public Transform targetToChase;
	public float chaseRange;
	public float speed;

	private NavMeshAgent botNavMesh;

	void Start () {

		botNavMesh = this.GetComponent<NavMeshAgent> ();

	}

	void Update () {

		//check how far away player is
		float distanceToTarget = Vector3.Distance (transform.position, targetToChase.position);

		//if player is within range, set Destination
		if (distanceToTarget < chaseRange) {
			SetDestination ();
		}
	}

	//make the player the destination
	private void SetDestination() {

		Vector3 targetVector = targetToChase.transform.position;
		botNavMesh.SetDestination (targetVector);

	}
}
