﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class Direction : MonoBehaviour {
	private bool voteOpen = false; 	
	private int up = 0;
	private int right = 0;
	private int down = 0;
	private int count = 0;
	//Hold the votes and number of
	public GameManager gm;
	public ArrowManager arrows;

    GamePadState state1;
    GamePadState state2;
    GamePadState state3;
    GamePadState state4;

    enum DirectionSelection { Up, Right, Down, Nullified };

    DirectionSelection directionSelection1;
    DirectionSelection directionSelection2;
    DirectionSelection directionSelection3;
    DirectionSelection directionSelection4;

    bool runOnce = false;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
		arrows = FindObjectOfType<ArrowManager> ();
		//Attempt to find the game manager	

        directionSelection1 = DirectionSelection.Nullified;
        directionSelection2 = DirectionSelection.Nullified;
        directionSelection3 = DirectionSelection.Nullified;
        directionSelection4 = DirectionSelection.Nullified;

	}
	
	// Update is called once per frame
	void Update () 
    {
        state1 = GamePad.GetState(PlayerIndex.One);
        state2 = GamePad.GetState(PlayerIndex.Two);
        state3 = GamePad.GetState(PlayerIndex.Three);
        state4 = GamePad.GetState(PlayerIndex.Four);

		if (voteOpen == true) {
            // Controller One
            if (state1.DPad.Up == ButtonState.Pressed && directionSelection1 == DirectionSelection.Nullified)
            {
                directionSelection1 = DirectionSelection.Up;
                up++;
                count++;
                Debug.Log("Up");
            }
            if (state1.DPad.Right == ButtonState.Pressed && directionSelection1 == DirectionSelection.Nullified)
            {
                directionSelection1 = DirectionSelection.Right;
                right++;
                count++;
                Debug.Log("Right");
            }
            if (state1.DPad.Down == ButtonState.Pressed && directionSelection1 == DirectionSelection.Nullified)
            {
                directionSelection1 = DirectionSelection.Down;
                down++;
                count++;
                Debug.Log("Down");
            }

            // Controller Two
            if (state2.DPad.Up == ButtonState.Pressed && directionSelection2 == DirectionSelection.Nullified)
            {
                directionSelection2 = DirectionSelection.Up;
                up++;
                count++;
            }
            if (state2.DPad.Right == ButtonState.Pressed && directionSelection2 == DirectionSelection.Nullified)
            {
                directionSelection2 = DirectionSelection.Right;
                right++;
                count++;
            }
            if (state2.DPad.Down == ButtonState.Pressed && directionSelection2 == DirectionSelection.Nullified)
            {
                directionSelection2 = DirectionSelection.Down;
                down++;
                count++;
            }

            // Controller Three
            if (state3.DPad.Up == ButtonState.Pressed && directionSelection3 == DirectionSelection.Nullified)
            {
                directionSelection3 = DirectionSelection.Up;
                up++;
                count++;
            }
            if (state3.DPad.Right == ButtonState.Pressed && directionSelection3 == DirectionSelection.Nullified)
            {
                directionSelection3 = DirectionSelection.Right;
                right++;
                count++;
            }
            if (state3.DPad.Down == ButtonState.Pressed && directionSelection3 == DirectionSelection.Nullified)
            {
                directionSelection3 = DirectionSelection.Down;
                down++;
                count++;
            }

            // Controller Four
            if (state4.DPad.Up == ButtonState.Pressed && directionSelection4 == DirectionSelection.Nullified)
            {
                directionSelection4 = DirectionSelection.Up;
                up++;
                count++;
            }
            if (state4.DPad.Right == ButtonState.Pressed && directionSelection4 == DirectionSelection.Nullified)
            {
                directionSelection4 = DirectionSelection.Right;
                right++;
                count++;
            }
            if (state4.DPad.Down == ButtonState.Pressed && directionSelection4 == DirectionSelection.Nullified)
            {
                directionSelection4 = DirectionSelection.Down;
                down++;
                count++;
            }

            //if (Input.GetKeyDown (KeyCode.W)) {
            //    up++;
            //    count++;
            //    Debug.Log("W");
            //}
            //if (Input.GetKeyDown (KeyCode.A)) {
            //    left++;
            //    count++;
            //    Debug.Log("A");
            //}
            //if (Input.GetKeyDown (KeyCode.D)) {
            //    right++;
            //    count++;
            //    Debug.Log("D");
            //}
			//If a vote in currently open, by selecting a direction, the player casts their vote

            if (count >= gm.currentPlayers)
            {
                //Debug.Log(gm.currentPlayers);
                tallyVotes();
                //If every player has cast a vote then
            }
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
		if (up >= down) 
        {
			temp = up;
			name = "up";
		}
		else
        {
			temp = down;
			name = "Down";
		}

		if (temp > right) 
        {
			Debug.Log (name);
			arrows.destroyArrows(name);
		}
		else
        {
			Debug.Log("Right");
			arrows.destroyArrows("Right");
		}
		//Find the direction with the highest number of votes
		clearVotes ();
	}

	public void clearVotes()
	{
        //if (runOnce == false)
        //{
            up = 0;
            right = 0;
            down = 0;
            count = 0;

            directionSelection1 = DirectionSelection.Nullified;
            directionSelection2 = DirectionSelection.Nullified;
            directionSelection3 = DirectionSelection.Nullified;
            directionSelection4 = DirectionSelection.Nullified;
            runOnce = true;

            toggleVote();
            //Reset the votes
        //}
	}
}
