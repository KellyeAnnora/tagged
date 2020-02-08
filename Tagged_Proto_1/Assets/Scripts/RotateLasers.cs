using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLasers : MonoBehaviour {

	public float speedAndDirection = 30;
	
	void Update () {
		transform.Rotate (new Vector3 (0, speedAndDirection, 0) * Time.deltaTime);
	}
}
