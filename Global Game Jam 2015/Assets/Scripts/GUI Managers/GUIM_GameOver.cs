using UnityEngine;
using System.Collections;

public class GUIM_GameOver : MonoBehaviour
{
	int globalScore = 0;

	// Use this for initialization
	void Start ()
	{
		globalScore = PlayerPrefs.GetInt ("Global Score");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 50, 10, 100, 30), "Global Score: " + globalScore);

		if (GUI.Button(new Rect(Screen.width / 2 - 125, 100, 250, 30), "Restart"))
			GameManager.RestartGame ();

		if (GUI.Button(new Rect(Screen.width / 2 - 125, 200, 250, 30), "Main Menu"))
			GameManager.GoToMainMenu ();

		if (GUI.Button(new Rect(Screen.width / 2 - 125, 300, 250, 30), "Quit"))
			GameManager.QuitGame ();
	}
}
