using UnityEngine;
using System.Collections;

public class MaintainMusic : MonoBehaviour {


	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}

}
