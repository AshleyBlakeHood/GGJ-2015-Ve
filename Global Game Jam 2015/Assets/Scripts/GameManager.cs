using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public int currentPlayers = 0;

	public int globalScore = 0;

	//public List<Player> players = new List<Player>();

	// Use this for initialization
	void Start ()
	{
		currentPlayers = PlayerPrefs.GetInt ("Player Count");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Ends the main game and enters the game over screen.
	/// </summary>
	public void EndGame()
	{
		PlayerPrefs.SetInt ("Global Score", globalScore);
		Application.LoadLevel ("Game Over Scene");
	}

	/// <summary>
	/// Restarts the game with the same settings as before.
	/// </summary>
	public static void RestartGame()
	{
		Application.LoadLevel ("Gameplay Scene");
	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	public static void QuitGame()
	{
		//Matt's controller stop rumbling in the jungle code to go here?
		Application.Quit ();
	}

	/// <summary>
	/// Gos to main menu.
	/// </summary>
	public static void GoToMainMenu()
	{
		Application.LoadLevel ("Start Up Screen");
	}
}