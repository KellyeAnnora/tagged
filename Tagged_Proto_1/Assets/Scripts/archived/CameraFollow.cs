using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 smoothSpeed;
	public float smoothTime = 0.5f;
	public float maxSpeed = 1;
	public Vector3 offset;

	void LateUpdate () {
		Vector3 desiredPosition = transform.position = target.position + offset;
		Vector3 smoothedPosition = Vector3.SmoothDamp (transform.position, desiredPosition, ref smoothSpeed, smoothTime, maxSpeed);
		transform.position = smoothedPosition;

		transform.LookAt (target);
	}
}
