using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class loadScreenCode : MonoBehaviour {

    GamePadState state1, state2, state3, state4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        state1 = GamePad.GetState(PlayerIndex.One);
        state2 = GamePad.GetState(PlayerIndex.Two);
        state3 = GamePad.GetState(PlayerIndex.Three);
        state4 = GamePad.GetState(PlayerIndex.Four);
        if (ButtonStateCheck("A"))
        {
            Application.LoadLevel("Gameplay Scene");
        }
	}

    bool ButtonStateCheck(string button)
    {
        switch (button)
        {
            case "A":
                if (state1.Buttons.A == ButtonState.Pressed || state2.Buttons.A == ButtonState.Pressed || state3.Buttons.A == ButtonState.Pressed || state4.Buttons.A == ButtonState.Pressed)
                    return true;
                break;
            case "B":
                if (state1.Buttons.B == ButtonState.Pressed || state2.Buttons.B == ButtonState.Pressed || state3.Buttons.B == ButtonState.Pressed || state4.Buttons.B == ButtonState.Pressed)
                    return true;
                break;
            case "X":
                if (state1.Buttons.X == ButtonState.Pressed || state2.Buttons.X == ButtonState.Pressed || state3.Buttons.X == ButtonState.Pressed || state4.Buttons.X == ButtonState.Pressed)
                    return true;
                break;
            case "Y":
                if (state1.Buttons.Y == ButtonState.Pressed || state2.Buttons.Y == ButtonState.Pressed || state3.Buttons.Y == ButtonState.Pressed || state4.Buttons.Y == ButtonState.Pressed)
                    return true;
                break;
            case "LB":
                if (state1.Buttons.LeftShoulder == ButtonState.Pressed || state2.Buttons.LeftShoulder == ButtonState.Pressed || state3.Buttons.LeftShoulder == ButtonState.Pressed || state4.Buttons.LeftShoulder == ButtonState.Pressed)
                    return true;
                break;
            case "RB":
                if (state1.Buttons.RightShoulder == ButtonState.Pressed || state2.Buttons.RightShoulder == ButtonState.Pressed || state3.Buttons.RightShoulder == ButtonState.Pressed || state4.Buttons.RightShoulder == ButtonState.Pressed)
                    return true;
                break;
            default:
                break;
        }
        return false;
    }
}
