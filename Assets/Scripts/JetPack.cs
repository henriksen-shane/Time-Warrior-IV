using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JetPack : MonoBehaviour {

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
			if (gameScript.yellowManaOne < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.yellowManaTwo < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		//sets the player in jetpack mode, where they the next instance of damage
		if (gameScript.allowActions == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.yellowManaOne < 10){
					gameScript.actionText.text = "Get more yellow energy!";
				}
				else {
					gameScript.yellowManaOne = gameScript.yellowManaOne - 10;   
					gameScript.yellowOne.value = (float)gameScript.yellowManaOne;
					gameScript.yellowManaOneText.text = "" + gameScript.yellowManaOne;

					gameScript.PlaySFX("jet");
					gameScript.allowDamage1 = false;
					gameScript.jetOne.text = "Jetpack Active";
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.yellowManaTwo < 10){
					gameScript.actionText.text = "Get more yellow energy!";
				}
				else {
					gameScript.yellowManaTwo = gameScript.yellowManaTwo - 10;
					gameScript.yellowTwo.value = (float)gameScript.yellowManaTwo;
					gameScript.yellowManaTwoText.text = "" + gameScript.yellowManaTwo;

					gameScript.PlaySFX("jet");
					gameScript.allowDamage2 = false;
					gameScript.jetTwo.text = "Jetpack Active";
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
