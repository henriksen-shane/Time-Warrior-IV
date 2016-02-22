using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AirStrike : MonoBehaviour {

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
			if (gameScript.greenManaOne < 20){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.greenManaTwo < 20){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		if (gameScript.allowActions == true) {
			// Deal damage and reduce the opponent's energy reserves
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.greenManaOne < 20){
					gameScript.actionText.text = "Get more green energy!";
				}
				else {
				gameScript.greenManaOne = gameScript.greenManaOne - 20;   
				gameScript.greenOne.value = (float)gameScript.greenManaOne;
				gameScript.greenManaOneText.text = "" + gameScript.greenManaOne;

				gameScript.PlaySFX("strike");

				gameScript.blueManaTwo = Mathf.Clamp((gameScript.blueManaTwo - 5), 0, 1000);
				gameScript.greenManaTwo = Mathf.Clamp((gameScript.greenManaTwo - 5), 0, 1000);
				gameScript.orangeManaTwo = Mathf.Clamp((gameScript.orangeManaTwo - 5), 0, 1000);
				gameScript.purpleManaTwo = Mathf.Clamp((gameScript.purpleManaTwo - 5), 0, 1000);
				gameScript.redManaTwo = Mathf.Clamp((gameScript.redManaTwo - 5), 0, 1000);
				gameScript.yellowManaTwo = Mathf.Clamp((gameScript.yellowManaTwo - 5), 0, 1000);

				gameScript.blueTwo.value = (float)gameScript.blueManaTwo;
				gameScript.greenTwo.value = (float)gameScript.greenManaTwo;
				gameScript.redTwo.value = (float)gameScript.redManaTwo;
				gameScript.purpleTwo.value = (float)gameScript.purpleManaTwo;
				gameScript.orangeTwo.value = (float)gameScript.orangeManaTwo;
				gameScript.yellowTwo.value = (float)gameScript.yellowManaTwo;
				

				gameScript.blueManaTwoText.text = "" + gameScript.blueManaTwo;
				gameScript.greenManaTwoText.text = "" + gameScript.greenManaTwo;
				gameScript.orangeManaTwoText.text = "" + gameScript.orangeManaTwo;
				gameScript.purpleManaTwoText.text = "" + gameScript.purpleManaTwo;
				gameScript.redManaTwoText.text = "" + gameScript.redManaTwo;
				gameScript.yellowManaTwoText.text = "" + gameScript.yellowManaTwo;
				
				gameScript.damageHolder = gameScript.damageHolder + 10;
				gameScript.CheckForMatchesAfterReplace();
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.greenManaTwo < 20){
					gameScript.actionText.text = "Get more green energy!";
				}
				else {
				gameScript.greenManaTwo = gameScript.greenManaTwo - 20;   
				gameScript.greenTwo.value = (float)gameScript.greenManaTwo;
				gameScript.greenManaTwoText.text = "" + gameScript.greenManaTwo;

				gameScript.PlaySFX("strike");
				
				gameScript.blueManaOne = Mathf.Clamp((gameScript.blueManaOne - 5), 0, 1000);
				gameScript.greenManaOne = Mathf.Clamp((gameScript.greenManaOne - 5), 0, 1000);
				gameScript.orangeManaOne = Mathf.Clamp((gameScript.orangeManaOne - 5), 0, 1000);
				gameScript.purpleManaOne = Mathf.Clamp((gameScript.purpleManaOne - 5), 0, 1000);
				gameScript.redManaOne = Mathf.Clamp((gameScript.redManaOne - 5), 0, 1000);
				gameScript.yellowManaOne = Mathf.Clamp((gameScript.yellowManaOne - 5), 0, 1000);

				gameScript.blueOne.value = (float)gameScript.blueManaOne;
				gameScript.greenOne.value = (float)gameScript.greenManaOne;
				gameScript.redOne.value = (float)gameScript.redManaOne;
				gameScript.purpleOne.value = (float)gameScript.purpleManaOne;
				gameScript.orangeOne.value = (float)gameScript.orangeManaOne;
				gameScript.yellowOne.value = (float)gameScript.yellowManaOne;

				gameScript.blueManaOneText.text = "" + gameScript.blueManaOne;
				gameScript.greenManaOneText.text = "" + gameScript.greenManaOne;
				gameScript.orangeManaOneText.text = "" + gameScript.orangeManaOne;
				gameScript.purpleManaOneText.text = "" + gameScript.purpleManaOne;
				gameScript.redManaOneText.text = "" + gameScript.redManaOne;
				gameScript.yellowManaOneText.text = "" + gameScript.yellowManaOne;
				
				gameScript.damageHolder = gameScript.damageHolder + 10;
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
