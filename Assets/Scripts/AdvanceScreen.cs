using UnityEngine;
using System.Collections;

public class AdvanceScreen : MonoBehaviour {

	// Advance to next option screen
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			Application.LoadLevel ("Rules 1");
		}
	}
}
