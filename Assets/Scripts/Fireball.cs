using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fireball : MonoBehaviour {

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
			if (gameScript.blueManaOne < 4){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.blueManaTwo < 4){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){

		if (gameScript.allowActions == true) {
			//deal 3 damage to opponent
			if ((gameScript.playerOneTurn) && (player == 1)){
				if (gameScript.blueManaOne < 4){
					gameScript.actionText.text = "Get more blue energy!";
				}
				else{
					gameScript.blueManaOne = gameScript.blueManaOne - 4;   
					gameScript.blueOne.value = (float)gameScript.blueManaOne;
					gameScript.blueManaOneText.text = "" + gameScript.blueManaOne;

					Debug.Log ("audio should play here");
					gameScript.PlaySFX("fire");
					gameScript.damageHolder = gameScript.damageHolder + 3;
					gameScript.CheckForMatchesAfterReplace();
				}
			}
			else if ((gameScript.playerTwoTurn) && (player == 2)){
				if (gameScript.blueManaTwo < 4){
					gameScript.actionText.text = "Get more blue energy!";
				}
				else{
					gameScript.blueManaTwo = gameScript.blueManaTwo - 4;
					gameScript.blueTwo.value = (float)gameScript.blueManaTwo;
					gameScript.blueManaTwoText.text = "" + gameScript.blueManaTwo;

					gameScript.PlaySFX("fire");
					gameScript.damageHolder = gameScript.damageHolder + 3;
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
