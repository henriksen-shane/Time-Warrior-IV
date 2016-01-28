using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Grenade : MonoBehaviour {

	RaycastHit hit;
	public bool grenadeStarted = false;
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
			if (gameScript.greenManaOne < 6){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.greenManaTwo < 6){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}

		Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetButtonDown("Fire1")) {
			if (Physics.Raycast (ray1, out hit, Mathf.Infinity)) {
				GameObject selectedTile = hit.transform.gameObject;
				if ((grenadeStarted == true) && (selectedTile.tag.Contains ("Tile"))){
					gameScript.actionText.text = "";
					TileChosen (selectedTile);
				}
			}
		}
	}

	public void Clicked (){
		if (gameScript.allowActions == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains ("Play1"))) {
				if (gameScript.greenManaOne < 6) {
					gameScript.actionText.text = "Get more green energy!";
				}
				else {
					gameScript.greenManaOne = gameScript.greenManaOne - 6;   
					gameScript.greenOne.value = (float)gameScript.greenManaOne;
					gameScript.greenManaOneText.text = "" + gameScript.greenManaOne;

					gameScript.actionText.text = "Select your target";
					grenadeStarted = true;
					gameScript.allowActions = false;
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains ("Play2"))) {
				if (gameScript.greenManaTwo < 6) {
					gameScript.actionText.text = "Get more green energy!";
				} 
				else {
					gameScript.greenManaTwo = gameScript.greenManaTwo - 6;   
					gameScript.greenTwo.value = (float)gameScript.greenManaTwo;
					gameScript.greenManaTwoText.text = "" + gameScript.greenManaTwo;

					gameScript.actionText.text = "Select your target";
					grenadeStarted = true;
					gameScript.allowActions = false;
				}
			}
		}
	}

	void TileChosen (GameObject center){

		int column = center.GetComponent<Tile> ().GetColumn ();
		int row = center.GetComponent<Tile> ().GetRow ();
		gameScript.PlaySFX("grenade");
		List <GameObject> tilesToRemove = new List<GameObject>();
		//create a 3x3 grid to explode
		for (int i = -1; i < 2; i++) {
			for (int j = -1; j < 2; j++){
				if (((column + i) >= 0) && ((column + i) < 8)){ 
					if (((row + j) >= 0) && ((row + j) < 8)) {
						tilesToRemove.Add (gameScript.tileArray [(column + i), (row + j)]);
					}
				}
			}
		}
		foreach (GameObject go in tilesToRemove) {
			gameScript.Remove (go);
		}
		grenadeStarted = false;
		StartCoroutine (gameScript.Collapse ());
	}
	public void MouseOver (string info){
		gameScript.ButtonMousedOver (info);
	}
	
	public void MouseLeave (){
		gameScript.ButtonLeft ();
	}
}
