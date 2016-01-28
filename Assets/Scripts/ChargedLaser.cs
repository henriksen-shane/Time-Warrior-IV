using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChargedLaser : MonoBehaviour {

	RaycastHit hit;
	bool chargeStarted = false;
	public GameObject yellowStar;

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
			if (gameScript.yellowManaOne < 20){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.yellowManaTwo < 20){
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
				//Catch if they are trying to turn yellow into yellow. Otherwise get the color.
				if ((selectedTile.tag == ("YellowTile")) && (chargeStarted == true)){
					gameScript.actionText.text = "Already yellow. Select the tile color to convert";
				}
				else if ((selectedTile.tag.Contains ("Tile")) && (chargeStarted == true)){
					gameScript.actionText.text = "";
					StartCoroutine (TileChosen (selectedTile.tag));
				}
			}
		}
	}

	public void Clicked (){
		if (gameScript.allowActions == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.yellowManaOne < 20){
					gameScript.actionText.text = "Get more yellow energy!";
				}
				else {
					gameScript.yellowManaOne = gameScript.yellowManaOne - 20;   
					gameScript.yellowOne.value = (float)gameScript.yellowManaOne;
					gameScript.yellowManaOneText.text = "" + gameScript.yellowManaOne;

					gameScript.actionText.text = "Select the tile color to convert";
					chargeStarted = true;
					gameScript.allowActions = false;
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.yellowManaTwo < 20){
					gameScript.actionText.text = "Get more yellow energy!";
				}
				else {
					gameScript.yellowManaTwo = gameScript.yellowManaTwo - 20;
					gameScript.yellowTwo.value = (float)gameScript.yellowManaTwo;
					gameScript.yellowManaTwoText.text = "" + gameScript.yellowManaTwo;

					gameScript.actionText.text = "Select the tile color to convert";
					chargeStarted = true;
					gameScript.allowActions = false;
				}
			}
		}
	}

	IEnumerator TileChosen (string tagToChange){
		GameObject manage2 = GameObject.Find ("GameManagerObject");
		GameManager gameScript2 = manage2.GetComponent<GameManager> ();
		gameScript2.PlaySFX("chargeL");
		yield return new WaitForSeconds (2.2F);
		int column;
		int row;
		GameObject manage = GameObject.Find ("GameManagerObject");
		GameManager gameScript = manage.GetComponent<GameManager> ();		
		GameObject[] tilesToConvert = GameObject.FindGameObjectsWithTag(tagToChange);
		foreach (GameObject go in tilesToConvert) {
			column = go.GetComponent<Tile> ().GetColumn ();
			row = go.GetComponent<Tile> ().GetRow ();
			gameScript.tileArray[column, row] = null;
			Destroy (go);
			gameScript.tileArray[column, row] = (GameObject)Instantiate(yellowStar, new Vector3((float)column - 3.5F, (float)row - 3.5F, 0F), Quaternion.Euler(0, 0, 0));
			gameScript.tileArray[column, row].GetComponent<Tile>().SetColumn(column);
			gameScript.tileArray[column, row].GetComponent<Tile>().SetRow(row);
		}
		chargeStarted = false;
		gameScript.chargeLaserDamage = true;
		gameScript.CheckForMatchesAfterReplace ();
	}

	public void MouseOver (string info){
		gameScript.ButtonMousedOver (info);
	}
	
	public void MouseLeave (){
		gameScript.ButtonLeft ();
	}
}
