﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmokeBomb : MonoBehaviour {

	public Sprite greyOut;
	int player;
	private Button button;
	GameObject manage;
	GameManager gameScript;
	Color buttonGrey;
	Text buttonText;

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
			if (gameScript.purpleManaOne < 6){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.purpleManaTwo < 6){
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
				if (gameScript.purpleManaOne < 6){
					gameScript.actionText.text = "Get more purple energy!";
				}
				else {
					gameScript.purpleManaOne = gameScript.purpleManaOne - 6;   
					gameScript.purpleOne.value = (float)gameScript.purpleManaOne;
					gameScript.purpleManaOneText.text = "" + gameScript.purpleManaOne;

					gameScript.PlaySFX("smoke");
					gameScript.smokebombed2 = true;
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.purpleManaTwo < 6){
					gameScript.actionText.text = "Get more purple energy!";
				}
				else {
					gameScript.purpleManaTwo = gameScript.purpleManaTwo - 6;
					gameScript.purpleTwo.value = (float)gameScript.purpleManaTwo;
					gameScript.purpleManaTwoText.text = "" + gameScript.purpleManaTwo;

					gameScript.PlaySFX("smoke");
					gameScript.smokebombed1 = true;
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