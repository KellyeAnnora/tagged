using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Testcamera : MonoBehaviour 
{
	public Transform posTarget;
	public Transform rotTarget;
	public Vector3 offset;
	public float rotationSpeed = 2;
	public float positionSpeed = 2;

	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targPos = posTarget.position - offset;
		transform.position = Vector3.Lerp (transform.position, targPos, Time.deltaTime * positionSpeed);// target.position - offset;
		transform.rotation = Quaternion.Slerp (transform.rotation, rotTarget.rotation, Time.deltaTime * rotationSpeed);
	}


	//
	//
	void Start ()
	{
		offset = posTarget.position - transform.position;
	}
}
