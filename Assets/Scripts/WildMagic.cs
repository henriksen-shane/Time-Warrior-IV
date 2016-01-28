using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WildMagic : MonoBehaviour {

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
			if (gameScript.orangeManaOne < 6){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.orangeManaTwo < 6){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		if (gameScript.allowActions == true) {

			int primaryClass = UnityEngine.Random.Range (0, 6);
			int secondaryClass = UnityEngine.Random.Range (0, 6);
			int primaryLevel = UnityEngine.Random.Range (1, 4);
			int secondaryLevel = UnityEngine.Random.Range (0, 2);
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.orangeManaOne < 6){
					gameScript.actionText.text = "Get more orange energy!";
				}
				else {
					gameScript.orangeManaOne = gameScript.orangeManaOne - 6;   
					gameScript.orangeOne.value = (float)gameScript.orangeManaOne;
					gameScript.orangeManaOneText.text = "" + gameScript.orangeManaOne;

					gameScript.PlaySFX("wild");
					gameScript.player1Classes = new int [] {0,0,0,0,0,0};
					gameScript.player1Classes[primaryClass] = primaryLevel;
					if ((primaryLevel == 1) || (primaryLevel == 2)){
						gameScript.player1Classes[secondaryClass] = secondaryLevel;
					}
					gameScript.player1Class = primaryClass;
					gameScript.UpdateClassImage(primaryClass, 1);
					gameScript.CheckForMatchesAfterReplace();
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.orangeManaTwo < 6){
					gameScript.actionText.text = "Get more orange energy!";
				}
				else {
					gameScript.orangeManaTwo = gameScript.orangeManaTwo - 6;
					gameScript.orangeTwo.value = (float)gameScript.orangeManaTwo;
					gameScript.orangeManaTwoText.text = "" + gameScript.orangeManaTwo;

					gameScript.PlaySFX("wild");
					gameScript.player2Classes = new int [] {0,0,0,0,0,0};
					gameScript.player2Classes[primaryClass] = primaryLevel;
					if ((primaryLevel == 1) || (primaryLevel == 2)){
						gameScript.player2Classes[secondaryClass] = secondaryLevel;
					}
					gameScript.player2Class = primaryClass;
					gameScript.UpdateClassImage(primaryClass, 2);
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
