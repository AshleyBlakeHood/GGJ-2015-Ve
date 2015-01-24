using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using System;

public class sequence : MonoBehaviour {

    sequenceManager sm;

    public int[] sequenceI;

    int playerLoc = 0;
    public int controller = 1, length;

    GamePadState state;

    bool downA, downB, downX, downY, downLS, downRS, runOnce = false;

	// Use this for initialization
	void Start () 
    {
        sm = GameObject.FindObjectOfType<sequenceManager>();

        sm.sequences.Add(this);
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Checking which state the controller is depending on which character the script is attached to
        if (controller == 1)
            state = GamePad.GetState(PlayerIndex.One);
        if (controller == 2)
            state = GamePad.GetState(PlayerIndex.Two);
        if (controller == 3)
            state = GamePad.GetState(PlayerIndex.Three);
        if (controller == 4)
            state = GamePad.GetState(PlayerIndex.Four);

        if (sequenceI.Length != 0)
        {

            if (state.Buttons.A == ButtonState.Pressed) // Checking for A depressed
            {
                if (downA == false) // Makes sure only ran once while the button is depressed
                {
                    if (sequenceI[playerLoc] == 0) // If button pressed equals the current button in the sequence
                    { // Correct Button
                        playerLoc++; // Moves the sequence along.

                        Debug.Log("A0");
                    }
                    else
                    { // Incorrect Button
                        playerLoc = 0; // Resetting the players location in the sequence
                        //Debug.Log("Wrong Button");
                        Debug.Log("Player " + controller + " got the button wrong restarting sequences");
                        sm.SetPromptText(controller);
                        sm.sequence(); // Calls for a new sequence
                    }

                    downA = true; // Sets the bool so that this code is only called once per depression
                }
            }
            else if (state.Buttons.B == ButtonState.Pressed) // Checking for B depressed
            {
                if (downB == false) // Makes sure only ran once while the button is depressed
                {
                    if (sequenceI[playerLoc] == 1) // If button pressed equals the current button in the sequence
                    { // Correct Button
                        playerLoc++; // Moves the sequence along.

                        Debug.Log("B1");
                    }
                    else
                    { // Incorrect Button
                        playerLoc = 0; // Resetting the players location in the sequence
                        //Debug.Log("Wrong Button");
                        Debug.Log("Player " + controller + " got the button wrong restarting sequences");
                        sm.SetPromptText(controller);
                        sm.sequence(); // Calls for a new sequence
                    }

                    downB = true; // Sets the bool so that this code is only called once per depression
                }
            }
            else if (state.Buttons.X == ButtonState.Pressed) // Checking for X depressed
            {
                if (downX == false) // Makes sure only ran once while the button is depressed
                {
                    if (sequenceI[playerLoc] == 2) // If button pressed equals the current button in the sequence
                    { // Correct Button
                        playerLoc++; // Moves the sequence along.

                        Debug.Log("X2");
                    }
                    else
                    { // Incorrect Button
                        playerLoc = 0; // Resetting the players location in the sequence
                        //Debug.Log("Wrong Button");
                        Debug.Log("Player " + controller + " got the button wrong restarting sequences");
                        sm.SetPromptText(controller);
                        sm.sequence(); // Calls for a new sequence
                    }

                    downX = true; // Sets the bool so that this code is only called once per depression
                }
            }
            else if (state.Buttons.Y == ButtonState.Pressed) // Checking for Y depressed
            {
                if (downY == false) // Makes sure only ran once while the button is depressed
                {
                    if (sequenceI[playerLoc] == 3) // If button pressed equals the current button in the sequence
                    { // Correct Button
                        playerLoc++; // Moves the sequence along.

                        Debug.Log("Y3");
                    }
                    else
                    { // Incorrect Button
                        playerLoc = 0; // Resetting the players location in the sequence
                        //Debug.Log("Wrong Button");
                        Debug.Log("Player " + controller + " got the button wrong restarting sequences");
                        sm.SetPromptText(controller);
                        sm.sequence(); // Calls for a new sequence
                    }

                    downY = true; // Sets the bool so that this code is only called once per depression
                }
            }
            else if (state.Buttons.LeftShoulder == ButtonState.Pressed) // Checking for Left Shoulder depressed
            {
                if (downLS == false) // Makes sure only ran once while the button is depressed
                {
                    if (sequenceI[playerLoc] == 4) // If button pressed equals the current button in the sequence
                    { // Correct Button
                        playerLoc++; // Moves the sequence along.

                        Debug.Log("LB4");
                    }
                    else
                    { // Incorrect Button
                        playerLoc = 0; // Resetting the players location in the sequence
                        //Debug.Log("Wrong Button");
                        Debug.Log("Player " + controller + " got the button wrong restarting sequences");
                        sm.SetPromptText(controller);
                        sm.sequence(); // Calls for a new sequence
                    }

                    downLS = true; // Sets the bool so that this code is only called once per depression
                }
            }
            if (state.Buttons.RightShoulder == ButtonState.Pressed) // Checking for Right Shoulder depressed
            {
                if (downRS == false) // Makes sure only ran once while the button is depressed
                {
                    if (sequenceI[playerLoc] == 5) // If button pressed equals the current button in the sequence
                    { // Correct Button
                        playerLoc++; // Moves the sequence along.

                        Debug.Log("RB5");
                    }
                    else
                    { // Incorrect Button
                        playerLoc = 0; // Resetting the players location in the sequence
                        //Debug.Log("Wrong Button");
                        Debug.Log("Player " + controller + " got the button wrong restarting sequences");
                        sm.SetPromptText(controller);
                        sm.sequence(); // Calls for a new sequence
                    }

                    downRS = true; // Sets the bool so that this code is only called once per depression
                }
            }

            if (state.Buttons.A == ButtonState.Released && downA == true) // Checks if button is released and that the button has been depressed but the bool not reset
                downA = false; // Resets the bool so that the button can be used next depression
            if (state.Buttons.B == ButtonState.Released && downB == true) // Checks if button is released and that the button has been depressed but the bool not reset
                downB = false; // Resets the bool so that the button can be used next depression
            if (state.Buttons.X == ButtonState.Released && downX == true) // Checks if button is released and that the button has been depressed but the bool not reset
                downX = false; // Resets the bool so that the button can be used next depression
            if (state.Buttons.Y == ButtonState.Released && downY == true) // Checks if button is released and that the button has been depressed but the bool not reset
                downY = false; // Resets the bool so that the button can be used next depression
            if (state.Buttons.LeftShoulder == ButtonState.Released && downLS == true) // Checks if button is released and that the button has been depressed but the bool not reset
                downLS = false; // Resets the bool so that the button can be used next depression
            if (state.Buttons.RightShoulder == ButtonState.Released && downRS == true) // Checks if button is released and that the button has been depressed but the bool not reset
                downRS = false; // Resets the bool so that the button can be used next depression

            if (playerLoc >= length && runOnce == false) // Checking if the player has successfully completed the sequence
            {
                runOnce = true;
                complete();
            }
        }
	}

    void complete()
    {
        playerLoc = 0;
        runOnce = false;

        switch (controller) // Decides which player this player is and then flips the successful bool in the Sequence Manager
        {
            case 1:
                sm.playerOne = true;
                Debug.Log("Player One Completed");
                break;
            case 2:
                sm.playerTwo = true;
                Debug.Log("Player Two Completed");
                break;
            case 3:
                sm.playerThree = true;
                Debug.Log("Player Three Completed");
                break;
            case 4:
                sm.playerFour = true;
                Debug.Log("Player Four Completed");
                break;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(50, 10, 250, 30), string.Join("+", Array.ConvertAll<int, String>(sequenceI, Convert.ToString)));
    }
}
