using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sensitivity = 5.0f;  //speed camera turns
	public float smoothing = 2.0f;  //value camera smooths

	private Vector3 mouseLook; //where the mouse is
	private Vector3 camLook;  //where the camera is

	public GameObject player;

	void Update () {

		//gets and stores input from mouse movement
		Vector2 mouseMovement = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		//multiplies mouse movement by sensitivity and smoothing for each axis
		mouseMovement = Vector2.Scale (mouseMovement, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));

		//interpolates between camLook Vector2 and mouseMovement Vector2 by a percentage of the smoothing float variable
		//does this for each axis of the camera's movement
		camLook.x = Mathf.Lerp (camLook.x, mouseMovement.x, 1f / smoothing);
		camLook.y = Mathf.Lerp (camLook.y, mouseMovement.y, 1f / smoothing);
		mouseLook += camLook;

		//clamps the camera's movement along the y axis, limiting how far the player can look up and down
		mouseLook.y = Mathf.Clamp (mouseLook.y, -45f, 0f);

		//rotates the camera based on the mouseLook Vector2's y axis
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);

		//rotates the player based onthe mouseLook Vector2's x axis
		player.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, player.transform.up);

	}

}
