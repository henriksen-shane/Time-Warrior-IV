using UnityEngine;
using System.Collections;

public class GoToExplorer : MonoBehaviour {

	//move to the explorer explanation screen
	public void Clicked (){
		Application.LoadLevel ("Explorer");
	}
}
