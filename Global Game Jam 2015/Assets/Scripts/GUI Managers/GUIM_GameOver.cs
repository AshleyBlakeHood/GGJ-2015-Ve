using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class GUIM_GameOver : MonoBehaviour
{
	public List<string> menu = new List<string> ();

	public bool[] buttons;

	int globalScore = 0;
	private int selectedIndex = 0;

    GamePadState state1, state2, state3, state4;
    bool dpDown = false, dpUp = false;

	// Use this for initialization
	void Start ()
	{
		globalScore = PlayerPrefs.GetInt ("Global Score");
		menu.Add("Restart");
		menu.Add("Main Menu");
		menu.Add("Quit");
		buttons = new bool[menu.Count];
	}
	
	// Update is called once per frame
	void Update ()
	{
        state1 = GamePad.GetState(PlayerIndex.One);
        state2 = GamePad.GetState(PlayerIndex.Two);
        state3 = GamePad.GetState(PlayerIndex.Three);
        state4 = GamePad.GetState(PlayerIndex.Four);
	}
	

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 50, 10, 100, 60), "Global Score: " + globalScore);

		for (int count = 0; count < menu.Count; count++) {
			GUI.SetNextControlName(menu[count]);
			buttons[count] = GUI.Button(new Rect(Screen.width / 2 - 125, 100 * (count + 1), 250, 30), menu[count]);
		}

		if (Input.GetKeyDown(KeyCode.Space) || ButtonStateCheck("A"))
        {
			// When the use key is pressed, the selected button will activate
			buttons[selectedIndex] = true;
		}
		// Button conditions

		if (buttons[0]) {
			GameManager.RestartGame ();
		}
		
		if (buttons[1]) {
			GameManager.GoToMainMenu ();
		}
		// Cycling through buttons
		if (buttons[2]) {
			GameManager.QuitGame ();
		}

		if (Input.GetKeyDown(KeyCode.S) || ButtonStateCheck("DPD")) {
			if (selectedIndex == 0) {
				selectedIndex = menu.Count - 1;
			} else {
				selectedIndex -= 1;
			}
			GUI.FocusControl(menu[selectedIndex]);
		}

		if (Input.GetKeyDown(KeyCode.W) || ButtonStateCheck("DPU")) {
			if (selectedIndex == menu.Count - 1) {
				selectedIndex = 0;
			} else {
				selectedIndex += 1;
			}
			GUI.FocusControl(menu[selectedIndex]);
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
            case "DPD":
                if (state1.DPad.Up == ButtonState.Pressed && !dpDown || state2.DPad.Up == ButtonState.Pressed && !dpDown || state3.DPad.Up == ButtonState.Pressed && !dpDown || state4.DPad.Up == ButtonState.Pressed && !dpDown)
                {
                    dpDown = true;
                    return true;
                }
                if (state1.IsConnected && state1.DPad.Up == ButtonState.Released || state2.IsConnected && state2.DPad.Up == ButtonState.Released || state3.IsConnected && state3.DPad.Up == ButtonState.Released || state4.IsConnected && state4.DPad.Up == ButtonState.Released)
                {
                    dpDown = false;
                }
                break;
            case "DPU":
                if (state1.DPad.Down == ButtonState.Pressed && !dpUp || state2.DPad.Down == ButtonState.Pressed && !dpUp || state3.DPad.Down == ButtonState.Pressed && !dpUp || state4.DPad.Down == ButtonState.Pressed && !dpUp)
                {
                    dpUp = true;
                    return true;
                }
                if (state1.IsConnected && state1.DPad.Down == ButtonState.Released || state2.IsConnected && state2.DPad.Down == ButtonState.Released || state3.IsConnected && state3.DPad.Down == ButtonState.Released || state4.IsConnected && state4.DPad.Down == ButtonState.Released)
                {
                    dpUp = false;
                }
                break;
            default:
                break;
        }
        return false;
    }
}
