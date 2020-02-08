using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidPlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float moveSpeed = 20;


	void Update () {
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 10.0f;

		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);


		//rb.AddForce (transform.forward * moveSpeed * Time.deltaTime);
	}


	void OnCollisionEnter (Collision c)
	{
		Debug.Log (c.gameObject.name);
	}
}
