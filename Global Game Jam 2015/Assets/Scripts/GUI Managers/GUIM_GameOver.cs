using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIM_GameOver : MonoBehaviour
{
	public List<string> menu = new List<string> ();

	public bool[] buttons;

	int globalScore = 0;
	private int selectedIndex = 0;

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

	}
	

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 50, 10, 100, 30), "Global Score: " + globalScore);

		for (int count = 0; count < menu.Count; count++) {
			GUI.SetNextControlName(menu[count]);
			buttons[count] = GUI.Button(new Rect(Screen.width / 2 - 125, 100 * (count + 1), 250, 30), menu[count]);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
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

		if (Input.GetKeyDown(KeyCode.S)) {
			if (selectedIndex == 0) {
				selectedIndex = menu.Count - 1;
			} else {
				selectedIndex -= 1;
			}
			GUI.FocusControl(menu[selectedIndex]);
		}

		if (Input.GetKeyDown(KeyCode.W)) {
			if (selectedIndex == menu.Count - 1) {
				selectedIndex = 0;
			} else {
				selectedIndex += 1;
			}
			GUI.FocusControl(menu[selectedIndex]);
		}


	}
}
