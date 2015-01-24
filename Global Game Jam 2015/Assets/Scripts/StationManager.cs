using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StationManager : MonoBehaviour
{
	public List<Station> stations = new List<Station>();

	int difficulty;

	float nextbreak = 0;

	// Use this for initialization
	void Start ()
	{
		nextbreak = Time.time + Random.Range (5f, 10f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextbreak)
		{
			stations [Random.Range (0, stations.Count)].BreakStation ();
			nextbreak = Time.time + Random.Range (5f, 10f);
		}
	}
}
