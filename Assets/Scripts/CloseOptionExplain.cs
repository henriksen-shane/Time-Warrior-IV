using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseOptionExplain : MonoBehaviour {


	public RectTransform mainPanel;
	public GameObject one;
	public GameObject two;
	public GameObject three;

	void Update (){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("arrow update");
			Clicked ();
		}
	}

	public void Clicked () {
		Color c = mainPanel.GetComponent<Image>().color;
		c.a = .39f;
		mainPanel.GetComponent<Image>().color = c;
		
		two.SetActive (true);
		three.SetActive (true);
		one.SetActive (true);
	}
}
