using UnityEngine;
using System.Collections;

public class FiniteLaser : MonoBehaviour {

	private Transform startPoint;
	public Transform endPoint;
	public Vector3 startPointAdjustment;

	LineRenderer laserLine;

	// Use this for initialization
	void Start () {
		laserLine = GetComponent<LineRenderer> ();
		laserLine.SetWidth (.1f, .1f);
		startPoint = this.transform;
	}
		
	void FixedUpdate ()	{

			laserLine.SetPosition (0, startPoint.position - startPointAdjustment);
			laserLine.SetPosition (1, endPoint.position);

	}
}
