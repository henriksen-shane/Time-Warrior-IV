using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using System;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoBehaviour {

	public Material black;
	public Material blue;
	public Material green;
	public Material orange;
	public Material purple;
	public Material red;
	public Material yellow;
	public GameObject hex;
	public GameObject hexT;
	public GameObject tear;
	public GameObject tearT;
	public GameObject square;
	public GameObject squareT;
	public GameObject triangle;
	public GameObject triangleT;
	public GameObject circle;
	public GameObject circleT;
	public GameObject diamond;
	public GameObject diamondT;
	public GameObject star;
	public GameObject starT;
	public Button roar1;
	public Button slash1;
	public Button charge1;
	public Button smokeBomb1;
	public Button poisonDart1;
	public Button intoTheShadows1;
	public Button manaBomb1;
	public Button wildMagic1;
	public Button chaosBeam1;
	public Button fireball1;
	public Button flashFreeze1;
	public Button manaStorm1;
	public Button grappleBeam1;
	public Button jetPack1;
	public Button chargedLaser1;
	public Button grenade1;
	public Button laserSight1;
	public Button airStrike1;
	public Button empty1;
	public Button roar2;
	public Button slash2;
	public Button charge2;
	public Button smokeBomb2;
	public Button poisonDart2;
	public Button intoTheShadows2;
	public Button manaBomb2;
	public Button wildMagic2;
	public Button chaosBeam2;
	public Button fireball2;
	public Button flashFreeze2;
	public Button manaStorm2;
	public Button grappleBeam2;
	public Button jetPack2;
	public Button chargedLaser2;
	public Button grenade2;
	public Button laserSight2;
	public Button airStrike2;
	public Button empty2;
	public Button power1player1;
	public Button power2player1;
	public Button power3player1;
	public Button power1player2;
	public Button power2player2;
	public Button power3player2;

	public Text turnStartText;
	public Text actionText;
	public string textHolder;
	public Text blueManaOneText;
	public Text greenManaOneText;
	public Text orangeManaOneText;
	public Text purpleManaOneText;
	public Text redManaOneText;
	public Text yellowManaOneText;
	public Text blueManaTwoText;
	public Text greenManaTwoText;
	public Text orangeManaTwoText;
	public Text purpleManaTwoText;
	public Text redManaTwoText;
	public Text yellowManaTwoText;
	public Text player1Health;
	public Text player2Health;
	public Text laserOne;
	public Text laserTwo;
	public Text jetOne;
	public Text jetTwo;
	public Text gameEnd;
	public Text restartText;

	public GameObject red1;
	public GameObject purple1;
	public GameObject orange1;
	public GameObject blue1;
	public GameObject yellow1;
	public GameObject green1;
	public GameObject red2;
	public GameObject purple2;
	public GameObject orange2;
	public GameObject blue2;
	public GameObject yellow2;
	public GameObject green2;

	public GameObject explosion;

	public Slider blueOne;
	public Slider greenOne;
	public Slider orangeOne;
	public Slider purpleOne;
	public Slider redOne;
	public Slider yellowOne;
	public Slider blueTwo;
	public Slider greenTwo;
	public Slider orangeTwo;
	public Slider purpleTwo;
	public Slider redTwo;
	public Slider yellowTwo;

	private AudioSource source;
	public AudioClip matchRemoveSound;
	public AudioClip fire;
	public AudioClip freeze;
	public AudioClip storm;
	public AudioClip grenade;
	public AudioClip laser;
	public AudioClip strike;
	public AudioClip wild;
	public AudioClip bomb;
	public AudioClip chaos;
	public AudioClip smoke;
	public AudioClip dart;
	public AudioClip shadow;
	public AudioClip roar;
	public AudioClip slash;
	public AudioClip charge;
	public AudioClip grapple;
	public AudioClip jet;
	public AudioClip chargedL;

	public int player1HP = 50;
	public int player2HP = 50;
	public int playerOneSightedHP = 50;
	public int playerTwoSightedHP = 50;
	public int damageHolder = 0;
	public int damageOverTimeOne = 0;
	public int damageOverTimeTwo = 0;
	public int poisonOverTimeOne = 0;
	public int poisonOverTimeTwo = 0;
	public int overallScoreOne = 0;
	public int blueManaOne = 0;
	public int greenManaOne = 0;
	public int orangeManaOne = 0;
	public int purpleManaOne = 0;
	public int redManaOne = 0;
	public int yellowManaOne = 0;
	public int blueManaTwo = 0;
	public int greenManaTwo = 0;
	public int orangeManaTwo = 0;
	public int purpleManaTwo = 0;
	public int redManaTwo = 0;
	public int yellowManaTwo = 0;

	RaycastHit hit;

	public bool tileSelected = false;
	public bool initialSetUpOver = false;
	public bool playerOneTurn = true;
	public bool playerTwoTurn = false;
	public bool allowActions = true;
	public bool allowDamage1 = true;
	public bool allowDamage2 = true;
	public bool smokebombed1 = false;
	public bool smokebombed2 = false;
	public bool cloaked1 = false;
	public bool cloaked2 = false;
	public bool chargeLaserDamage = false;
	public bool stun = false;
	public bool charging = false;
	public bool matchFive = false;
	public bool matchFour = false;
	public bool keepTurn = false;
	public bool allowEdit = false;
	public bool optionsOpen = false;
	bool firstMatch;
	public bool gameOver = false;
	public int sightedOne = 1;
	public int sightedTwo = 1;


	GameObject firstTile;
	GameObject secondTile;
	public GameObject[,] tileArray = new GameObject[8,8];
	// array key [red, purple, orange, blue, yellow, green]
	public int[] player1Classes  = new int[] {0, 0, 0, 0, 0, 0,};
	public int[] player2Classes = new int[] {0, 0, 0, 0, 0, 0,};
	public int player1Class = 10;
	public int player2Class = 10;
	public int player1Attack = 1;
	public int player2Attack = 1;
	public int player1Defense = 0;
	public int player2Defense = 0;
	Vector3 p1p1 = new Vector3 (104.9f, 194f, 0f);
	Vector3 p2p1 = new Vector3 (104.9f, 149f, 0f);
	Vector3 p3p1 = new Vector3 (104.9f, 101f, 0f);
	Vector3 p1p2 = new Vector3 (-101.9f, 194f, 0f);
	Vector3 p2p2 = new Vector3 (-101.9f, 149f, 0f);
	Vector3 p3p2 = new Vector3 (-101.9f, 101f, 0f);

	public float swapSpeed;
	public Button testButton;
	public Canvas wholeCanvas;
	public GameObject optionMenu;
	public GameObject option1;
	public GameObject option2;
	public GameObject option3;
	public GameObject optionButton1;
	public GameObject optionButton2;
	public GameObject optionButton3;

	public RectTransform UItoMove;
	Options panelScript;

	public GameObject poison1;
	public GameObject poison2;
	public GameObject freeze1;
	public GameObject freeze2;
	public GameObject bleed1;
	public GameObject bleed2;

	void Start () {
		source = GetComponent<AudioSource>();
		InitializeTiles ();
		//stop playing the intro music
		Destroy (GameObject.FindWithTag ("IntroMusic"));
		firstMatch = true;
		optionMenu.SetActive (false);
	}

	void Update () {
		//options menu
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if ((!optionsOpen) && (initialSetUpOver)){
				optionsOpen = true;
				allowActions = false;
				optionMenu.SetActive (true);
				optionButton1.SetActive (true);
				optionButton2.SetActive (true);
				optionButton3.SetActive (true);
				foreach (GameObject go in tileArray){
					if (go != null){
						go.SetActive (false);
					}
				}
			}
			else if ((optionsOpen) && (initialSetUpOver)) {
				optionsOpen = false;
				allowActions = true;

				Color c = optionMenu.GetComponent<Image>().color;
				c.a = .39f;
				optionMenu.GetComponent<Image>().color = c;

				option1.SetActive (false);
				option2.SetActive (false);
				option3.SetActive (false);
				optionMenu.SetActive (false);
				foreach (GameObject go in tileArray){
					if (go != null){
						go.SetActive (true);
					}
				}
			}
		}

		//select a tile when clicked
		Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);

		if ((Input.GetButtonDown("Fire1")) && (allowActions))
		{
			if (Physics.Raycast(ray1, out hit, Mathf.Infinity))
			{
				GameObject selectedTile = hit.transform.gameObject;
				//Did they click a tile?
				if (selectedTile.tag.Contains("Tile")){
					//Is this the first tile?
					if (!tileSelected){
						firstTile = selectedTile;
						// change the color of the tile to show it is selected
						firstTile.GetComponent<Tile>().Selected();
						tileSelected = true;

					}
					//Is this the second tile?
					else if (tileSelected){
						secondTile = selectedTile;
						//Is the second tile adjacent to the first?
						if (Vector3.Distance(firstTile.transform.position, secondTile.transform.position) < 1.1F){
							secondTile.GetComponent<Tile>().Selected();
							// prevent player actions until the matches are resolved
							allowActions = false;
							StartCoroutine(SelectionMade(firstTile, secondTile));
							tileSelected = false;
						}
						else {
							//if the tiles arent next to each other, change their color back to normal.
							firstTile.GetComponent<Tile>().Deselected();
							secondTile = null;
							firstTile = selectedTile;
							firstTile.GetComponent<Tile>().Selected();
						}
					}
				}
				else{
					// if they didn't click on a second tile when the first is selected, deselects the first
					if (firstTile != null){
						firstTile.GetComponent<Tile>().Deselected();
						firstTile = null;
						tileSelected = false;
					}
				}
			}
		}

		// Restart the game
		if ((gameOver) && (Input.GetKeyDown (KeyCode.R))) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	private void InitializeTiles(){
		//initial game set up and board reset when there are no more matches
		bool tileInvalid = false; 
		List<GameObject> toDisplay = new List<GameObject> ();
		//add tiles to fade in list and tile array
		for (int columnI = 0; columnI < 8; columnI++) {
			for (int rowI = 0; rowI < 8; rowI++){
				//create tile, ensure that it wouldn't create matches out the gate, and insert into array
				do{
					var go = RandomTile();
					tileArray[columnI, rowI] = (GameObject)Instantiate(go, new Vector3((float)columnI - 3.5F, (float)rowI - 3.5F, 0F), Quaternion.Euler(0, 0, 0)); 
					tileArray[columnI, rowI].GetComponent<Tile>().SetColumn(columnI);
					tileArray[columnI, rowI].GetComponent<Tile>().SetRow(rowI);
					//Temp List is used during initial set up. if the tile chosen would make a match, it is removed and a new tile chosen.
					List<GameObject> tempList = GetMatches(tileArray[columnI, rowI]);
					if (tempList.Count >= 3){
						tileInvalid = true;
						Remove (tileArray[columnI, rowI]);
					}
					else {
						tileInvalid = false;
						toDisplay.Add(tileArray[columnI, rowI]);
					}
				}while (tileInvalid == true);

			}
		}
		initialSetUpOver = true;
		StartCoroutine (FadeIn (toDisplay));
		allowEdit = true;
	}

	//displays the explanation text for class abilities and preserves the existing text for display once the cursor leaves
	public void ButtonMousedOver (string info){
		textHolder = actionText.text;
		actionText.text = info;
	}

	//replace the power explanation text with whatever text was there before it.
	public void ButtonLeft (){
		actionText.text = textHolder;
	}

	//runs when a swap has been made
	public IEnumerator SelectionMade(GameObject tileOne, GameObject tileTwo){
		actionText.text = "";
		StartCoroutine (SwapTiles(tileOne, tileTwo));
		yield return new WaitForSeconds (1.1f);
		//need to swap in array as well
		//get column and row
		int column1 = tileOne.GetComponent<Tile> ().GetColumn ();
		int column2 = tileTwo.GetComponent<Tile> ().GetColumn ();
		int row1 = tileOne.GetComponent<Tile> ().GetRow ();
		int row2 = tileTwo.GetComponent<Tile> ().GetRow ();
		
		//make a list of all tiles to be destroyed
		List<GameObject> tilesToDestroyA = GetMatches (tileArray [column1, row1]);
		List<GameObject> tilesToDestroyB = (tilesToDestroyA.Union ((List<GameObject>)GetMatches (tileArray [column2, row2]))).ToList ();

		//Check if the swap resulted in no matches. If so, reverse it. 
		if (tilesToDestroyB.Count == 0) {
			tileOne.GetComponent<Tile>().Deselected();
			tileTwo.GetComponent<Tile>().Deselected();
			StartCoroutine (SwapTiles(tileOne, tileTwo));
			allowActions = true;
		} 

		//If it does have matches, destroy them
		else {
			source.PlayOneShot(matchRemoveSound, 1F);
			foreach (GameObject boom in tilesToDestroyB) {
				Remove (boom);
			}
			//change tiles not destroyed back to their normal appearance
			if (tileOne != null){
				tileOne.GetComponent<Tile>().Deselected();
			}
			if (tileTwo != null){
				tileTwo.GetComponent<Tile>().Deselected();
			}
			ResolveDamage();
			StartCoroutine(Collapse ());
		}
	}

	//Called whenever we need to check for a match of 3 or above
	private List<GameObject> GetMatches(GameObject go){
		List<GameObject> hozMatches = GetMatchesHorizontally (go);
		List<GameObject> vertMatches = GetMatchesVertically (go);
		List<GameObject> allMatches = hozMatches.Union(vertMatches).ToList();
		return allMatches;
	}


	private List<GameObject> GetMatchesHorizontally(GameObject go)
	{
		List<GameObject> hMatches = new List<GameObject>();
		hMatches.Add(go);
		int hRow = go.GetComponent<Tile> ().GetRow ();
		//check left
		if (go.GetComponent<Tile>().GetColumn() != 0){
			for (int column = go.GetComponent<Tile>().GetColumn() - 1; column >= 0; column--)
			{
				if ((tileArray [column, hRow] != null) && 
					(tileArray[column, hRow].tag == go.tag)) 
				{
					tileArray [column, hRow].GetComponent<Tile>().alreadyCounted = true;
					hMatches.Add(tileArray[column, hRow]);
				}
				else
					break;
			}
		}
		
		//check right
		if (go.GetComponent<Tile> ().GetColumn () != 7) {
			for (int column = go.GetComponent<Tile>().GetColumn() + 1; column < 8; column++) {
				if ((tileArray [column, hRow] != null) && 
					(tileArray [column, hRow].tag == go.tag)) 
				{
					tileArray [column, hRow].GetComponent<Tile>().alreadyCounted = true;
					hMatches.Add (tileArray [column, hRow]);
				} else
					break;
			}
		}
		// Change player class depending on tile
		if (hMatches.Count > 2) {
			//this is where we account for the player's attack and defense if this is a black match
			if (go.tag == "BlackTile"){
				if (playerOneTurn){
					damageHolder = damageHolder + (player1Attack - player2Defense);
				}
				else if (playerTwoTurn){
					damageHolder = damageHolder + (player2Attack - player1Defense);
				}
			}
			// if this is the first match of the turn, change class
			if(firstMatch){
				firstMatch = false;
				if (playerOneTurn){
					EditClass1 (go.tag);
				}
				else if (playerTwoTurn){
					EditClass2 (go.tag);
				}
			}
		}
		// different out comes depending on number of tiles matched
		if (hMatches.Count > 4) {
			matchFive = true;
		} else if (hMatches.Count == 4) {
			matchFour = true;
		} else if (hMatches.Count < 3) {
			hMatches.Clear ();
		}
		return (hMatches.Distinct()).ToList();
	}

	private List<GameObject> GetMatchesVertically(GameObject go)
	{
		List<GameObject> vMatches = new List<GameObject> ();
		vMatches.Add (go);
		int vColumn = go.GetComponent<Tile> ().GetColumn ();
		//check bottom
		if (go.GetComponent<Tile> ().GetRow () != 0)
		{
			for (int row = go.GetComponent<Tile>().GetRow() - 1; row >= 0; row--) {
				if ((tileArray[vColumn, row] != null) &&
				    (tileArray [vColumn, row].tag == go.tag)) {
					tileArray [vColumn, row].GetComponent<Tile>().alreadyCounted = true;
					vMatches.Add (tileArray [vColumn, row]);
				} else
					break;
			}	
		}

		//check top
		if (go.GetComponent<Tile> ().GetRow () != 7) {
			for (int row = go.GetComponent<Tile>().GetRow() + 1; row < 8; row++) {
				if ((tileArray [vColumn, row] != null) && 
				    (tileArray [vColumn, row].tag == go.tag)) {
					tileArray [vColumn, row].GetComponent<Tile>().alreadyCounted = true;
					vMatches.Add (tileArray [vColumn, row]);
				} else
					break;
			}
		}

		// Acccount for class attack and defense for black matches
		if (vMatches.Count > 2) {
			if (go.tag == "Black"){
				if (playerOneTurn){
					damageHolder = damageHolder + (player1Attack - player2Defense);
				}
				else if (playerTwoTurn){
					damageHolder = damageHolder + (player2Attack - player1Defense);
				}
			}
			//if this is the first match of the turn, change class.
			if(firstMatch){
				firstMatch = false;
				if (playerOneTurn){
					EditClass1 (go.tag);
				}
				else if (playerTwoTurn){
					EditClass2 (go.tag);
				}
			}
		}

		if (vMatches.Count > 4) {
			matchFive = true;
		} 
		else if (vMatches.Count == 4) {
			matchFour = true;
		}
		else if (vMatches.Count < 3) {
			vMatches.Clear ();
		}
		return (vMatches.Distinct()).ToList();
	}

	//removes tiles and gives energy or damage depending on the tile
	public void Remove(GameObject kill){
		if (initialSetUpOver == true) {
			// creates the explosion effect when a tile is removed
			Instantiate(explosion, kill.transform.position, kill.transform.rotation);
			if (playerOneTurn == true){	
				if (kill.tag != "BlackTile"){
					charging = false;
				}
				if (kill.tag == "BlackTile") {
					damageHolder++;
				} else if (kill.tag == "BlueTile") {
					if (blueManaOne < 30){
						blueManaOne++;
					}
					blueOne.value = (float)blueManaOne;
					blueManaOneText.text = "" + blueManaOne;
				} else if (kill.tag == "GreenTile") {
					if (greenManaOne < 30){
						greenManaOne++;
					}
					greenOne.value = (float)greenManaOne;
					greenManaOneText.text = "" + greenManaOne;
				} else if (kill.tag == "OrangeTile") {
					if (orangeManaOne < 30){
						orangeManaOne++;
					}
					orangeOne.value = (float)orangeManaOne;
					orangeManaOneText.text = "" + orangeManaOne;
				} else if (kill.tag == "PurpleTile") {
					if (purpleManaOne < 30){
						purpleManaOne++;
					}
					purpleOne.value = (float)purpleManaOne;
					purpleManaOneText.text = "" + purpleManaOne;
					poisonOverTimeOne = 0;
					poison1.SetActive(false); 
				} else if (kill.tag == "RedTile") {
					if (redManaOne < 30){
						redManaOne++;
					}
					redOne.value = (float)redManaOne;
					redManaOneText.text = "" + redManaOne;
				} else {
					if (yellowManaOne < 30){
						yellowManaOne++;
					}
					yellowOne.value = (float)yellowManaOne;
					yellowManaOneText.text = "" + yellowManaOne;
					// 
					if (chargeLaserDamage == true){
						damageHolder++;
					}
				}
			}
			else if (playerTwoTurn == true){
				if (kill.tag != "BlackTile"){
					charging = false;
				}

				if (kill.tag == "BlackTile") {
					damageHolder++;
				} else if (kill.tag == "BlueTile") {
					if (blueManaTwo < 30){
						blueManaTwo++;
					}
					blueTwo.value = (float)blueManaTwo;
					blueManaTwoText.text = "" + blueManaTwo;
				} else if (kill.tag == "GreenTile") {
					if (greenManaTwo < 30){
						greenManaTwo++;
					}
					greenTwo.value = (float)greenManaTwo;
					greenManaTwoText.text = "" + greenManaTwo;
				} else if (kill.tag == "OrangeTile") {
					if (orangeManaTwo < 30){
						orangeManaTwo++;
					}
					orangeTwo.value = (float)orangeManaTwo;
					orangeManaTwoText.text = "" + orangeManaTwo;
				} else if (kill.tag == "PurpleTile") {
					if (purpleManaTwo < 30){
						purpleManaTwo++;
					}
					purpleTwo.value = (float)purpleManaTwo;
					purpleManaTwoText.text = "" + purpleManaTwo;
					poisonOverTimeTwo = 0;
					poison2.SetActive(false); 
				} else if (kill.tag == "RedTile") {
					if (redManaTwo < 30) {
						redManaTwo++;
					}
					redTwo.value = (float)redManaTwo;
					redManaTwoText.text = "" + redManaTwo;
				} else {
					if (yellowManaTwo < 30){
						yellowManaTwo++;
					}
					yellowTwo.value = (float)yellowManaTwo;
					yellowManaTwoText.text = "" + yellowManaTwo;
					if (chargeLaserDamage == true){
						damageHolder++;
					}
				}
			}
			overallScoreOne++;
		}
		if (kill != null) {
			tileArray [kill.GetComponent<Tile> ().GetColumn (), kill.GetComponent<Tile> ().GetRow ()] = null;
			Destroy (kill);
		}
	}

	//make tiles fall after making a match
	public IEnumerator Collapse (){
	// Go through each column
		for (int cColumn = 0; cColumn < 8; cColumn++) {
			//Start on bottom row
			for (int cRow = 0; cRow < 8; cRow++){
				//if a tile is missing
				if (tileArray [cColumn, cRow] == null){
					//look for the first tile in the column above the missing tile that isn't missing
					for (int cRow2 = cRow + 1; cRow2 < 8; cRow2++){
						//when found, move it to empty space in array
						if (tileArray [cColumn, cRow2] != null){
							GameObject tempObj = tileArray [cColumn, cRow2];

							tileArray [cColumn, cRow] = tempObj;
							tileArray [cColumn, cRow2] = null;
							tileArray [cColumn, cRow].GetComponent<Tile> ().SetColumn (cColumn);
							tileArray [cColumn, cRow].GetComponent<Tile> ().SetRow (cRow);
													
							//Move to new position

							StartCoroutine(MoveTile(tileArray [cColumn, cRow], cColumn, cRow));
							break;
						}
						//tileArray [cColumn, cRow].transform.Translate (new Vector3 ((float)cColumn - 3.5, (float)cRow - 3.5)); 
						  
					}
				}
			}
		}
		yield return new WaitForSeconds (1);
		Replace ();
		Invoke ("CheckForMatchesAfterReplace", 1);
	}

	// Looks for missing tiles in the array and replaces them with new ones. 
	void Replace (){
		List<GameObject> toDisplay = new List<GameObject> ();
		for (int rColumn = 0; rColumn < 8; rColumn++) {
			//Start on bottom row
			for (int rRow = 0; rRow < 8; rRow++){
				//if a tile is missing
				if (tileArray [rColumn, rRow] == null){
					var go = RandomTransTile();
					
					tileArray[rColumn, rRow] = (GameObject)Instantiate(go, new Vector3((float)rColumn - 3.5F, (float)rRow - 3.5F, 0F), Quaternion.Euler(0, 0, 0)); 
					tileArray[rColumn, rRow].GetComponent<Tile>().SetColumn(rColumn);
					tileArray[rColumn, rRow].GetComponent<Tile>().SetRow(rRow);
					toDisplay.Add(tileArray[rColumn, rRow]);
				}
			}
		}
		//have new tiles fade into view
		StartCoroutine (FadeIn (toDisplay));

	}

	//reduce the tile's alpha level to create a fade effect
	IEnumerator FadeIn (List<GameObject> newTiles){
		for (float i = 0f; i <= 1f; i += 0.1f){
			foreach (GameObject tile in newTiles) {
				Color c = tile.GetComponent<MeshRenderer>().material.color;
				c.a = i;
				tile.GetComponent<MeshRenderer>().material.color = c;
			}
			yield return new WaitForSeconds(.075f);
		}
	}

	//After a collapse checks for new matches. If there are it collapses and calls itself again.
	public void CheckForMatchesAfterReplace(){
		List<GameObject> tilesToDestroy = new List<GameObject> ();
		foreach (GameObject go in tileArray){
			List<GameObject> tilesToDestroyHolder = tilesToDestroy;
			if (!go.GetComponent<Tile>().alreadyCounted){
				tilesToDestroy=(tilesToDestroyHolder.Union((List<GameObject>)GetMatches(go)).ToList());
			}
		}
		// if there aren't any matches, proceed to next turn
		if (tilesToDestroy.Count < 3){
			tilesToDestroy.Clear();
			ResolveDamage();
			ResolveTurn();
			// if a 4 or 5 of a kind match was made, don't switch to the other player.
			if ((matchFive) || (matchFour)){
				actionText.text = "Multimatch, take another turn";
				matchFive = false;
				matchFour = false;
			}
			else if (keepTurn){
				keepTurn = false;
				actionText.text = "Powerful Roar! Take another turn";
			}
			else {
				// if either player is using the charge ability and it's still on, the turn won't change. Otherwise it switches the turn.
				if (playerTwoTurn == true){
					if (charging == true){
						turnStartText.text = "Player 2 still charging";
					}
					else if (stun == true){
						turnStartText.text = "Player 2's turn again";
						stun = false;
						freeze1.SetActive(false);
					}
					else{
						playerTwoTurn = false;
						playerOneTurn = true;
						turnStartText.text = "Player 1's turn";
					}
				}
				else if (playerOneTurn == true){
					if (charging == true){
						turnStartText.text = "Player 1 still charging";
					}
					else if (stun == true){
						turnStartText.text = "Player 1's turn again";
						stun = false;
						freeze2.SetActive(false);
					}
					else {
						playerOneTurn = false;
						playerTwoTurn = true;
						turnStartText.text = "Player 2's turn";
					}
				}
			}
			allowActions = true;
		}
		// if there are matches then remove them and collapse again
		else{
			source.PlayOneShot(matchRemoveSound, 1F);
			foreach (GameObject boom in tilesToDestroy){
				Remove (boom);
			}
			ResolveDamage();
			StartCoroutine (Collapse());
		}
	}

	//check for possible matches for the next turn. 
	bool CheckForPotentialMatches (){
		bool check1 = false;
		bool check2 = false;
		bool check3 = false;
		bool check4 = false;
		bool check5 = false;
		bool check6 = false;
		foreach (GameObject go in tileArray) {
			if (CheckPotentialMatchHorizontal1 (go)){
				check1 = true;
			}
			if (CheckPotentialMatchHorizontal2 (go)){
				check2 = true;
			}
			if (CheckPotentialMatchHorizontal3 (go)){
				check3 = true;
			}
			if (CheckPotentialMatchVertical1 (go)){
				check4 = true;
			}
			if (CheckPotentialMatchVertical2 (go)){
				check5 = true;
			}
			if (CheckPotentialMatchVertical3 (go)){
				check6 = true;
			}
		}
		if ((!check1) && (!check2) && (!check3) && (!check4) && (!check5) && (!check6)) {
			return false;
		}		
		return true;
	}

	//The check potential match methods all search for different combinations of moves that could result in a match next turn.
	bool CheckPotentialMatchHorizontal1 (GameObject go){
		int row = go.GetComponent<Tile> ().GetRow ();
		int column = go.GetComponent<Tile> ().GetColumn ();

		if (column <= 6) {
			if (go.tag == tileArray[column + 1, row].tag){
				if (column >= 1 && row >= 1){
					if (go.tag == tileArray[column - 1, row - 1].tag){
						return true;
						//this is looking for a horizontal match where the partner is to the lower left
					}
				}
				if (column >= 1 && row <= 6){
					if (go.tag == tileArray[column - 1, row + 1].tag){
						return true;
						//this looks for horizontal match to the upper left
					}
				}
			}
		}
		return false;
	}

	bool CheckPotentialMatchHorizontal2 (GameObject go){
		int row = go.GetComponent<Tile> ().GetRow ();
		int column = go.GetComponent<Tile> ().GetColumn ();

		if (column <= 5) {
			if (go.tag == tileArray[column + 1, row].tag){
				if (row >= 1 && column <= 5){
					if (go.tag == tileArray[column + 2, row - 1].tag){
						return true;
						//this is looking for a horizontal match where the partner is to the lower right
					}
				}
				if (column <= 5 && row <= 6){
					if (go.tag == tileArray[column + 2, row + 1].tag){
						return true;
						//this looks for horizontal match to the upper left
					}
				}
			}
		}
		return false;
	}

	bool CheckPotentialMatchHorizontal3 (GameObject go){
		int row = go.GetComponent<Tile> ().GetRow ();
		int column = go.GetComponent<Tile> ().GetColumn ();

		if (column <= 4) {
			if ((go.tag == tileArray[column + 1, row].tag) && (go.tag == tileArray[column + 3, row].tag)){
				return true;
				//this is looking for a horizontal match where the partner is directly to the right
			}
		}
		if (column >= 2 && column <= 6){
			if ((go.tag == tileArray[column + 1, row].tag) && (go.tag == tileArray[column - 2, row].tag)){
				return true;
				//this is looking for a horizontal match where the partner is directly to the left
			}
		}
		return false;
		
	}

	bool CheckPotentialMatchVertical1 (GameObject go){
		int row = go.GetComponent<Tile> ().GetRow ();
		int column = go.GetComponent<Tile> ().GetColumn ();

		if (row <= 6) {
			if (go.tag == tileArray[column, row + 1].tag){
				if (column >=1 && row >= 1){
					if (go.tag == tileArray[column - 1, row - 1].tag){
						return true;
						//this checks for vertical match below and to the left
					}
				}
				if (column <= 6 && row >= 1){
					if (go.tag == tileArray[column + 1, row - 1].tag){
						return true;
						//this checks for vertical match below and to the left
					}
				}
			}
		}
		return false;
	} 

	bool CheckPotentialMatchVertical2 (GameObject go){
		int row = go.GetComponent<Tile> ().GetRow ();
		int column = go.GetComponent<Tile> ().GetColumn ();

		if (row <= 5) {
			if (go.tag == tileArray[column, row + 1].tag){
				if (column >= 1){
					if (go.tag == tileArray[column - 1, row + 2].tag){
						return true;
						// this checks for a vertical match above and to the left
					}
				}
				if (column <= 6){
					if (go.tag == tileArray[column + 1, row + 2].tag){
						return true;
						// this checks for a vertical match above and to the right
					}
				}
			}
		}
		return false;
	}

	bool CheckPotentialMatchVertical3 (GameObject go){
		int row = go.GetComponent<Tile> ().GetRow ();
		int column = go.GetComponent<Tile> ().GetColumn ();

		if (row <= 4) {
			if ((go.tag == tileArray[column, row + 1].tag) && (go.tag == tileArray[column, row + 3].tag)){
				return true;	
				// this checks for a verical match directly above
			}
		}
		if (row >= 2 && row <= 6){
			if ((go.tag == tileArray[column, row + 1].tag) && (go.tag == tileArray[column, row - 2].tag)){
				return true;
				// this checks for a vertical match directly below
			}
		}
		return false;
	}

	// moves the object to the column and row given
	IEnumerator MoveTile (GameObject go, int column, int row){
		float startTime = Time.time;
		Vector3 posA = go.transform.position;
		Vector3 posB = new Vector3 ((float)(column - 3.5), (float)(row - 3.5), 0f);
		while (Time.time-startTime<=1) { // until one second passed
			go.transform.position = Vector3.Lerp (posA, posB, (Time.time - startTime)); // lerp from A to B in one second
			yield return 1; 
		}
		//lerp can end the movement slightly early. This will shift the object the last bit if this happened.
		go.transform.position = posB;
	} 

	// swaps the positions of two tiles
	public IEnumerator SwapTiles (GameObject go, GameObject go2){
		float startTime = Time.time;
		Vector3 posA = go.transform.position;
		Vector3 posB = go2.transform.position;
		while (Time.time-startTime<=1) { // until one second passed
			go.transform.position = Vector3.Lerp (posA, posB, (Time.time - startTime)); // lerp from A to B in one second
			go2.transform.position = Vector3.Lerp (posB, posA, (Time.time - startTime)); // lerp from B to A in one second
			yield return 1; 
		}

		//lerp can end the movement slightly early. This will shift the objects the last bit if this happened.
		go.transform.position = posB;
		go2.transform.position = posA;

		//get column and row
		int column1 = go.GetComponent<Tile> ().GetColumn ();
		int column2 = go2.GetComponent<Tile> ().GetColumn ();
		int row1 = go.GetComponent<Tile> ().GetRow ();
		int row2 = go2.GetComponent<Tile> ().GetRow ();
		
		//swap in array
		GameObject temp = go;
		tileArray [column1, row1] = go2;
		tileArray [column2, row2] = temp; 
		
		//reassign positions to objects after swap
		tileArray [column1, row1].GetComponent<Tile> ().SetColumn (column1);
		tileArray [column1, row1].GetComponent<Tile> ().SetRow (row1);
		tileArray [column2, row2].GetComponent<Tile> ().SetColumn (column2);
		tileArray [column2, row2].GetComponent<Tile> ().SetRow (row2);
	}

	// create buttons for the various player powers
	public void CreateButton (Button buttonPrefab, Vector3 where, int powerLevel, int player){
		var button = GameObject.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
		var rectTransform = button.GetComponent<RectTransform>();
		rectTransform.position = where;
		rectTransform.SetParent(wholeCanvas.transform, false);
		if (player == 1) {
			if (powerLevel == 1) {
				Destroy (GameObject.FindWithTag ("P1Play1"));
				button.tag = "P1Play1";
			} else if (powerLevel == 2) {
				Destroy (GameObject.FindWithTag ("P2Play1"));
				button.tag = "P2Play1";
			} else if (powerLevel == 3) {
				Destroy (GameObject.FindWithTag ("P3Play1"));
				button.tag = "P3Play1";
			}
		} 
		else if (player == 2) {
			if (powerLevel == 1) {
				Destroy (GameObject.FindWithTag ("P1Play2"));
				button.tag = "P1Play2";
			} else if (powerLevel == 2) {
				Destroy (GameObject.FindWithTag ("P2Play2"));
				button.tag = "P2Play2";
			} else if (powerLevel == 3) {
				Destroy (GameObject.FindWithTag ("P3Play2"));
				button.tag = "P3Play2";
			}
		}
	}

	//returns a random tile. Used for startup.
	public GameObject RandomTile (){
		GameObject tempTile;
		// choose tile and assign
		float rand = UnityEngine.Random.Range(0.0F, 7.0F); 
		if (rand < 1){
			tempTile = hex;
		}
		else if ((rand >= 1) && (rand < 2)){
			tempTile = tear;
		}
		else if ((rand >= 2) && (rand < 3)){
			tempTile = square;
		}
		else if ((rand >= 3) && (rand < 4)){
			tempTile = triangle;
		}
		else if ((rand >= 4) && (rand < 5)){
			tempTile = circle;
		}
		else if ((rand >= 5) && (rand < 6)){
			tempTile = diamond;
		}
		else {
			tempTile = star;
		}

		return tempTile;
	}

	//returns a random transparent tile. Used for replacing destroyed tiles, which will then be faded in
	private GameObject RandomTransTile (){
		GameObject tempTransTile;
		// choose tile and assign
		float rand = UnityEngine.Random.Range(0.0F, 7.0F); 
		if (rand < 1){
			tempTransTile = hexT;
		}
		else if ((rand >= 1) && (rand < 2)){
			tempTransTile = tearT;
		}
		else if ((rand >= 2) && (rand < 3)){
			tempTransTile = squareT;
		}
		else if ((rand >= 3) && (rand < 4)){
			tempTransTile = triangleT;
		}
		else if ((rand >= 4) && (rand < 5)){
			tempTransTile = circleT;
		}
		else if ((rand >= 5) && (rand < 6)){
			tempTransTile = diamondT;
		}
		else {
			tempTransTile = starT;
		}
		return tempTransTile;
	}

	//apply any damaging effects from the turn
	void ResolveDamage (){
		// Resolve effects of turn
		if (playerOneTurn == true) {
			//if smokebomb was applied, 50% chance all damage ignored
			if (smokebombed1 && (damageHolder != 0)){
				int hitResult = UnityEngine.Random.Range(0, 2);
				if (hitResult == 0){
					actionText.text = "Smoke made your attack miss!";
					damageHolder = 0;
				}
			}

			if ((damageHolder != 0)&&(allowDamage2 == true)){
				//if a player used fade into shadows, damage is taken from purple energy rather than health
				if (cloaked2) {
					if (purpleManaTwo > (damageHolder * sightedOne)){
						purpleManaTwo = purpleManaTwo - (damageHolder * sightedOne);
					}
					else{
						player2HP = Mathf.Clamp(player2HP - ((damageHolder * sightedOne) - purpleManaTwo), 0, 50 );
						purpleManaTwo = 0;
						player2Health.text = "HP: " + player2HP;
						cloaked2 = false;
					}
					purpleTwo.value = (float)purpleManaTwo;
					purpleManaTwoText.text = "" + purpleManaTwo;
				}
				//apply damage normally
				else {
					player2HP = Mathf.Clamp(player2HP - (damageHolder * sightedOne), 0, 50);
					player2Health.text = "HP: " + player2HP;
				}
				damageHolder = 0;
				sightedOne = 1;
				laserOne.text = "";
			}
			// if the other player used jetpack, then damage is 0 this turn
			else if ((damageHolder != 0)&&(allowDamage2 == false)){
				actionText.text = "Jetpack broken";
				allowDamage2 = true;
				jetTwo.text = "";
				damageHolder = 0;
			}
		} 
		else if (playerTwoTurn == true) {
			if (smokebombed2 && (damageHolder != 0)){
				int hitResult = UnityEngine.Random.Range(0, 2);
				if (hitResult == 0){
					actionText.text = "Smoke made your attack miss!";
					damageHolder = 0;
				}

			}

			if ((damageHolder != 0)&&(allowDamage1 == true)){
				if (cloaked1) {
					if (purpleManaOne > (damageHolder * sightedTwo)){
						purpleManaOne = purpleManaOne - (damageHolder * sightedTwo);
					}
					else{
						player1HP = Mathf.Clamp(player1HP - ((damageHolder * sightedTwo) - purpleManaOne),0, 50);
						purpleManaOne = 0;
						player1Health.text = "HP: " + player1HP;
						cloaked1 = false;
					}
					purpleOne.value = (float)purpleManaOne;
					purpleManaOneText.text = "" + purpleManaOne;
				}
				else {
					player1HP = Mathf.Clamp(player1HP - (damageHolder * sightedTwo), 0, 50);
					player1Health.text = "HP: " + player1HP;
				}
				damageHolder = 0;
				sightedTwo = 1;
				laserTwo.text = "";
			}
			else if ((damageHolder != 0)&&(allowDamage1 == false)){
				actionText.text = "Jetpack broken";
				allowDamage1 = true;
				jetOne.text = "";
				damageHolder = 0;
			}
		}
		chargeLaserDamage = false;
	}

	//clean up various effects for the next turn to start
	void ResolveTurn(){
		if (playerOneTurn == true) {
			// apply bleed damage
			if (damageOverTimeOne != 0) {
				if (cloaked1){
					purpleManaOne--;
					purpleOne.value = (float)purpleManaOne;
					purpleManaOneText.text = "" + purpleManaOne;
				}
				else{
					player1HP = Mathf.Clamp (player1HP - 1,0, 50);
					player1Health.text = "HP: " + player1HP;
					damageOverTimeOne--;
				}
			}
			//if bleed is done, remove indicator
			if (damageOverTimeOne == 0){
				bleed1.SetActive(false);
			}
			// apply poison damage
			if (poisonOverTimeOne != 0){
				if (cloaked1){
					purpleManaOne = purpleManaOne - poisonOverTimeOne;
					purpleOne.value = (float)purpleManaOne;
					purpleManaOneText.text = "" + purpleManaOne;
				}
				else{
					player1HP = Mathf.Clamp (player1HP - poisonOverTimeOne, 0, 50);
					player1Health.text = "HP: " + player1HP;
				}
			}
			//smokebombs only last 1 turn
			smokebombed1 = false;
			//drain purple energy if they are using fade into shadows
			if ((cloaked1)&&(purpleManaOne > 0)){
				purpleManaOne--;
				purpleManaOneText.text = "" + purpleManaOne;
			}
			//if they have no purple energy, fade into shadows deactivates
			if ((cloaked1)&&(purpleManaOne == 0)){
				cloaked1 = false;
			}
		} 
		else if (playerTwoTurn == true) {
			if (damageOverTimeTwo != 0){
				if (cloaked2){
					purpleManaTwo--;
					purpleTwo.value = (float)purpleManaTwo;
					purpleManaTwoText.text = "" + purpleManaTwo;
				}
				else{
					player2HP = Mathf.Clamp (player2HP - 1, 0, 50);
					player2Health.text = "HP: " + player2HP;
					damageOverTimeTwo--;
				}
			}
			//if bleed is done, remove indicator
			if (damageOverTimeTwo == 0){
				bleed2.SetActive(false);
			}
			if (poisonOverTimeTwo != 0){
				if (cloaked2){
					purpleManaTwo = purpleManaTwo - poisonOverTimeTwo;
					purpleTwo.value = (float)purpleManaTwo;
					purpleManaTwoText.text = "" + purpleManaTwo;
				}
				else{
					player2HP = Mathf.Clamp (player2HP - poisonOverTimeTwo, 0, 50);
					player2Health.text = "HP: " + player2HP;
				}
			}
			smokebombed2 = false;
			if ((cloaked2)&&(purpleManaTwo > 0)){
				purpleManaTwo--;
				purpleManaTwoText.text = "" + purpleManaTwo;
			}
			
			if ((cloaked1)&&(purpleManaOne == 0)){
				cloaked2 = false;
			}
		}

		if (player1HP != playerOneSightedHP){
			sightedOne = 1;
			laserOne.text = "";
		}
		if (player2HP != playerTwoSightedHP){
			sightedTwo = 1;
			laserTwo.text = "";
		}

		//clean up explosions
		GameObject[] explosions = GameObject.FindGameObjectsWithTag ("Explosion");
		foreach (GameObject go in explosions) {
			Destroy (go);
		}

		//mark all selected flags to false
		foreach (GameObject go in tileArray) {
			go.GetComponent<Tile>().alreadyCounted = false;
		}

		//change back to normal tiles that may still be selected
		if (firstTile != null) {
			firstTile.GetComponent<Tile>().Deselected();
		}
		if (secondTile != null) {
			secondTile.GetComponent<Tile>().Deselected();
		}

		//change class powers based on matches made this turn
		ChangeButtons();

		//check for game end
		if ((player1HP == 0) || (player2HP == 0)) {
			GameOver ();
		}

		//class can be changed again
		firstMatch = true;


		//if there are no potential matches, then drop a new board
		if (!CheckForPotentialMatches ()) {
			actionText.text = "No matches available! New board.";
			foreach (GameObject go in tileArray){
				Destroy (go);
			}
			InitializeTiles ();
		}

	}

	//plays the appropriate sound effect
	public void PlaySFX (string track){
		switch (track) {
		case "fire": {
			source.PlayOneShot(fire, 1F);
			break;
		}
		case "freeze": {
			source.PlayOneShot(freeze, 1F);
			break;
		}
		case "storm": {
			source.PlayOneShot(storm, 1F);
			break;
		}
		case "grenade": {
			source.PlayOneShot(grenade, 1F);
			break;
		}
		case "laser": {
			source.PlayOneShot(laser, 1F);
			break;
		}
		case "strike": {
			source.PlayOneShot(strike, 1F);
			break;
		}
		case "wild": {
			source.PlayOneShot(wild, 1F);
			break;
		}
		case "bomb": {
			source.PlayOneShot(bomb, 1F);
			break;
		}
		case "chaos": {
			source.PlayOneShot(chaos, 1F);
			break;
		}
		case "smoke": {
			source.PlayOneShot(smoke, 1F);
			break;
		}
		case "dart": {
			source.PlayOneShot(dart, 1F);
			break;
		}
		case "shadow": {
			source.PlayOneShot(shadow, 1F);
			break;
		}
		case "roar": {
			source.PlayOneShot(roar, 1F);
			break;
		}
		case "slash": {
			source.PlayOneShot(slash, 1F);
			break;
		}
		case "charge": {
			source.PlayOneShot(charge, 1F);
			break;
		}
		case "grapple": {
			source.PlayOneShot(grapple, 1F);
			break;
		}
		case "jet": {
			source.PlayOneShot(jet, 1F);
			break;
		}
		case "chargeL": {
			source.PlayOneShot(chargedL, 1F);
			break;
		}
		}
	}

	void GameOver (){
		//disallow any new actions and don't score removed tiles
		allowActions = false;
		initialSetUpOver = false;
		foreach (GameObject go in tileArray) {
			Remove (go);
		}

		//display victory text
		if (player1HP == 0) {
			playerOneTurn = false;
			gameEnd.text = "Player 1 \n Wins!";
		}
		else if (player2HP == 0) {
			playerTwoTurn = false;
			gameEnd.text = "Player 2 \n Wins!";
		}

		restartText.text = "Press R to restart";
		gameOver = true;
	}

	//change the class for player 1 depending on the first match made this turn and their previous class
	void EditClass1 (string objTag){
	// array key [red, purple, orange, blue, yellow, green]
		if (allowEdit){	
			if (objTag == "BlueTile") {
				if (player1Class == 3){
					if (player1Classes [3] < 2){
						player1Classes = new int[] {0,0,0,2,0,0};
					}
					else if (player1Classes [3] == 2){
						player1Classes = new int[] {0,0,0,3,0,0};
					}
				}
				else if (player1Class == 2){
					if ((player1Classes [2] == 2)) {
						if (player1Classes [3] == 0){
							player1Classes [3] = player1Classes [3] + 1;
						}
						else if (player1Classes [3] == 1){
							player1Classes = new int[] {0,0,1,2,0,0};
							player1Class = 3;
						}
					}
					else if (player1Classes [2] == 1){
						if (player1Classes [3] == 0){
							player1Classes [3] = player1Classes [3] + 1;
						}
						else if (player1Classes [3] == 1){
							player1Classes = new int[] {0,0,1,2,0,0};
							player1Class = 3;
						}
					}
				}
				else if (player1Class == 4){
					if ((player1Classes [4] == 2)) {
						if (player1Classes [3] == 0){
							player1Classes [3] = player1Classes [3] + 1;
						}
						else if (player1Classes [3] == 1){
							player1Classes = new int[] {0,0,0,2,1,0};
							player1Class = 3;
						}
					}
					else if (player1Classes [4] == 1){
						if (player1Classes [3] == 0){
							player1Classes [3] = player1Classes [3] + 1;
						}
						else if (player1Classes [3] == 1){
							player1Classes = new int[] {0,0,0,2,1,0};
							player1Class = 3;
						}
					}
				}
				else{
					player1Classes = new int[] {0,0,0,1,0,0};
					player1Class = 3;
				}
			} else if (objTag == "GreenTile") {
			// array key [red, purple, orange, blue, yellow, green]
				if (player1Class == 5){
					if (player1Classes [5] < 2){
						player1Classes = new int[] {0,0,0,0,0,2};
					}
					else if (player1Classes [5] == 2){
						player1Classes = new int[] {0,0,0,0,0,3};
					}
				}
				else if (player1Class == 4){
					if ((player1Classes [4] == 2)) {
						if (player1Classes [5] == 0){
							player1Classes [5] = player1Classes [5] + 1;
						}
						else if (player1Classes [5] == 1){
							player1Classes = new int[] {0,0,0,0,1,2};
							player1Class = 5;
						}
					}
					else if (player1Classes [4] == 1){
						if (player1Classes [5] == 0){
							player1Classes [5] = player1Classes [5] + 1;
						}
						else if (player1Classes [5] == 1){
							player1Classes = new int[] {0,0,0,0,1,2};
							player1Class = 5;
						}
					}
				}
				else if (player1Class == 0){
					if ((player1Classes [0] == 2)) {
						if (player1Classes [5] == 0){
							player1Classes [5] = player1Classes [5] + 1;
						}
						else if (player1Classes [5] == 1){
							player1Classes = new int[] {1,0,0,0,0,2};
							player1Class = 5;
						}
					}
					else if (player1Classes [0] == 1){
						if (player1Classes [5] == 0){
							player1Classes [5] = player1Classes [5] + 1;
						}
						else if (player1Classes [5] == 1){
							player1Classes = new int[] {1,0,0,0,0,2};
							player1Class = 5;
						}
					}
				}
				else{
					player1Classes = new int[] {0,0,0,0,0,1};
					player1Class = 5;
				}
			} else if (objTag == "OrangeTile") {
			// array key [red, purple, orange, blue, yellow, green]
				if (player1Class == 2){
					if (player1Classes [2] < 2){
						player1Classes = new int[] {0,0,2,0,0,0};
					}
					else if (player1Classes [2] == 2){
						player1Classes = new int[] {0,0,3,0,0,0};
					}
				}
				else if (player1Class == 1){
					if ((player1Classes [1] == 2)) {
						if (player1Classes [2] == 0){
							player1Classes [2] = player1Classes [2] + 1;
						}
						else if (player1Classes [2] == 1){
							player1Classes = new int[] {0,1,2,0,0,0};
							player1Class = 2;
						}
					}
					else if (player1Classes [1] == 1){
						if (player1Classes [2] == 0){
							player1Classes [2] = player1Classes [2] + 1;
						}
						else if (player1Classes [2] == 1){
							player1Classes = new int[] {0,1,2,0,0,0};
							player1Class = 2;
						}
					}
				}
				else if (player1Class == 3){
					if ((player1Classes [3] == 2)) {
						if (player1Classes [2] == 0){
							player1Classes [2] = player1Classes [2] + 1;
						}
						else if (player1Classes [2] == 1){
							player1Classes = new int[] {0,0,2,1,0,0};
							player1Class = 2;
						}
					}
					else if (player1Classes [3] == 1){
						if (player1Classes [2] == 0){
							player1Classes [2] = player1Classes [2] + 1;
						}
						else if (player1Classes [2] == 1){
							player1Classes = new int[] {0,0,2,1,0,0};
							player1Class = 2;
						}
					}
				}
				else{
					player1Classes = new int[] {0,0,1,0,0,0};
					player1Class = 2;
				}
			} else if (objTag == "PurpleTile") {
			// array key [red, purple, orange, blue, yellow, green]
				if (player1Class == 1){
					if (player1Classes [1] < 2){
						player1Classes = new int[] {0,2,0,0,0,0};
					}
					else if (player1Classes [1] == 2){
						player1Classes = new int[] {0,3,0,0,0,0};
					}
				}
				else if (player1Class == 0){
					if ((player1Classes [0] == 2)) {
						if (player1Classes [1] == 0){
							player1Classes [1] = player1Classes [1] + 1;
						}
						else if (player1Classes [0] == 1){
							player1Classes = new int[] {1,2,0,0,0,0};
							player1Class = 1;
						}
					}
					else if (player1Classes [0] == 1){
						if (player1Classes [1] == 0){
							player1Classes [1] = player1Classes [1] + 1;
						}
						else if (player1Classes [1] == 1){
							player1Classes = new int[] {1,2,0,0,0,0};
							player1Class = 1;
						}
					}
				}
				else if (player1Class == 2){
					if ((player1Classes [2] == 2)) {
						if (player1Classes [1] == 0){
							player1Classes [1] = player1Classes [1] + 1;
						}
						else if (player1Classes [2] == 1){
							player1Classes = new int[] {0,2,1,0,0,0};
							player1Class = 1;
						}
					}
					else if (player1Classes [2] == 1){
						if (player1Classes [1] == 0){
							player1Classes [1] = player1Classes [1] + 1;
						}
						else if (player1Classes [1] == 1){
							player1Classes = new int[] {0,2,1,0,0,0};
							player1Class = 1;
						}
					}
				}
				else{
					player1Classes = new int[] {0,1,0,0,0,0};
					player1Class = 1;
				}
			} else if (objTag == "RedTile") {
			// array key [red, purple, orange, blue, yellow, green]
				if (player1Class == 0){
					if (player1Classes [0] < 2){
						player1Classes = new int[] {2,0,0,0,0,0};
					}
					else if (player1Classes [0] == 2){
						player1Classes = new int[] {3,0,0,0,0,0};
					}
				}
				else if (player1Class == 6){
					if ((player1Classes [6] == 2)) {
						if (player1Classes [0] == 0){
							player1Classes [0] = player1Classes [0] + 1;
						}
						else if (player1Classes [0] == 1){
							player1Classes = new int[] {2,0,0,0,0,1};
							player1Class = 0;
						}
					}
					else if (player1Classes [6] == 1){
						if (player1Classes [0] == 0){
							player1Classes [0] = player1Classes [0] + 1;
						}
						else if (player1Classes [0] == 1){
							player1Classes = new int[] {2,0,0,0,0,1};
							player1Class = 0;
						}
					}
				}
				else if (player1Class == 1){
					if ((player1Classes [1] == 2)) {
						if (player1Classes [0] == 0){
							player1Classes [0] = player1Classes [0] + 1;
						}
						else if (player1Classes [1] == 1){
							player1Classes = new int[] {2,1,0,0,0,0};
							player1Class = 0;
						}
					}
					else if (player1Classes [1] == 1){
						if (player1Classes [0] == 0){
							player1Classes [0] = player1Classes [0] + 1;
						}
						else if (player1Classes [0] == 1){
							player1Classes = new int[] {2,1,0,0,0,0};
							player1Class = 0;
						}
					}
				}
				else{
					player1Classes = new int[] {1,0,0,0,0,0};
					player1Class = 0;
				}	
			} else if (objTag == "YellowTile"){
			// array key [red, purple, orange, blue, yellow, green]
				if (player1Class == 4){
					if (player1Classes [4] < 2){
						player1Classes = new int[] {0,0,0,0,2,0};
					}
					else if (player1Classes [4] == 2){
						player1Classes = new int[] {0,0,0,0,3,0};
					}
				}
				else if (player1Class == 3){
					if ((player1Classes [3] == 2)) {
						if (player1Classes [4] == 0){
							player1Classes [4] = player1Classes [4] + 1;
						}
						else if (player1Classes [4] == 1){
							player1Classes = new int[] {0,0,0,1,2,0};
							player1Class = 4;
						}
					}
					else if (player1Classes [3] == 1){
						if (player1Classes [4] == 0){
							player1Classes [4] = player1Classes [4] + 1;
						}
						else if (player1Classes [4] == 1){
							player1Classes = new int[] {0,0,0,1,2,0};
							player1Class = 4;
						}
					}
				}
				else if (player1Class == 5){
					if ((player1Classes [5] == 2)) {
						if (player1Classes [4] == 0){
							player1Classes [4] = player1Classes [4] + 1;
						}
						else if (player1Classes [4] == 1){
							player1Classes = new int[] {0,0,0,0,2,1};
							player1Class = 4;
						}
					}
					else if (player1Classes [5] == 1){
						if (player1Classes [4] == 0){
							player1Classes [4] = player1Classes [4] + 1;
						}
						else if (player1Classes [4] == 1){
							player1Classes = new int[] {0,0,0,0,2,1};
							player1Class = 4;
						}
					}
				}
				else{
					player1Classes = new int[] {0,0,0,0,1,0};
					player1Class = 4;
				}
			}
			StatChange ();
			UpdateClassImage (player1Class, 1);
		}
	}

	void EditClass2 (string objTag){
		// array key [red, purple, orange, blue, yellow, green]
		if (allowEdit) {
			if (objTag == "BlueTile") {
				if (player2Class == 3) {
					if (player2Classes [3] < 2) {
						player2Classes = new int[] {0,0,0,2,0,0};
					} else if (player2Classes [3] == 2) {
						player2Classes = new int[] {0,0,0,3,0,0};
					}
				} else if (player2Class == 2) {
					if ((player2Classes [2] == 2)) {
						if (player2Classes [3] == 0) {
							player2Classes [3] = player2Classes [3] + 1;
						} else if (player2Classes [3] == 1) {
							player2Classes = new int[] {0,0,1,2,0,0};
							player2Class = 3;
						}
					} else if (player2Classes [2] == 1) {
						if (player2Classes [3] == 0) {
							player2Classes [3] = player2Classes [3] + 1;
						} else if (player2Classes [3] == 1) {
							player2Classes = new int[] {0,0,1,2,0,0};
							player2Class = 3;
						}
					}
				} else if (player2Class == 4) {
					if ((player2Classes [4] == 2)) {
						if (player2Classes [3] == 0) {
							player2Classes [3] = player2Classes [3] + 1;
						} else if (player2Classes [3] == 1) {
							player2Classes = new int[] {0,0,0,2,1,0};
							player2Class = 3;
						}
					} else if (player2Classes [4] == 1) {
						if (player2Classes [3] == 0) {
							player2Classes [3] = player2Classes [3] + 1;
						} else if (player2Classes [3] == 1) {
							player2Classes = new int[] {0,0,0,2,1,0};
							player2Class = 3;
						}
					}
				} else {
					player2Classes = new int[] {0,0,0,1,0,0};
					player2Class = 3;
				}
			} else if (objTag == "GreenTile") {
				// array key [red, purple, orange, blue, yellow, green]
				if (player2Class == 5) {
					if (player2Classes [5] < 2) {
						player2Classes = new int[] {0,0,0,0,0,2};
					} else if (player2Classes [5] == 2) {
						player2Classes = new int[] {0,0,0,0,0,3};
					}
				} else if (player2Class == 4) {
					if ((player2Classes [4] == 2)) {
						if (player2Classes [5] == 0) {
							player2Classes [5] = player2Classes [5] + 1;
						} else if (player2Classes [5] == 1) {
							player2Classes = new int[] {0,0,0,0,1,2};
							player2Class = 5;
						}
					} else if (player2Classes [4] == 1) {
						if (player2Classes [5] == 0) {
							player2Classes [5] = player2Classes [5] + 1;
						} else if (player2Classes [5] == 1) {
							player2Classes = new int[] {0,0,0,0,1,2};
							player2Class = 5;
						}
					}
				} else if (player2Class == 0) {
					if ((player2Classes [0] == 2)) {
						if (player2Classes [5] == 0) {
							player2Classes [5] = player2Classes [5] + 1;
						} else if (player2Classes [5] == 1) {
							player2Classes = new int[] {1,0,0,0,0,2};
							player2Class = 5;
						}
					} else if (player2Classes [0] == 1) {
						if (player2Classes [5] == 0) {
							player2Classes [5] = player2Classes [5] + 1;
						} else if (player2Classes [5] == 1) {
							player2Classes = new int[] {1,0,0,0,0,2};
							player2Class = 5;
						}
					}
				} else {
					player2Classes = new int[] {0,0,0,0,0,1};
					player2Class = 5;
				}
			} else if (objTag == "OrangeTile") {
				// array key [red, purple, orange, blue, yellow, green]
				if (player2Class == 2) {
					if (player2Classes [2] < 2) {
						player2Classes = new int[] {0,0,2,0,0,0};
					} else if (player2Classes [2] == 2) {
						player2Classes = new int[] {0,0,3,0,0,0};
					}
				} else if (player2Class == 1) {
					if ((player2Classes [1] == 2)) {
						if (player2Classes [2] == 0) {
							player2Classes [2] = player2Classes [2] + 1;
						} else if (player2Classes [2] == 1) {
							player2Classes = new int[] {0,1,2,0,0,0};
							player2Class = 2;
						}
					} else if (player2Classes [1] == 1) {
						if (player2Classes [2] == 0) {
							player2Classes [2] = player2Classes [2] + 1;
						} else if (player2Classes [2] == 1) {
							player2Classes = new int[] {0,1,2,0,0,0};
							player2Class = 2;
						}
					}
				} else if (player2Class == 3) {
					if ((player2Classes [3] == 2)) {
						if (player2Classes [2] == 0) {
							player2Classes [2] = player2Classes [2] + 1;
						} else if (player2Classes [2] == 1) {
							player2Classes = new int[] {0,0,2,1,0,0};
							player2Class = 2;
						}
					} else if (player2Classes [3] == 1) {
						if (player2Classes [2] == 0) {
							player2Classes [2] = player2Classes [2] + 1;
						} else if (player2Classes [2] == 1) {
							player2Classes = new int[] {0,0,2,1,0,0};
							player2Class = 2;
						}
					}
				} else {
					player2Classes = new int[] {0,0,1,0,0,0};
					player2Class = 2;
				}
			} else if (objTag == "PurpleTile") {
				// array key [red, purple, orange, blue, yellow, green]
				if (player2Class == 1) {
					if (player2Classes [1] < 2) {
						player2Classes = new int[] {0,2,0,0,0,0};
					} else if (player2Classes [1] == 2) {
						player2Classes = new int[] {0,3,0,0,0,0};
					}
				} else if (player2Class == 0) {
					if ((player2Classes [0] == 2)) {
						if (player2Classes [1] == 0) {
							player2Classes [1] = player2Classes [1] + 1;
						} else if (player2Classes [0] == 1) {
							player2Classes = new int[] {1,2,0,0,0,0};
							player2Class = 1;
						}
					} else if (player2Classes [0] == 1) {
						if (player2Classes [1] == 0) {
							player2Classes [1] = player2Classes [1] + 1;
						} else if (player2Classes [1] == 1) {
							player2Classes = new int[] {1,2,0,0,0,0};
							player2Class = 1;
						}
					}
				} else if (player2Class == 2) {
					if ((player2Classes [2] == 2)) {
						if (player2Classes [1] == 0) {
							player2Classes [1] = player2Classes [1] + 1;
						} else if (player2Classes [2] == 1) {
							player2Classes = new int[] {0,2,1,0,0,0};
							player2Class = 1;
						}
					} else if (player2Classes [2] == 1) {
						if (player2Classes [1] == 0) {
							player2Classes [1] = player2Classes [1] + 1;
						} else if (player2Classes [1] == 1) {
							player2Classes = new int[] {0,2,1,0,0,0};
							player2Class = 1;
						}
					}
				} else {
					player2Classes = new int[] {0,1,0,0,0,0};
					player2Class = 1;
				}
			} else if (objTag == "RedTile") {
				// array key [red, purple, orange, blue, yellow, green]
				if (player2Class == 0) {
					if (player2Classes [0] < 2) {
						player2Classes = new int[] {2,0,0,0,0,0};
					} else if (player2Classes [0] == 2) {
						player2Classes = new int[] {3,0,0,0,0,0};
					}
				} else if (player2Class == 6) {
					if ((player2Classes [6] == 2)) {
						if (player2Classes [0] == 0) {
							player2Classes [0] = player2Classes [0] + 1;
						} else if (player2Classes [0] == 1) {
							player2Classes = new int[] {2,0,0,0,0,1};
							player2Class = 0;
						}
					} else if (player2Classes [6] == 1) {
						if (player2Classes [0] == 0) {
							player2Classes [0] = player2Classes [0] + 1;
						} else if (player2Classes [0] == 1) {
							player2Classes = new int[] {2,0,0,0,0,1};
							player2Class = 0;
						}
					}
				} else if (player2Class == 1) {
					if ((player2Classes [1] == 2)) {
						if (player2Classes [0] == 0) {
							player2Classes [0] = player2Classes [0] + 1;
						} else if (player2Classes [1] == 1) {
							player2Classes = new int[] {2,1,0,0,0,0};
							player2Class = 0;
						}
					} else if (player2Classes [1] == 1) {
						if (player2Classes [0] == 0) {
							player2Classes [0] = player2Classes [0] + 1;
						} else if (player2Classes [0] == 1) {
							player2Classes = new int[] {2,1,0,0,0,0};
							player2Class = 0;
						}
					}
				} else {
					player2Classes = new int[] {1,0,0,0,0,0};
					player2Class = 0;
				}	
			} else if (objTag == "YellowTile") {
				// array key [red, purple, orange, blue, yellow, green]
				if (player2Class == 4) {
					if (player2Classes [4] < 2) {
						player2Classes = new int[] {0,0,0,0,2,0};
					} else if (player2Classes [4] == 2) {
						player2Classes = new int[] {0,0,0,0,3,0};
					}
				} else if (player2Class == 3) {
					if ((player2Classes [3] == 2)) {
						if (player2Classes [4] == 0) {
							player2Classes [4] = player2Classes [4] + 1;
						} else if (player2Classes [4] == 1) {
							player2Classes = new int[] {0,0,0,1,2,0};
							player2Class = 4;
						}
					} else if (player2Classes [3] == 1) {
						if (player2Classes [4] == 0) {
							player2Classes [4] = player2Classes [4] + 1;
						} else if (player2Classes [4] == 1) {
							player2Classes = new int[] {0,0,0,1,2,0};
							player2Class = 4;
						}
					}
				} else if (player2Class == 5) {
					if ((player2Classes [5] == 2)) {
						if (player2Classes [4] == 0) {
							player2Classes [4] = player2Classes [4] + 1;
						} else if (player2Classes [4] == 1) {
							player2Classes = new int[] {0,0,0,0,2,1};
							player2Class = 4;
						}
					} else if (player2Classes [5] == 1) {
						if (player2Classes [4] == 0) {
							player2Classes [4] = player2Classes [4] + 1;
						} else if (player2Classes [4] == 1) {
							player2Classes = new int[] {0,0,0,0,2,1};
							player2Class = 4;
						}
					}
				} else {
					player2Classes = new int[] {0,0,0,0,1,0};
					player2Class = 4;
				}
			}
			StatChange ();
			UpdateClassImage (player2Class, 2);
		}
	}

	//change the class image based on what the new class is
	public void UpdateClassImage (int playerClass, int player){
		if (player == 1) {
			if (GameObject.FindWithTag ("ClassImage1") != null){
				GameObject.FindWithTag ("ClassImage1").SetActive(false);
			}

			switch (playerClass) {
				case 0: {
					red1.SetActive(true);
					red1.tag = "ClassImage1";
				break;
				}
				case 1: {
					purple1.SetActive(true);
					purple1.tag = "ClassImage1";
				break;
				}
				case 2: {
					orange1.SetActive(true);
					orange1.tag = "ClassImage1";
				break;
				}
				case 3: {
					blue1.SetActive(true);
					blue1.tag = "ClassImage1";
				break;
				}
				case 4: {
					yellow1.SetActive(true);
					yellow1.tag = "ClassImage1";
				break;
				}
				case 5: {
					green1.SetActive(true);
					green1.tag = "ClassImage1";
				break;
				}
			}
		} 
		else if (player == 2) {
			if (GameObject.FindWithTag ("ClassImage2") != null){
				GameObject.FindWithTag ("ClassImage2").SetActive(false);
				//GameObject.FindWithTag ("ClassImage2").tag = "Untagged";
			}
			switch (playerClass) {
				case 0: {
					red2.SetActive(true);
					red2.tag = "ClassImage2";
				break;
				}
				case 1: {
					purple2.SetActive(true);
					purple2.tag = "ClassImage2";
				break;
				}
				case 2: {
					orange2.SetActive(true);
					orange2.tag = "ClassImage2";
				break;
				}
				case 3: {
					blue2.SetActive(true);
					blue2.tag = "ClassImage2";
				break;
				}
				case 4: {
					yellow2.SetActive(true);
					yellow2.tag = "ClassImage2";
				break;
				}
				case 5: {
					green2.SetActive(true);
					green2.tag = "ClassImage2";
				break;
				}
			}
		}
	}

	//update the player's attack and defense stats once their class has changed
	void StatChange () {
		if (playerOneTurn) {
			if (player1Class == 0){
				player1Attack = 3;
				player1Defense = 1;
			}
			else if (player1Class == 1){
				player1Attack = 3;
				player1Defense = -2;
			}
			else if ((player1Class == 2)||(player1Class == 5)){
				player1Attack = 1;
				player1Defense = 0;
			}
			else if (player1Class == 3){
				player1Attack = -1;
				player1Defense = -2;
			}
			else if (player1Class == 4){
				player1Attack = 1;
				player1Defense = 1;
			}
		}
		else if (playerTwoTurn) {
			if (player2Class == 0){
				player2Attack = 3;
				player2Defense = 1;
			}
			else if (player2Class == 1){
				player2Attack = 3;
				player2Defense = -2;
			}
			else if ((player2Class == 2)||(player2Class == 5)){
				player2Attack = 1;
				player2Defense = 0;
			}
			else if (player2Class == 3){
				player2Attack = -1;
				player2Defense = -2;
			}
			else if (player2Class == 4){
				player2Attack = 1;
				player2Defense = 1;
			}
		}
	}

	//change class powers after a class change
	void ChangeButtons () {
		if ((playerOneTurn) && (player1Class != 10)) {	
			if (player1Classes [player1Class] == 3) {
				switch (player1Class) {
				case 0:
					{
						CreateButton (roar1,p1p1,1,1);
						CreateButton (slash1,p2p1,2,1);
						CreateButton (charge1,p3p1,3,1);
						break;
					}
				case 1:
					{
						CreateButton (smokeBomb1,p1p1,1,1);
						CreateButton (poisonDart1,p2p1,2,1);
						CreateButton (intoTheShadows1,p3p1,3,1);
						break;
					}
				case 2:
					{
						CreateButton (wildMagic1,p1p1,1,1);
						CreateButton (manaBomb1,p2p1,2,1);
						CreateButton (chaosBeam1,p3p1,3,1);
						break;
					}
				case 3:
					{
						CreateButton (fireball1,p1p1,1,1);
						CreateButton (flashFreeze1,p2p1,2,1);
						CreateButton (manaStorm1,p3p1,3,1);
						break;
					}
				case 4:
					{
						CreateButton (grappleBeam1,p1p1,1,1);
						CreateButton (jetPack1,p2p1,2,1);
						CreateButton (chargedLaser1,p3p1,3,1);
						break;
					}
				case 5:
					{
						CreateButton (grenade1,p1p1,1,1);
						CreateButton (laserSight1,p2p1,2,1);
						CreateButton (airStrike1,p3p1,3,1);
						break;
					}
				}
			} else if (player1Classes [player1Class] == 2) {
				int secondClass = Array.IndexOf (player1Classes, 1);
				switch (player1Class) {
				case 0:
					{
						CreateButton (roar1,p1p1,1,1);
						CreateButton (slash1,p2p1,2,1);
						if (secondClass == -1) {
							CreateButton (empty1,p3p1,3,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p1,3,1);
						}
						break;
					}
				case 1:
					{
						CreateButton (smokeBomb1,p1p1,1,1);
						CreateButton (poisonDart1,p2p1,2,1);
						if (secondClass == -1) {
							CreateButton (empty1,p3p1,3,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p1,3,1);
						}
						break;
					}
				case 2:
					{
						CreateButton (wildMagic1,p1p1,1,1);
						CreateButton (manaBomb1,p2p1,2,1);
						if (secondClass == -1) {
							CreateButton (empty1,p3p1,3,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p1,3,1);
						}
						break;
					}
				case 3:
					{
						CreateButton (fireball1,p1p1,1,1);
						CreateButton (flashFreeze1,p2p1,2,1);
						if (secondClass == -1) {
							CreateButton (empty1,p3p1,3,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p1,3,1);
						}
						break;
					}
				case 4:
					{
						CreateButton (grappleBeam1,p1p1,1,1);
						CreateButton (jetPack1,p2p1,2,1);
						if (secondClass == -1) {
							CreateButton (empty1,p3p1,3,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p1,3,1);
						}
						break;
					}
				case 5:
					{
						CreateButton (grenade1,p1p1,1,1);
						CreateButton (laserSight1,p2p1,2,1);
						if (secondClass == -1) {
							CreateButton (empty1,p3p1,3,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p1,3,1); 
						}
						break;
					}
				}
			} else if (player1Classes [player1Class] == 1) {
				//set secondClass to a dummy value
				int secondClass = 10;
				// if there is a second class, change secondClass from the dummy
				for (int i = 0; i < 6; i++) {
					if ((player1Classes [i] == 1) && (i != player1Class)) {
						secondClass = i;
					}
				}
				CreateButton (empty1,p3p1,3,1);
				switch (player1Class) {
				case 0:
					{
						CreateButton (roar1,p1p1,1,1);
						if (secondClass == 10) {
							CreateButton (empty1,p2p1,2,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p1,2,1);
						}
						break;
					}
				case 1:
					{
						CreateButton (smokeBomb1,p1p1,1,1);
						if (secondClass == 10) {
							CreateButton (empty1,p2p1,2,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p1,2,1);
						}
						break;
					}
				case 2:
					{
						CreateButton (wildMagic1,p1p1,1,1);
						if (secondClass == 10) {
							CreateButton (empty1,p2p1,2,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p1,2,1);
						}
						break;
					}
				case 3:
					{
						CreateButton (fireball1,p1p1,1,1);
						if (secondClass == 10) {
							CreateButton (empty1,p2p1,2,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p1,2,1);
						}
						break;
					}
				case 4:
					{
						CreateButton (grappleBeam1,p1p1,1,1);
						if (secondClass == 10) {
							CreateButton (empty1,p2p1,2,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p1,2,1);
						}
						break;
					}
				case 5:
					{
						CreateButton (grenade1,p1p1,1,1);
						if (secondClass == 10) {
							CreateButton (empty1,p2p1,2,1);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p1,2,1);
						}
						break;
					}
				}
			} else {
				CreateButton (empty1,p1p1,1,1);
				CreateButton (empty1,p2p1,2,1);
				CreateButton (empty1,p3p1,3,1);
			}


		}
		// do the same for player 2
		else if ((playerTwoTurn) && (player2Class != 10)) {	
			if (player2Classes [player2Class] == 3) {
				switch (player2Class) {
				case 0:
					{
						CreateButton (roar2,p1p2,1,2);
						CreateButton (slash2,p2p2,2,2);
						CreateButton (charge2,p3p2,3,2);
						break;
					}
				case 1:
					{
						CreateButton (smokeBomb2,p1p2,1,2);
						CreateButton (poisonDart2,p2p2,2,2);
						CreateButton (intoTheShadows2,p3p2,3,2);
						break;
					}
				case 2:
					{
						CreateButton (wildMagic2,p1p2,1,2);
						CreateButton (manaBomb2,p2p2,2,2);
						CreateButton (chaosBeam2,p3p2,3,2);
						break;
					}
				case 3:
					{
						CreateButton (fireball2,p1p2,1,2);
						CreateButton (flashFreeze2,p2p2,2,2);
						CreateButton (manaStorm2,p3p2,3,2);
						break;
					}
				case 4:
					{
						CreateButton (grappleBeam2,p1p2,1,2);
						CreateButton (jetPack2,p2p2,2,2);
						CreateButton (chargedLaser2,p3p2,3,2);
						break;
					}
				case 5:
					{
						CreateButton (grenade2,p1p2,1,2);
						CreateButton (laserSight2,p2p2,2,2);
						CreateButton (airStrike2,p3p2,3,2);
						break;
					}
				}
			} else if (player2Classes [player2Class] == 2) {
				int secondClass = Array.IndexOf (player2Classes, 1);
				switch (player2Class) {
				case 0:
					{
						CreateButton (roar2,p1p2,1,2);
						CreateButton (slash2,p2p2,2,2);
						if (secondClass == -1) {
							CreateButton (empty2,p3p2,3,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p2,3,2);
						}
						break;
					}
				case 1:
					{
						CreateButton (smokeBomb2,p1p2,1,2);
						CreateButton (poisonDart2,p2p2,2,2);
						if (secondClass == -1) {
							CreateButton (empty2,p3p2,3,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p2,3,2);
						}
						break;
					}
				case 2:
					{
						CreateButton (wildMagic2,p1p2,1,2);
						CreateButton (manaBomb2,p2p2,2,2);
						if (secondClass == -1) {
							CreateButton (empty2,p3p2,3,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p2,3,2);
						}
						break;
					}
				case 3:
					{
						CreateButton (fireball2,p1p2,1,2);
						CreateButton (flashFreeze2,p2p2,2,2);
						if (secondClass == -1) {
							CreateButton (empty2,p3p2,3,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p2,3,2);
						}
						break;
					}
				case 4:
					{
						CreateButton (grappleBeam2,p1p2,1,2);
						CreateButton (jetPack2,p2p2,2,2);
						if (secondClass == -1) {
							CreateButton (empty2,p3p2,3,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p2,3,2);
						}
						break;
					}
				case 5:
					{
						CreateButton (grenade2,p1p2,1,2);
						CreateButton (laserSight2,p2p2,2,2);
						if (secondClass == -1) {
							CreateButton (empty2,p3p2,3,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p3p2,3,2); 
						}
						break;
					}
				}
			} else if (player2Classes [player2Class] == 1) {
				int secondClass = 10;
				for (int i = 0; i < 6; i++) {
					if ((player2Classes [i] == 1) && (i != player2Class)) {
						secondClass = i;
					}
				}
				CreateButton (empty2,p3p2,3,2);
				switch (player2Class) {
				case 0:
					{
						CreateButton (roar2,p1p2,1,2);
						if (secondClass == 10) {
							CreateButton (empty2,p2p2,2,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p2,2,2);
						}
						break;
					}
				case 1:
					{
						CreateButton (smokeBomb2,p1p2,1,2);
						if (secondClass == 10) {
							CreateButton (empty2,p2p2,2,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p2,2,2);
						}
						break;
					}
				case 2:
					{
						CreateButton (wildMagic2,p1p2,1,2);
						if (secondClass == 10) {
							CreateButton (empty2,p2p2,2,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p2,2,2);
						}
						break;
					}
				case 3:
					{
						CreateButton (fireball2,p1p2,1,2);
						if (secondClass == 10) {
							CreateButton (empty2,p2p2,2,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p2,2,2);
						}
						break;
					}
				case 4:
					{
						CreateButton (grappleBeam2,p1p2,1,2);
						if (secondClass == 10) {
							CreateButton (empty2,p2p2,2,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p2,2,2);
						}
						break;
					}
				case 5:
					{
						CreateButton (grenade2,p1p2,1,2);
						if (secondClass == 10) {
							CreateButton (empty2,p2p2,2,2);
						} else {
							CreateButton (SecondaryPower (secondClass),p2p2,2,2);
						}
						break;
					}
				}
			} 
			else {
				CreateButton (empty2,p1p2,1,2);
				CreateButton (empty2,p2p2,2,2);
				CreateButton (empty2,p3p2,3,2);
			}
		}
	}

	//grant a secondary power if the player made a match for a complementary class
	Button SecondaryPower (int c){
		if (playerOneTurn) {
			switch (c) {
			case 0:
				{
					return roar1;
				}
			case 1:
				{
					return smokeBomb1;
				}
			case 2:
				{
					return wildMagic1;
				}
			case 3:
				{
					return fireball1;
				}
			case 4:
				{
					return grappleBeam1;
				}
			case 5:
				{
					return grenade1;
				}
			default:
				{
					return chargedLaser1;
				}
			}
		} else if (playerTwoTurn) {
			switch (c) {
			case 0:
				{
					return roar2;
				}
			case 1:
				{
					return smokeBomb2;
				}
			case 2:
				{
					return wildMagic2;
				}
			case 3:
				{
					return fireball2;
				}
			case 4:
				{
					return grappleBeam2;
				}
			case 5:
				{
					return grenade2;
				}
			default:
				{
					return chargedLaser2;
				}
			}
		} else {
			return empty1;
		}
	}

}
