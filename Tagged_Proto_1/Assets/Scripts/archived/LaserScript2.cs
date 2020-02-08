using UnityEngine;
using System.Collections;

public class LaserScript2 : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;

	LineRenderer laserLine;

	// Use this for initialization
	void Start () {
		laserLine = GetComponent<LineRenderer> ();
		laserLine.SetWidth (.1f, .1f);
	}
	
	// Update is called once per frame
	void Update () {
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);
	
	}
		
	void FixedUpdate ()
	{

		RaycastHit hit;

		if (Physics.Raycast (transform.position, -transform.forward, out hit))
		{
			Vector3 hitPosition = hit.point;
//			Debug.Log (hitPosition);

			laserLine.SetPosition (0, transform.position);
			laserLine.SetPosition (1, hitPosition);
		}
	}
}
