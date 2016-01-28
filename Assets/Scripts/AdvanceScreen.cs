using UnityEngine;
using System.Collections;

public class AdvanceScreen : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			Application.LoadLevel ("Rules 1");
		}
	}
}
