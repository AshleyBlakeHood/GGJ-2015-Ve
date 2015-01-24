using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;
	public int currentPlayers = 3;

    public GameObject Character;

	public int globalScore = 0;

	//public List<Player> players = new List<Player>();

	// Use this for initialization
	void Start ()
	{
		currentPlayers = PlayerPrefs.GetInt ("Player Count");
        SpawnPlayers();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnPlayers()
    {
        if (PlayerPrefs.GetInt("P1") == 1)
        {
            GameObject p1 = Instantiate(Character) as GameObject;
            p1.name = "Player 1";
            p1.transform.position = spawnPoints[0].transform.position;
            p1.GetComponent<PrisonerController>().SetUpGamePad(1);
            //p1.GetComponentInChildren<HeadChanger>().SetHead(1);
        }
        if (PlayerPrefs.GetInt("P2") == 1)
        {
            GameObject p2 = Instantiate(Character) as GameObject;
            p2.name = "Player 2";
            p2.transform.position = spawnPoints[1].transform.position;
            p2.GetComponent<PrisonerController>().SetUpGamePad(2);
            //p2.GetComponentInChildren<HeadChanger>().SetHead(2);
        }
        if (PlayerPrefs.GetInt("P3") == 1)
        {
            GameObject p3 = Instantiate(Character) as GameObject;
            p3.name = "Player 3";
            p3.transform.position = spawnPoints[2].transform.position;
            p3.GetComponent<PrisonerController>().SetUpGamePad(3);
            //p3.GetComponentInChildren<HeadChanger>().SetHead(3);
        }
        if (PlayerPrefs.GetInt("P4") == 1)
        {
            GameObject p4 = Instantiate(Character) as GameObject;
            p4.name = "Player 4";
            p4.transform.position = spawnPoints[3].transform.position;
            p4.GetComponent<PrisonerController>().SetUpGamePad(4);
            //p4.GetComponentInChildren<HeadChanger>().SetHead(4);
        }
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
