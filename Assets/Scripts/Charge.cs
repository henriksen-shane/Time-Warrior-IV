﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Charge : MonoBehaviour {

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
			if (gameScript.redManaOne < 15){
				button.image.overrideSprite = greyOut;
			}
			else{
				button.image.overrideSprite = null;
			}
		} 
		else {
			if (gameScript.redManaTwo < 15){
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
				if (gameScript.redManaOne < 15){
					gameScript.actionText.text = "Get more red energy!";
				}
				else {
					gameScript.redManaOne = gameScript.redManaOne - 15;   
					gameScript.redOne.value = (float)gameScript.redManaOne;
					gameScript.redManaOneText.text = "" + gameScript.redManaOne;

					if (gameScript.charging == false){
						gameScript.PlaySFX("charge");
						gameScript.charging = true;
						gameScript.actionText.text = "Charging! Swap until you make a non black match.";
					}
					else if (gameScript.charging == true) {
						gameScript.actionText.text = "Already Charging";
					}
				}
			}
			else if ((gameScript.playerTwoTurn) && (gameObject.tag.Contains("Play2"))){
				if (gameScript.redManaTwo < 15){
					gameScript.actionText.text = "Get more red energy!";
				}
				else {
					gameScript.redManaTwo = gameScript.redManaTwo - 15;   
					gameScript.redTwo.value = (float)gameScript.redManaTwo;
					gameScript.redManaTwoText.text = "" + gameScript.redManaTwo;

					if (gameScript.charging == false){
						gameScript.PlaySFX("charge");
						gameScript.charging = true;
						gameScript.actionText.text = "Charging! Swap until you make a non black match.";
					}
					else if (gameScript.charging == true) {
						gameScript.actionText.text = "Already Charging";
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
