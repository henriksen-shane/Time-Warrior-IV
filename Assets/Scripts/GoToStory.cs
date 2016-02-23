using UnityEngine;
using System.Collections;

public class GoToStory : MonoBehaviour {
//move to the story explanation screen
	public void Clicked (){
		Application.LoadLevel ("StoryIntro");
	}
}
