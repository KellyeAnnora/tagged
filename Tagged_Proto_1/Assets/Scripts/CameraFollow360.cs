using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow360 : MonoBehaviour {

	public Transform player;
	public Vector3 lookOffset = new Vector3 (0, 1, 0);
	public float followDistance = 5;
	public float cameraSpeed = 8;
	
	void LateUpdate () {
		Vector3 lookPosition = player.position + lookOffset;
		this.transform.LookAt (lookPosition);

		if (Vector3.Distance (this.transform.position, lookPosition) > followDistance) {
			this.transform.Translate (0, 0, cameraSpeed * Time.deltaTime);
		}
			
	}
}
