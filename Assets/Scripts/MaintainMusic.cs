using UnityEngine;
using System.Collections;

public class MaintainMusic : MonoBehaviour {

	//keeps the intro music playing until the main game screen is loaded
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}

}
