using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class ControllerTesting : MonoBehaviour {

    GamePadState state1;
    GamePadState state2;
    GamePadState state3;
    GamePadState state4;

    sequenceManager sm;

	// Use this for initialization
	void Start () {

        sm = GameObject.Find("Main Camera").GetComponent<sequenceManager>();

        sm.sequence(6);
	
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.anyKey)
        //{
            state1 = GamePad.GetState(PlayerIndex.One);
            state2 = GamePad.GetState(PlayerIndex.Two);
            state3 = GamePad.GetState(PlayerIndex.Three);
            state4 = GamePad.GetState(PlayerIndex.Four);
        //}

        //if (Input.GetButton("j1HorizontalLeft"))
        //    Debug.Log("Joystick 1 Horizontal Left Pressed");

        //if (Input.GetButton("j1VerticalLeft"))
        //    Debug.Log("Joystick 1 Vertical Left Pressed");

        //if (Input.GetButton("j1HorizontalRight"))
        //    Debug.Log("Joystick 1 Horizontal Right Pressed");

        //if (Input.GetButton("j1VerticalRight"))
        //    Debug.Log("Joystick 1 Vertical Right Pressed");

        //if (Input.GetButton("j1HorizontalDPad"))
        //    Debug.Log("Joystick 1 Horizontal DPad Pressed");

        //if (Input.GetButton("j1VerticalDPad"))
        //    Debug.Log("Joystick 1 Vertical DPad Pressed");

        //if (Input.GetButton("j1Triggers"))
        //    Debug.Log("Joystick 1 Triggers Pressed");

        //if (Input.GetButton("j1TriggerLeft"))
        //    Debug.Log("Joystick 1 Trigger Left Pressed");

        //if (Input.GetButton("j1TriggerRight"))
        //    Debug.Log("Joystick 1 Trigger Right Pressed");

        //if (Input.GetButton("j1A"))
        //    Debug.Log("Joystick 1 A Pressed");

        //if (Input.GetButton("j1B"))
        //    Debug.Log("Joystick 1 B Pressed");

        //if (Input.GetButton("j1X"))
        //{
        //    //Debug.Log("Joystick 1 X Pressed");

        //    if (state1.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 1 X Pressedj1X");
        //    if (state2.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 2 X Pressedj1X");
        //    if (state3.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 3 X Pressedj1X");
        //    if (state4.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 4 X Pressedj1X");
        //}

        //if (Input.GetButton("j2X"))
        //{
        //    //Debug.Log("Joystick 1 X Pressed");

        //    if (state1.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 1 X Pressedj2X");
        //    if (state2.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 2 X Pressedj2X");
        //    if (state3.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 3 X Pressedj2X");
        //    if (state4.Buttons.X.ToString() == "Pressed")
        //        Debug.Log("Joystick 4 X Pressedj2X");
        //}

        //if (Input.GetButton("j3X"))
        //{
        //    //Debug.Log("Joystick 1 X Pressed");

        //    if (state1.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 1 X Pressed");
        //    if (state2.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 2 X Pressed");
        //    if (state3.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 3 X Pressed");
        //    if (state4.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 4 X Pressed");
        //}

        //if (Input.GetButton("j4X"))
        //{
        //    //Debug.Log("Joystick 1 X Pressed");

        //    if (state1.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 1 X Pressed");
        //    if (state2.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 2 X Pressed");
        //    if (state3.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 3 X Pressed");
        //    if (state4.Buttons.X.Equals("Pressed"))
        //        Debug.Log("Joystick 4 X Pressed");
        //}

        //if (Input.GetButton("j1Y"))
        //    Debug.Log("Joystick 1 Y Pressed");

        //if (Input.GetButton("j1LB"))
        //    Debug.Log("Joystick 1 LB Pressed");

        //if (Input.GetButton("j1RB"))
        //    Debug.Log("Joystick 1 RB Pressed");

        //if (Input.GetButton("j1Back"))
        //    Debug.Log("Joystick 1 Back Pressed");

        //if (Input.GetButton("j1Start"))
        //    Debug.Log("Joystick 1 Start Pressed");

        //if (Input.GetButton("j1LeftPressed"))
        //    Debug.Log("Joystick 1 Left Pressed");

        //if (Input.GetButton("j1RightPressed"))
        //    Debug.Log("Joystick 1 Right Pressed");

            if (state3.Buttons.X == ButtonState.Pressed)
            {
                
            }


        if (state1.Buttons.A == ButtonState.Pressed)
        {
            StartCoroutine(vibrate1());
        }

        if (state2.Buttons.A == ButtonState.Pressed)
        {
            StartCoroutine(vibrate2());
        }

        if (state3.Buttons.A == ButtonState.Pressed)
        {
            StartCoroutine(vibrate3());
        }

        if (state4.Buttons.A == ButtonState.Pressed)
        {
            StartCoroutine(vibrate4());
        }


	}

    void OnApplicationQuit() // Forcing any vibrations to turn off to stop perpetual vibrations
    {
        float j1 = 0.0f;

        GamePad.SetVibration(PlayerIndex.One, j1, j1);
        GamePad.SetVibration(PlayerIndex.Two, j1, j1);
        GamePad.SetVibration(PlayerIndex.Three, j1, j1);
        GamePad.SetVibration(PlayerIndex.Four, j1, j1);

    }

    IEnumerator vibrate1() // Runs methods every 10 seconds
    {
        float j1 = 0.9f;

        GamePad.SetVibration(PlayerIndex.One, j1, j1);

        yield return new WaitForSeconds(0.5f);

        j1 = 0.0f;

        GamePad.SetVibration(PlayerIndex.One, j1, j1);
    }

    IEnumerator vibrate2() // Runs methods every 10 seconds
    {
        float j1 = 0.9f;

        GamePad.SetVibration(PlayerIndex.Two, j1, j1);

        yield return new WaitForSeconds(0.5f);

        j1 = 0.0f;

        GamePad.SetVibration(PlayerIndex.Two, j1, j1);
    }

    IEnumerator vibrate3() // Runs methods every 10 seconds
    {
        float j1 = 0.9f;

        GamePad.SetVibration(PlayerIndex.Three, j1, j1);

        yield return new WaitForSeconds(0.5f);

        j1 = 0.0f;

        GamePad.SetVibration(PlayerIndex.Three, j1, j1);
    }

    IEnumerator vibrate4() // Runs methods every 10 seconds
    {
        float j1 = 0.9f;

        GamePad.SetVibration(PlayerIndex.Four, j1, j1);

        yield return new WaitForSeconds(0.5f);

        j1 = 0.0f;

        GamePad.SetVibration(PlayerIndex.Four, j1, j1);
    }
}
