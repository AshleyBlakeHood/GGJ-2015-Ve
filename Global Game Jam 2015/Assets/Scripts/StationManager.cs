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
			stations [Random.Range (0, stations.Count)].BreakStation ();
			nextbreak = Time.time + Random.Range (5f, 10f);
		}
	}
}
