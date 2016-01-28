using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaBomb : MonoBehaviour {

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
			if (gameScript.orangeManaOne < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.orangeManaTwo < 10){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){

		if (gameScript.allowActions == true) {
			string removalTag = gameScript.RandomTile().tag;

			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.orangeManaOne < 10){
					gameScript.actionText.text = "Get more orange energy!";
				}
				else {
					gameScript.orangeManaOne = gameScript.orangeManaOne - 10;   
					gameScript.orangeOne.value = (float)gameScript.orangeManaOne;
					gameScript.orangeManaOneText.text = "" + gameScript.orangeManaOne;

					gameScript.PlaySFX("bomb");

					switch (removalTag)
					{
					case "BlackTile":
						gameScript.actionText.text = "Black tiles destroyed";
						break;
					case "BlueTile":
						gameScript.actionText.text = "Blue tiles destroyed";
						break;
					case "GreenTile":
						gameScript.actionText.text = "Green tiles destroyed";
						break;
					case "OrangeTile":
						gameScript.actionText.text = "Orange tiles destroyed";
						break;
					case "PurpleTile":
						gameScript.actionText.text = "Purple tiles destroyed";
						break;
					case "RedTile":
						gameScript.actionText.text = "Red tiles destroyed";
						break;
					default:
						gameScript.actionText.text = "Yellow tiles destroyed";
						break;
					}
					
					GameObject[] tilesToRemove = GameObject.FindGameObjectsWithTag(removalTag);
					foreach (GameObject go in tilesToRemove)
					{
						gameScript.Remove(go);
					}
					StartCoroutine (gameScript.Collapse ());
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.orangeManaTwo < 10){
					gameScript.actionText.text = "Get more orange energy!";
				}
				else {
					gameScript.orangeManaTwo = gameScript.orangeManaTwo - 10;
					gameScript.orangeTwo.value = (float)gameScript.orangeManaTwo;
					gameScript.orangeManaTwoText.text = "" + gameScript.orangeManaTwo;

					gameScript.PlaySFX("bomb");

					switch (removalTag)
					{
					case "BlackTile":
						gameScript.actionText.text = "Black tiles destroyed";
						break;
					case "BlueTile":
						gameScript.actionText.text = "Blue tiles destroyed";
						break;
					case "GreenTile":
						gameScript.actionText.text = "Green tiles destroyed";
						break;
					case "OrangeTile":
						gameScript.actionText.text = "Orange tiles destroyed";
						break;
					case "PurpleTile":
						gameScript.actionText.text = "Purple tiles destroyed";
						break;
					case "RedTile":
						gameScript.actionText.text = "Red tiles destroyed";
						break;
					default:
						gameScript.actionText.text = "Yellow tiles destroyed";
						break;
					}
					
					GameObject[] tilesToRemove = GameObject.FindGameObjectsWithTag(removalTag);
					foreach (GameObject go in tilesToRemove)
					{
						gameScript.Remove(go);
					}
					StartCoroutine (gameScript.Collapse ());
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
