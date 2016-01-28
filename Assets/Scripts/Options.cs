using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	public RectTransform options;

	public void MoveToFront (){
		options.SetAsLastSibling ();
	}
}
