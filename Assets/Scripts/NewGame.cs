using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	public void Clicked () {
		Application.LoadLevel(Application.loadedLevel);
	}
}
