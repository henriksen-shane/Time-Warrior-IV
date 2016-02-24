using UnityEngine;
using System.Collections;

// script attached to each tile that contains its row, column, and sprite information
public class Tile : MonoBehaviour {

	public int column = 0;
	public int row = 0;
	public bool alreadyCounted = false;
	public Material normal;
	public Material selected;

	public int GetColumn (){
		return column;
	}

	public int GetRow (){
		return row;
	}

	public void SetColumn (int tempCol){
		column = tempCol;
	}

	public void SetRow (int tempRow){
		row = tempRow;
	}

	public void Selected (){
		GetComponent<Renderer>().material = selected;
	}
	public void Deselected(){
		GetComponent<Renderer>().material = normal;
	}
}
