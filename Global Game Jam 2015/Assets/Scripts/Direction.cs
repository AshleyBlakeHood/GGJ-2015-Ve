using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Direction : MonoBehaviour {
	private bool voteOpen = false; 	
	private int left = 0;
	private int right = 0;
	private int up = 0;
	private int count = 0;
	//Hold the votes and number of
	public GameManager gm;
	public ArrowManager arrows;

	// Use this for initialization
	void Start () {
		gm = new GameManager ();
		arrows = FindObjectOfType<ArrowManager> ();
		//Attempt to find the game manager	
		gm.currentPlayers = 4;

	}
	
	// Update is called once per frame
	void Update () {
		if (voteOpen = true) {
			if (Input.GetKeyDown (KeyCode.W)) {
				up++;
				count++;
				Debug.Log("W");
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				left++;
				count++;
				Debug.Log("A");
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				right++;
				count++;
				Debug.Log("D");
			}
			//If a vote in currently open, by selecting a direction, the player casts their vote
		}
		if (count >= gm.currentPlayers) {
			Debug.Log(gm.currentPlayers);
			tallyVotes();
			//If every player has cast a vote then
		}

	}
	public void toggleVote()
	{
		voteOpen = !voteOpen;
		//Open or close a vote
		if (voteOpen == true) {
			arrows.instantiateArrows();
		}
	}

	public void tallyVotes()
	{
		int temp;
		string name;
		if (left >= right) {
			temp = left;
			name = "Left";
		}
		else{
			temp = right;
			name = "Right";
		}
		if (temp > up) {
			Debug.Log (name);
			arrows.destroyArrows(name);
		}
		else{
			Debug.Log("Up");
			arrows.destroyArrows("Up");
		}
		//Find the direction with the highest number of votes
		clearVotes ();
	}

	public void clearVotes()
	{
		up = 0;
		left = 0;
		right = 0;
		count = 0;
		//Reset the votes
	}
}
