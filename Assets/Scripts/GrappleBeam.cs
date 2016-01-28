using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GrappleBeam : MonoBehaviour {

	GameObject firstTile;
	GameObject secondTile;
	RaycastHit hit;
	bool grappleStarted = false;
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

	// Update is called once per frame
	void Update () {
		if (player == 1) {
			if (gameScript.yellowManaOne < 7){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.yellowManaTwo < 7){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
		
		Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetButtonDown ("Fire1")) {	
			if (Physics.Raycast (ray1, out hit, Mathf.Infinity)) {
				GameObject selectedTile = hit.transform.gameObject;
				//Did they click a tile?
				if (selectedTile.tag.Contains ("Tile")) {
					//Is this the first tile?
					if (firstTile == null) {
						firstTile = selectedTile;
					}
					//Is this the second tile?
					else if (firstTile != null) {
						secondTile = selectedTile;
					}
				}
			}
		}
		if ((grappleStarted == true) && (firstTile != null)){
			gameScript.actionText.text = "Select the second tile to switch";
		}
		if ((grappleStarted == true) && (secondTile != null)){
			gameScript.PlaySFX("grapple");
			StartCoroutine (gameScript.SelectionMade(firstTile, secondTile));
			gameScript.actionText.text = "";
			grappleStarted = false;
			//gameScript.Invoke ("CheckForMatchesAfterReplace", 1);
		}
	}

	public void Clicked (){
		Debug.Log ("grapple Clicked");

		if ((gameScript.allowActions) == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.yellowManaOne < 7){
					gameScript.actionText.text = "Get more yellow energy!";
				}
				else {
					gameScript.yellowManaOne = gameScript.yellowManaOne - 7;   
					gameScript.yellowOne.value = (float)gameScript.yellowManaOne;
					gameScript.yellowManaOneText.text = "" + gameScript.yellowManaOne;

					firstTile = null;
					secondTile = null;
					gameScript.allowActions = false;
					gameScript.actionText.text = "Select the first tile to switch";
					grappleStarted = true;
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.yellowManaTwo < 7){
					gameScript.actionText.text = "Get more yellow energy!";
				}
				else {
					gameScript.yellowManaTwo = gameScript.yellowManaTwo - 7;
					gameScript.yellowTwo.value = (float)gameScript.yellowManaTwo;
					gameScript.yellowManaTwoText.text = "" + gameScript.yellowManaTwo;

					firstTile = null;
					secondTile = null;
					gameScript.allowActions = false;
					gameScript.actionText.text = "Select the first tile to switch";
					grappleStarted = true;
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
