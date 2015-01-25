using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StationManager : MonoBehaviour
{
	public List<Station> stations = new List<Station>();
    public GameObject flash;

	int difficulty;

	float nextbreak = 0;

    public bool allowBreaking = true;

	// Use this for initialization
	void Start ()
	{
		nextbreak = Time.time + Random.Range (5f, 10f);
        allowBreaking = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextbreak && allowBreaking == true)
		{
			BreakUnbrokenStation ();
			nextbreak = Time.time + Random.Range (5f, 10f);
		}
	}

	public void BreakUnbrokenStation()
	{
		bool[] allBrokenCheck = new bool[stations.Count];

		bool impossibleToBreak = false;

		while (!impossibleToBreak)
		{
			int i = Random.Range (0, stations.Count);

			if (stations[i].IsBroken ())
				allBrokenCheck[i] = true;
			else
			{
				stations[i].BreakStation ();
				break;
			}

			for (int b = 0; b < allBrokenCheck.Length; b++)
			{
				if (allBrokenCheck[b] == false)
					break;

				if (b == allBrokenCheck.Length - 1)
					impossibleToBreak = true;
			}
		}
	}
}
