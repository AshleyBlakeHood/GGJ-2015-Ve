﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Station : MonoBehaviour
{
	GameManager gameManager;

    sequenceManager sm;

	StationManager stationManager;
	SpriteRenderer spriteRenderer;

	bool broken = false;

    float maxTimeUntilCompletelyBroken = 25f;
	float timeUntilCompletelyBroken = 30f;

	List<PrisonerController> playersInZone = new List<PrisonerController> ();

    bool inSequence = false;
    bool flashing = false;

    public GameObject firstAlert, secondAlert;

    public GameObject sequenceDisplay, hintText;

	public Vector3 triggerZoneCentre = Vector3.zero;
	public float triggerRadius = 1f;

	// Use this for initialization
	void Start ()
	{
		//Get Managers
		gameManager = GameObject.FindObjectOfType<GameManager> ();
		stationManager = GameObject.FindObjectOfType<StationManager> ();

        sm = GameObject.FindObjectOfType<sequenceManager>();

		//Get Compenents
		spriteRenderer = GetComponent<SpriteRenderer> ();

		//Tell station manager the station exists.
		stationManager.stations.Add (this);
        timeUntilCompletelyBroken = maxTimeUntilCompletelyBroken;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (broken)
		{
			//Scan all players to check their distance to the station.
            for (int i = 0; i < gameManager.players.Count; i++)
            {
                if (Vector2.Distance(gameManager.players[i].transform.position, transform.position + triggerZoneCentre) < triggerRadius)
                {
                    //Debug.Log("Lana!");
                    if (!playersInZone.Contains(gameManager.players[i]))
                        playersInZone.Add(gameManager.players[i]);
                }
                else
                    playersInZone.Remove(gameManager.players[i]);
            }

            if (playersInZone.Count == gameManager.currentPlayers && inSequence == false)
            {
                //Matt's Sequence Stuff to go here.

                for (int i = 0; i < gameManager.players.Count; i++)
                {
                    gameManager.players[i].canMove = false;
                }
                hintText.GetComponent<Text>().text = "HIT THE BUTTONS IN ORDER! QUICK!";
                inSequence = true;
                sm.sequnceStation(6, this);
            }

			timeUntilCompletelyBroken -= Time.deltaTime;

			if (timeUntilCompletelyBroken < 0)
			{
				gameManager.EndGame ();
			}

            if (timeUntilCompletelyBroken <= 5)
            {
                if(!secondAlert.GetComponent<AudioSource>().isPlaying)
                secondAlert.GetComponent<AudioSource>().Play();
            }
		}
	}

	/// <summary>
	/// Will break the station and update the apperance to show this.
	/// </summary>
	public void BreakStation()
	{
        hintText.GetComponent<Text>().text = "EVERYONE GET TO THE STATION!";
        //hintText.guiText.text = "GET TO THE STATION!";
		broken = true;
        spriteRenderer.enabled = true;
        firstAlert.GetComponent<AudioSource>().Play();
        StartCoroutine(FlashToggle());
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
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            gameManager.players[i].canMove = true;
        }

		broken = false;
		spriteRenderer.enabled = false;

		if (timesAttempted > 1)
			gameManager.globalScore += (int)(timeUntilCompletelyBroken / 2);
		else
			gameManager.globalScore += (int)timeUntilCompletelyBroken;

        timeUntilCompletelyBroken = maxTimeUntilCompletelyBroken;
        inSequence = false;

        flashing = false;

        gameManager.fixes++;

        hintText.GetComponent<Text>().text = "YOU DID IT!";
        SpriteRenderer[] temp = sequenceDisplay.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in temp)
        {
            s.sprite = null;
        }
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

    IEnumerator FlashToggle()
    {
        while (flashing)
        {
            yield return new WaitForSeconds(0.5f);

            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
    }

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;

		Gizmos.DrawWireSphere (transform.position + triggerZoneCentre, triggerRadius);
	}

    void OnGUI()
    {
        if (broken)
        {
            if (timeUntilCompletelyBroken < 0)
                timeUntilCompletelyBroken = 0;

            GUIStyle style = new GUIStyle();
            style.fontSize = 32;
            style.normal.textColor = Color.white;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            GUI.Label(new Rect(screenPos.x + 1, Screen.height - screenPos.y + 1, 100, 100), timeUntilCompletelyBroken.ToString("F2"), style);
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 100, 100), timeUntilCompletelyBroken.ToString("F2"), style);

            


        }
    }
}
