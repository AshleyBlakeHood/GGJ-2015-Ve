using UnityEngine;
using System.Collections;
using XInputDotNetPure;

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
        //if (Input.anyKey) // Checks if any player has pressed a button
        //{
        if (controller == 1)
            state = GamePad.GetState(PlayerIndex.One);
        if (controller == 2)
            state = GamePad.GetState(PlayerIndex.Two);
        if (controller == 3)
            state = GamePad.GetState(PlayerIndex.Three);
        if (controller == 4)
            state = GamePad.GetState(PlayerIndex.Four);
        //}

        if (state.Buttons.A == ButtonState.Pressed)
        {
            if (downA == false)
            {
                if (sequenceI[playerLoc] == 0)
                { // Correct Button
                    playerLoc++;

                    Debug.Log("Correct Button");
                }
                else
                { // Incorrect Button
                    playerLoc = 0;
                    Debug.Log("Wrong Button");
                    Debug.Log("Player " + controller + " got the button wrong restarting sequences");

                    sm.sequence(length);
                }

                downA = true;
            }
        }
        else if (state.Buttons.B == ButtonState.Pressed)
        {
            if (downB == false)
            {
                if (sequenceI[playerLoc] == 1)
                { // Correct Button
                    playerLoc++;

                    Debug.Log("Correct Button");
                }
                else
                { // Incorrect Button
                    playerLoc = 0;
                    Debug.Log("Wrong Button");
                }

                downB = true;
            }
        }
        else if (state.Buttons.X == ButtonState.Pressed)
        {
            if (downX == false)
            {
                if (sequenceI[playerLoc] == 2)
                { // Correct Button
                    playerLoc++;

                    Debug.Log("Correct Button");
                }
                else
                { // Incorrect Button
                    playerLoc = 0;
                    Debug.Log("Wrong Button");
                }

                downX = true;
            }    
        }
        else if (state.Buttons.Y == ButtonState.Pressed)
        {
            if (downY == false)
            {
                if (sequenceI[playerLoc] == 3)
                { // Correct Button
                    playerLoc++;

                    Debug.Log("Correct Button");
                }
                else
                { // Incorrect Button
                    playerLoc = 0;
                    Debug.Log("Wrong Button");
                }

                downY = true;
            }
        }
        else if (state.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            if (downLS == false)
            {
                if (sequenceI[playerLoc] == 4)
                { // Correct Button
                    playerLoc++;

                    Debug.Log("Correct Button");
                }
                else
                { // Incorrect Button
                    playerLoc = 0;
                    Debug.Log("Wrong Button");
                }

                downLS = true;
            }
        }
        if (state.Buttons.RightShoulder == ButtonState.Pressed)
        {
            if (downRS == false)
            {
                if (sequenceI[playerLoc] == 5)
                { // Correct Button
                    playerLoc++;

                    Debug.Log("Correct Button");
                }
                else
                { // Incorrect Button
                    playerLoc = 0;
                    Debug.Log("Wrong Button");
                }

                downRS = true;
            }
        }

        if (state.Buttons.A == ButtonState.Released && downA == true)
            downA = false;
        if (state.Buttons.B == ButtonState.Released && downB == true)
            downB = false;
        if (state.Buttons.X == ButtonState.Released && downX == true)
            downX = false;
        if (state.Buttons.Y == ButtonState.Released && downY == true)
            downY = false;
        if (state.Buttons.LeftShoulder == ButtonState.Released && downLS == true)
            downLS = false;
        if (state.Buttons.RightShoulder == ButtonState.Released && downRS == true)
            downRS = false;

        if (playerLoc >= length && runOnce == false)
        {
            runOnce = true;
            complete();
        }
	}

    void complete()
    {
        switch (controller)
        {
            case 1:
                sm.playerOne = true;
                Debug.Log("Completed");
                break;
            case 2:
                sm.playerTwo = true;
                break;
            case 3:
                sm.playerThree = true;
                break;
            case 4:
                sm.playerFour = true;
                break;
        }
    }
}
