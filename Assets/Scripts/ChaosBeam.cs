using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChaosBeam: MonoBehaviour {

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
			if (gameScript.orangeManaOne < 20){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.orangeManaTwo < 20){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		//drain orange energy and deal a random amount of damage to opponent
		if (gameScript.allowActions == true) {
			int randomPower = Random.Range(0, 3);

			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.orangeManaOne < 20){
					gameScript.actionText.text = "Get more orange energy!";
				}
				else {
					gameScript.PlaySFX("chaos");
					switch (randomPower)
					{
					case 0:
						gameScript.actionText.text = "Your beam fizzles out - No Damage";
						break;
					case 1:
						gameScript.actionText.text = "Beam fired - Normal Damage";
						break;
					default:
						gameScript.actionText.text = "Overcharge - Double Damage";
						break;
					}
					gameScript.damageHolder = gameScript.damageHolder + (gameScript.orangeManaOne * randomPower);
					gameScript.orangeManaOne = 0;
					gameScript.orangeOne.value = 0f;
					gameScript.orangeManaOneText.text = "Orange: " + gameScript.orangeManaOne;

					gameScript.CheckForMatchesAfterReplace();
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.orangeManaTwo < 20){
					gameScript.actionText.text = "Get more orange energy!";
				}
				else {
					gameScript.PlaySFX("chaos");
					switch (randomPower)
					{
					case 0:
						gameScript.actionText.text = "Your beam fizzles out - No Damage";
						break;
					case 1:
						gameScript.actionText.text = "Beam fired - Normal Damage";
						break;
					default:
						gameScript.actionText.text = "Overcharge - Double Damage";
						break;
					}
					gameScript.damageHolder = gameScript.damageHolder + (gameScript.orangeManaTwo * randomPower);
					gameScript.orangeManaTwo = 0;
					gameScript.orangeTwo.value = 0f;
					gameScript.orangeManaTwoText.text = "Orange: " + gameScript.orangeManaTwo;

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
