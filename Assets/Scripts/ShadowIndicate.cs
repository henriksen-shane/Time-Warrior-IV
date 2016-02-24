using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShadowIndicate : MonoBehaviour {

	public Sprite smoke;
	public Image Fill;
	GameObject manage;
	GameManager gameScript;


	void Start () {
		manage = GameObject.Find ("GameManagerObject");
		gameScript = manage.GetComponent<GameManager> ();
	}
	
	// if the player is cloaked, provides a visual effect on their purple mana to indicate it
	void Update () {
		if (gameScript.cloaked1){
			Fill.overrideSprite = smoke;
		}
		else{
			Fill.overrideSprite = null;
		}
	}
}
