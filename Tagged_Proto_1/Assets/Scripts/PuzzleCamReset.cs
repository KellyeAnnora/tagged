using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCamReset : MonoBehaviour {

	//resetting switches from checkpoints
	public GameObject checkpoint;
	public GameObject beam;
	public bool switchHasReset = false;
	public bool startsOn;
	
	void Update () {

		switchHasReset = checkpoint.GetComponent<Checkpoint> ().resetPuzzle;

		if (switchHasReset == true) {
			print ("Puzzle cameras have reset.");
			beam.SetActive (startsOn);
			switchHasReset = false;
		}
	}
}
