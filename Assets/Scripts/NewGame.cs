using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

// reloads the main game scene, starting a new game. Called from option menu
	public void Clicked () {
		Application.LoadLevel(Application.loadedLevel);
	}
}
