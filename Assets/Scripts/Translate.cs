using UnityEngine;
using System.Collections;

//used for moving tiles
public class Translate : MonoBehaviour {

	public float delayTime;
	public Vector3 posA;
	public Vector3 posB;
	
	void Start () {
		StartCoroutine(WaitAndMove(delayTime));	
	}

	IEnumerator WaitAndMove(float delayTime){
		yield return new WaitForSeconds (delayTime); // start at time X
		float startTime = Time.time; // Time.time contains current frame time, so remember starting point
		while (Time.time-startTime<=.5) { // until one second passed
			transform.position = Vector3.Lerp (posA, posB, (Time.time - startTime)); // lerp from A to B in one second
			yield return 1; // wait for next frame
		}
	}
}

	
