using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashFreeze : MonoBehaviour {

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
			if (gameScript.blueManaOne < 8){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.blueManaTwo < 8){
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
		Debug.Log ("Button Clicked");

		if (gameScript.allowActions == true) {
			Debug.Log ("allow actions was true");
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				Debug.Log ("Player1Turn");
				if (gameScript.blueManaOne < 8){
					gameScript.actionText.text = "Get more blue energy!";
				}
				else {
					if (gameScript.stun == false) {
						Debug.Log ("stun was false");
						gameScript.blueManaOne = gameScript.blueManaOne - 8;   
						gameScript.blueOne.value = (float)gameScript.blueManaOne;
						gameScript.blueManaOneText.text = "" + gameScript.blueManaOne;

						gameScript.PlaySFX("freeze");
						gameScript.stun = true;
						Debug.Log ("stun set to true");
						gameScript.freeze2.SetActive(true);
						gameScript.actionText.text = "Opponent stunned";
					} 
					else if (gameScript.stun == true) {
						Debug.Log ("Stun was true");
						gameScript.actionText.text = "Opponent already stunned";
					}
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.blueManaTwo < 8){
					gameScript.actionText.text = "Get more blue energy!";
				}
				else {
					if (gameScript.stun == false) {
						gameScript.blueManaTwo = gameScript.blueManaTwo - 8;
						gameScript.blueTwo.value = (float)gameScript.blueManaTwo;
						gameScript.blueManaTwoText.text = "" + gameScript.blueManaTwo;

						gameScript.PlaySFX("freeze");
						gameScript.stun = true;
						gameScript.freeze1.SetActive(true);
						gameScript.actionText.text = "Opponent stunned";
					} 
					else if (gameScript.stun == true) {
						gameScript.actionText.text = "Opponent already stunned";
					}
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
