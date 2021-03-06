﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;
	public int currentPlayers = 3, fixes = 0;

    public GameObject Character, EndGameParticles, scoreText, promptText;

	public int globalScore = 0;

	public List<PrisonerController> players = new List<PrisonerController>();

    Direction dir;
    StationManager sm;

    public bool runOnce = false;

	// Use this for initialization
	void Start ()
	{
        dir = GameObject.FindObjectOfType<Direction>();
        sm = GameObject.FindObjectOfType<StationManager>();

		currentPlayers = PlayerPrefs.GetInt ("Player Count");
        SpawnPlayers();
	}
	
	// Update is called once per frame
	void Update () 
    {
        scoreText.GetComponent<Text>().text = "Score: " + globalScore;
        if (fixes >= 2 && runOnce == false)
        {
            //fixes = 0;
            dir.toggleVote();
            //sm.allowBreaking = false;

            //Debug.Log("Game Manager Fixes =" + fixes + " RunOnce =" + runOnce);

            //runOnce = true;
        }
	
	}

    void SpawnPlayers()
    {
        if (PlayerPrefs.GetInt("P1") == 1)
        {
            GameObject p1 = Instantiate(Character) as GameObject;
            p1.name = "Player 1";
            p1.transform.position = spawnPoints[0].transform.position;
            p1.GetComponent<PrisonerController>().SetUpGamePad(1);
            p1.GetComponent<sequence>().controller = 1;
            //p1.GetComponentInChildren<HeadChanger>().SetHead(1);
        }
        if (PlayerPrefs.GetInt("P2") == 1)
        {
            GameObject p2 = Instantiate(Character) as GameObject;
            p2.name = "Player 2";
            p2.transform.position = spawnPoints[1].transform.position;
            p2.GetComponent<PrisonerController>().SetUpGamePad(2);
            p2.GetComponent<sequence>().controller = 2;
            //p2.GetComponentInChildren<HeadChanger>().SetHead(2);
        }
        if (PlayerPrefs.GetInt("P3") == 1)
        {
            GameObject p3 = Instantiate(Character) as GameObject;
            p3.name = "Player 3";
            p3.transform.position = spawnPoints[2].transform.position;
            p3.GetComponent<PrisonerController>().SetUpGamePad(3);
            p3.GetComponent<sequence>().controller = 3;
            //p3.GetComponentInChildren<HeadChanger>().SetHead(3);
        }
        if (PlayerPrefs.GetInt("P4") == 1)
        {
            GameObject p4 = Instantiate(Character) as GameObject;
            p4.name = "Player 4";
            p4.transform.position = spawnPoints[3].transform.position;
            p4.GetComponent<PrisonerController>().SetUpGamePad(4);
            p4.GetComponent<sequence>().controller = 4;
            //p4.GetComponentInChildren<HeadChanger>().SetHead(4);
        }
    }

    /// <summary>
	/// Ends the main game and enters the game over screen.
	/// </summary>
	public void EndGame()
	{
        EndGameParticles.GetComponent<GameOverParticles>().EndGameExplosion();
        StartCoroutine(GameEnd());
        
	}

    void LoadEndMenu()
    {
        PlayerPrefs.SetInt("Global Score", globalScore);
        Application.LoadLevel("Game Over Scene");
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

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(2.75f);
        LoadEndMenu();
    }
}
