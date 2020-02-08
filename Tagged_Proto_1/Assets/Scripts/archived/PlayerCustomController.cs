﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomController : MonoBehaviour {

	public float runSpeed = 1;

	Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero) {
			transform.eulerAngles = Vector3.up * Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg;
		}

		float speed = (runSpeed) * inputDir.magnitude;

		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);

		float animationSpeedPercent = (1) * inputDir.magnitude;
		animator.SetFloat ("speedPercent", animationSpeedPercent);
	}
}
