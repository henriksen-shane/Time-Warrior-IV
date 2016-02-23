using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserSight : MonoBehaviour {

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
			if (gameScript.greenManaOne < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.greenManaTwo < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		//puts the player in laser sight mode where they deal double damage
		if (gameScript.allowActions == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.greenManaOne < 10){
					gameScript.actionText.text = "Get more green energy!";
				}
				else {
					gameScript.greenManaOne = gameScript.greenManaOne - 10;   
					gameScript.greenOne.value = (float)gameScript.greenManaOne;
					gameScript.greenManaOneText.text = "" + gameScript.greenManaOne;

					gameScript.PlaySFX("laser");
					gameScript.actionText.text = "Target acquired! Next attack will deal double damage.";
					gameScript.sightedOne = 2;
					gameScript.playerOneSightedHP = gameScript.player1HP;
					gameScript.laserOne.text = "Laser Sight";
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.greenManaTwo < 10){
					gameScript.actionText.text = "Get more green energy!";
				}
				else {
					gameScript.greenManaTwo = gameScript.greenManaTwo - 10;
					gameScript.greenTwo.value = (float)gameScript.greenManaTwo;
					gameScript.greenManaTwoText.text = "" + gameScript.greenManaTwo;

					gameScript.PlaySFX("laser");
					gameScript.actionText.text = "Target acquired! Next attack will deal double damage.";
					gameScript.sightedTwo = 2;
					gameScript.playerTwoSightedHP = gameScript.player2HP;
					gameScript.laserTwo.text = "Laser Sight";
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
