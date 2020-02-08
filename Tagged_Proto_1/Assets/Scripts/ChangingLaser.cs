using UnityEngine;
using System.Collections;

public class ChangingLaser : MonoBehaviour {

	private Transform startPoint;
	public Transform endPoint;
	public Vector3 startPointAdjustment;

	public GameObject player;
	public int laserDamage = 10;

	LineRenderer laserLine;

	// Use this for initialization
	void Start () {
		laserLine = GetComponent<LineRenderer> ();
		laserLine.SetWidth (.1f, .1f);
		startPoint = this.transform;
	}
		
	void FixedUpdate ()
	{

		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			Vector3 hitPosition = hit.point;
			laserLine.SetPosition (0, transform.position);
			laserLine.SetPosition (1, hitPosition);
		} else {
			laserLine.SetPosition (0, startPoint.position - startPointAdjustment);
			laserLine.SetPosition (1, endPoint.position);
		}

		if (hit.collider.tag == "Player") {
			player.GetComponent<PlayerSpotted> ().playerHP -= laserDamage;
		}
	}
}
