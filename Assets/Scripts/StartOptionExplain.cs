using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartOptionExplain : MonoBehaviour {

	public RectTransform mainPanel;
	public GameObject barb;
	public GameObject one;
	public GameObject two;
	public GameObject three;

	  
	// loads the class explanations in the option menu
	public void Clicked () {
		Color c = mainPanel.GetComponent<Image>().color;
		c.a = 0;
		mainPanel.GetComponent<Image>().color = c;

		two.SetActive (false);
		three.SetActive (false);
		barb.SetActive (true);
		one.SetActive (false);
	}
}
