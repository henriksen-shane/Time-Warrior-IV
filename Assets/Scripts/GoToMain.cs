using UnityEngine;
using System.Collections;

public class GoToMain : MonoBehaviour {

//move to the game screen
	public void Clicked(){
		Application.LoadLevel ("Main");
	}
}
