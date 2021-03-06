﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaStorm : MonoBehaviour {

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
			if (gameScript.blueManaOne < 15){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.blueManaTwo < 15){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		}
	}

	public void Clicked (){
		// drains the users blue energy and deals that much damage
		if (gameScript.allowActions == true) {
			if ((gameScript.playerOneTurn) && (gameObject.tag.Contains("Play1"))){
				if (gameScript.blueManaOne < 15){
					gameScript.actionText.text = "Get more blue energy!";
				}
				else {
					gameScript.PlaySFX("storm");
					gameScript.damageHolder	= gameScript.damageHolder + gameScript.blueManaOne;
					gameScript.blueManaOne = 0;
					gameScript.blueOne.value = (float)gameScript.blueManaOne;
					gameScript.blueManaOneText.text = "0";
					gameScript.CheckForMatchesAfterReplace();
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.blueManaTwo < 15){
					gameScript.actionText.text = "Get more blue energy!";
				}
				else {
					gameScript.PlaySFX("storm");
					gameScript.damageHolder	= gameScript.damageHolder + gameScript.blueManaTwo;
					gameScript.blueManaTwo = 0;
					gameScript.blueTwo.value = (float)gameScript.blueManaTwo;
					gameScript.blueManaTwoText.text = "0";
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
