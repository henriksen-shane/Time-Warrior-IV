using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slash : MonoBehaviour {

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
		if (player == 1) {
			if (gameScript.redManaOne < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.redManaTwo < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		if (gameScript.allowActions == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.redManaOne < 10){
					gameScript.actionText.text = "Get more red energy!";
				}
				else {
					gameScript.redManaOne = gameScript.redManaOne - 10;   
					gameScript.redOne.value = (float)gameScript.redManaOne;
					gameScript.redManaOneText.text = "" + gameScript.redManaOne;

					gameScript.PlaySFX("slash");
					gameScript.bleed2.SetActive(true);
					gameScript.damageOverTimeTwo = gameScript.damageOverTimeTwo + 3;
					gameScript.damageHolder = gameScript.damageHolder + 3;
					gameScript.CheckForMatchesAfterReplace();
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.redManaTwo < 10){
					gameScript.actionText.text = "Get more red energy!";
				}
				else {
					gameScript.redManaTwo = gameScript.redManaTwo - 10;
					gameScript.redTwo.value = (float)gameScript.redManaTwo;
					gameScript.redManaTwoText.text = "" + gameScript.redManaTwo;

					gameScript.PlaySFX("slash");
					gameScript.bleed1.SetActive(true);
					gameScript.damageOverTimeOne = gameScript.damageOverTimeOne + 3;
					gameScript.damageHolder = gameScript.damageHolder + 5;
					gameScript.CheckForMatchesAfterReplace();
				}
			}
		}
	}
	public void MouseOver (string info){
		gameScript.ButtonMousedOver (info);
	}
	
	public void MouseLeave (){
		gameScript.ButtonLeft ();
	}
}
