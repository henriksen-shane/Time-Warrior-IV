using UnityEngine;
using System.Collections;

public class GoToWizard : MonoBehaviour {
//move to the wizard explanation screen
	public void Clicked (){
		Application.LoadLevel ("Wizard");
	}
}
