using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Roar : MonoBehaviour {

	public GameObject blackHex;
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
			if (gameScript.redManaOne < 8){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.redManaTwo < 8){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked () {
		//choses 3 random tiles on the grid and turns them to black
		if (gameScript.allowActions == true) {
			int tempColumn;
			int tempRow;
			int column;
			int column1 = 0;
			int column2 = 0;
			int column3 = 0;
			int row;
			int row1 = 0;
			int row2 = 0;
			int row3 = 0;
			bool acceptable = false;
			bool enoughMana = false;

			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.redManaOne < 8){
					gameScript.actionText.text = "Get more red energy!";
				}
				else {
					gameScript.redManaOne = gameScript.redManaOne - 8;   
					gameScript.redOne.value = (float)gameScript.redManaOne;
					gameScript.redManaOneText.text = "" + gameScript.redManaOne;

					enoughMana = true;
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.redManaTwo < 8){
					gameScript.actionText.text = "Get more red energy!";
				}
				else {
					gameScript.redManaTwo = gameScript.redManaTwo - 8;
					gameScript.redTwo.value = (float)gameScript.redManaTwo;
					gameScript.redManaTwoText.text = "" + gameScript.redManaTwo;

					enoughMana = true;
				}
			}


			if (enoughMana){
				gameScript.PlaySFX("roar");
				//need to generate 3 black tiles that are not in the same space 
				for (int i = 0; i < 3; i++){
					if (i == 0){
						while (acceptable == false){
							tempColumn = Random.Range(0, 8);
							tempRow = Random.Range(0,8); 
							if (gameScript.tileArray[tempColumn, tempRow].tag != "BlackTile"){
								column1 = tempColumn;
								row1= tempRow;
								acceptable = true;
							}
							else{
								acceptable = false;
							}
						}
						acceptable = false;
					}
					if (i == 1){
						while (acceptable == false){
							tempColumn = Random.Range(0, 8);
							tempRow = Random.Range(0,8);
							if (gameScript.tileArray[tempColumn, tempRow].tag != "BlackTile"){
								if ((tempColumn == column1) && (tempRow == row1)){
									acceptable = false;
								}
								else {
									column2 = tempColumn;
									row2 = tempRow;
									acceptable = true;
								}
							}
						}
						acceptable = false;
					}
					if (i == 2){
						while (acceptable == false){
							tempColumn = Random.Range(0, 8);
							tempRow = Random.Range(0,8);
							if (gameScript.tileArray[tempColumn, tempRow].tag != "BlackTile"){
								if ((tempColumn == column1) && (tempRow == row1)){
									acceptable = false;
								}
								else {
									if ((tempColumn == column2) && (tempRow == row2)){
										acceptable = false;
									}
									else {
										column3 = tempColumn;
										row3 = tempRow;
										acceptable = true;
									}
								}
							}
						}
					}
				}
				//add in black hexes
				for (int i = 0; i < 3; i++){
					if (i == 0){
						column = column1;
						row = row1;
					}
					else if (i == 1){
						column = column2;
						row = row2;
					}
					else {
						column = column3;
						row = row3;
					}
					GameObject tempObj = gameScript.tileArray[column, row];
					gameScript.tileArray[column, row] = null;
					Destroy (tempObj);
					gameScript.tileArray[column, row] = (GameObject)Instantiate(blackHex, new Vector3((float)column - 3.5F, (float)row - 3.5F, 0F), Quaternion.Euler(0, 0, 0));
					gameScript.tileArray[column, row].GetComponent<Tile>().SetColumn(column);
					gameScript.tileArray[column, row].GetComponent<Tile>().SetRow(row);
				}
			//resolve results
				if (gameScript.playerOneTurn == true){
					if (gameScript.redManaOne > 2){
						gameScript.keepTurn = true;
					}
				}
				else if (gameScript.playerTwoTurn == true){
					if (gameScript.redManaTwo > 2){
						gameScript.keepTurn = true;
					}
				}
				gameScript.CheckForMatchesAfterReplace ();
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
