using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class sequenceManager : MonoBehaviour {



    public List<sequence> sequences = new List<sequence>();

    public bool playerOne = false, playerTwo = false, playerThree = false, playerFour = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (PlayerPrefs.GetInt("Player Count") == 1)
        {
            if (playerOne == true)
            {

            }
        }

	
	}

    public void sequence(int length, station station) // Randomly picks the sequence of events
    {
        int[] sequenceI = new int[length];

        for (int i = 0; i < sequenceI.Length; i++)
        {
            sequenceI[i] = UnityEngine.Random.Range(0, 6);
        }

        Debug.Log(string.Join("+", Array.ConvertAll<int, String>(sequenceI, Convert.ToString)));

        foreach (sequence hold in sequences)
        {
            hold.sequenceI = sequenceI;
            hold.length = length;
        }

        //sequenceOutput(length, sequenceI); // Calls the output method to output to screen and wait for users input
    }
}
