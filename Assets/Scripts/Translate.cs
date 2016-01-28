using UnityEngine;
using System.Collections;


public class Translate : MonoBehaviour {

	public float delayTime;
	public Vector3 posA;
	public Vector3 posB;
	//public Vector3 speed = new Vector3(5.0F,0,0);
	
	// Use this for initialization
	void Start () {
		StartCoroutine(WaitAndMove(delayTime));	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.Translate(speed * Time.deltaTime);
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

	
