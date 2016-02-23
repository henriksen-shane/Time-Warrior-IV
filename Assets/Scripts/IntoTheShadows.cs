using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntoTheShadows : MonoBehaviour {

	public Sprite greyOut;
	int player;
	private Button button;
	GameObject manage;
	GameManager gameScript;
	
	void Start (){
		if (gameObject.tag.Contains ("Play1")) {
			player = 1;
		} 
		else {
			player = 2;
		}
		
		button = GetComponent<Button> ();
		manage = GameObject.Find ("GameManagerObject");
		gameScript = manage.GetComponent<GameManager> ();
	}
	
	void Update (){
		//if the player doesn't have enough energy for this move, grey the button out
		if (player == 1) {
			if (gameScript.purpleManaOne < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.purpleManaTwo < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		GameObject go = GameObject.Find ("GameManagerObject");
		GameManager gameScript = go.GetComponent<GameManager> ();
		// puts the player into cloaked mode, where damge is dealt do their purple energy rather than health
		if (gameScript.allowActions == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.purpleManaOne < 10){
					gameScript.actionText.text = "Get more purple energy!";
				}
				else {
					gameScript.purpleManaOne = gameScript.purpleManaOne - 10;   
					gameScript.purpleOne.value = (float)gameScript.purpleManaOne;
					gameScript.purpleManaOneText.text = "" + gameScript.purpleManaOne;

					gameScript.PlaySFX("shadow");
					gameScript.cloaked1 = true;
					gameScript.CheckForMatchesAfterReplace();
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.purpleManaTwo < 10){
					gameScript.actionText.text = "Get more purple energy!";
				}
				else {
					gameScript.purpleManaTwo = gameScript.purpleManaTwo - 10;
					gameScript.purpleTwo.value = (float)gameScript.purpleManaTwo;
					gameScript.purpleManaTwoText.text = "" + gameScript.purpleManaTwo;

					gameScript.PlaySFX("shadow");
					gameScript.cloaked2 = true;
					gameScript.CheckForMatchesAfterReplace();
				}
			}
		}
	}
	//call the script in Game Manger to change the explanation text
	public void MouseOver (string info){
		gameScript.ButtonMousedOver (info);
	}
	
//call the script in Game Manager to erase the explanation text
	public void MouseLeave (){
		gameScript.ButtonLeft ();
	}
}
