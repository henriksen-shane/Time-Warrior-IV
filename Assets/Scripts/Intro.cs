using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Go to the story screen
	public void Clicked (){
		Application.LoadLevel ("StoryIntro");
	}
}
