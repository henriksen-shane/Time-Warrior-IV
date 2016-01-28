using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShadowIndicate : MonoBehaviour {

	public Sprite smoke;
	public Image Fill;
	GameObject manage;
	GameManager gameScript;


	// Use this for initialization
	void Start () {
		manage = GameObject.Find ("GameManagerObject");
		gameScript = manage.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameScript.cloaked1){
			Fill.overrideSprite = smoke;
		}
		else{
			Fill.overrideSprite = null;
		}
	}
}
