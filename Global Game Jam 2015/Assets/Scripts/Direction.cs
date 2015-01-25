using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class Direction : MonoBehaviour
{
	AudioSource audioSource;

	private bool voteOpen = false; 	
	private int up = 0;
	private int right = 0;
	private int down = 0;
	private int count = 0;

    int stationCount = 0;
	//Hold the votes and number of
	GameManager gm;
	ArrowManager arrows;
    StationManager sm;
	BackgroundManager backgroundManager;

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
        sm = FindObjectOfType<StationManager>();
		backgroundManager = FindObjectOfType<BackgroundManager>();
		//Attempt to find the game manager	

        directionSelection1 = DirectionSelection.Nullified;
        directionSelection2 = DirectionSelection.Nullified;
        directionSelection3 = DirectionSelection.Nullified;
        directionSelection4 = DirectionSelection.Nullified;

		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        state1 = GamePad.GetState(PlayerIndex.One);
        state2 = GamePad.GetState(PlayerIndex.Two);
        state3 = GamePad.GetState(PlayerIndex.Three);
        state4 = GamePad.GetState(PlayerIndex.Four);

        stationCount = 0;

        foreach (Station sta in sm.stations)
        {
            if (sta.IsBroken() == true)
            {
                stationCount++;

                Debug.Log(stationCount);
                
            }
        }

		if (voteOpen == true) 
        {
            Debug.Log(" station count: " + stationCount);
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
        if (stationCount == 0)
        {
            voteOpen = !voteOpen;
            //Open or close a vote
            if (voteOpen == true)
            {
                gm.runOnce = true;
                gm.fixes = 0;
                sm.allowBreaking = false;
                arrows.instantiateArrows();
            }
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

			if (up != count || up == 0)
				BreakMultipleStations (2);

			backgroundManager.FauxMoveUp ();
		}
		else
        {
			temp = down;
			name = "Down";

			if (down != count || down == 0)
				BreakMultipleStations (2);

			backgroundManager.FauxMoveDown ();
		}

		if (temp > right) 
        {
			Debug.Log (name);
			arrows.destroyArrows(name);
		}
		else
        {
			if (right != count || right == 0)
				BreakMultipleStations (2);

			Debug.Log("Right");
			arrows.destroyArrows("Right");
		}

		//Find the direction with the highest number of votes
		clearVotes ();
	}

	/// <summary>
	/// Breaks multiple stations when the players do not vote unaminously.
	/// </summary>
	/// <param name="count">Count.</param>
	private void BreakMultipleStations(int count)
	{
		if (audioSource != null)
			audioSource.Play ();

		for (int i = 0; i < count; i++)
		{
			sm.BreakUnbrokenStation ();
		}
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
