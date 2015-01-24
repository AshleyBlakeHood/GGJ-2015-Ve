﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Station : MonoBehaviour
{
	GameManager gameManager;

	StationManager stationManager;
	SpriteRenderer spriteRenderer;

	public Sprite normalSprite;
	public Sprite brokenSprite;

	bool broken = false;

	float timeUntilCompletelyBroken = 10f;

	//List<Player> playersInZone = new List<PlayerPrefs> ();

	// Use this for initialization
	void Start ()
	{
		//Get Managers
		gameManager = GameObject.FindObjectOfType<GameManager> ();
		stationManager = GameObject.FindObjectOfType<StationManager> ();

		//Get Compenents
		spriteRenderer = GetComponent<SpriteRenderer> ();

		//Tell station manager the station exists.
		stationManager.stations.Add (this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (broken)
		{
			//Scan all players to check their distance to the station.
//			for (int i = 0; i < gameManager.players.Count; i++)
//			{
//				if (Vector2.Distance(gameManager.players[i].transform.position, transform.position) < 1f)
//				{
//					if (!players[i].Contains(gameManager.players[i]))
//						playersInZone.Add(gameManager.players[i]);
//				}
//				else
//					playersInZone.Remove(gameManager.players[i]);
//			}

//			if (playersInZone.Count == gameManager.currentPlayers)
//			{
//				//Matt's Sequence Stuff to go here.
//			}

			timeUntilCompletelyBroken -= Time.deltaTime;

			if (timeUntilCompletelyBroken < 0)
			{
				Debug.Log ("Game Over! Explosion!");
			}
		}
	}

	/// <summary>
	/// Will break the station and update the apperance to show this.
	/// </summary>
	public void BreakStation()
	{
		broken = true;
		spriteRenderer.sprite = brokenSprite;
	}

	/// <summary>
	/// Determines whether this instance is broken.
	/// </summary>
	/// <returns><c>true</c> if this instance is broken; otherwise, <c>false</c>.</returns>
	public bool IsBroken()
	{
		return broken;
	}

	/// <summary>
	/// Will set the station to normal status. If times attempted is greater than 1 then the score for fixing will be halfed.
	/// </summary>
	/// <param name="timesAttempted">Times attempted.</param>
	public void FixStation(int timesAttempted)
	{
		broken = false;
		spriteRenderer.sprite = normalSprite;

		if (timesAttempted > 1)
			gameManager.globalScore += (int)(timeUntilCompletelyBroken / 2);
		else
			gameManager.globalScore += (int)timeUntilCompletelyBroken;

		timeUntilCompletelyBroken = 10f;
	}

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	void OnMouseDown()
	{
		if (broken)
			FixStation (1);
		else
			BreakStation (); 
	}
}
