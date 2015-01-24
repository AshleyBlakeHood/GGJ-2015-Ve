using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {
	public Vector3 upwards;
	public Vector3 right;
	public Vector3 down;
	public GameObject arrow;

	private GameObject upArrow;
	private GameObject rightArrow;
	private GameObject downArrow;

    StationManager sm;

	// Use this for initialization
	void Start () 
    {
        sm = GameObject.FindObjectOfType<StationManager>();

        upwards = new Vector3(7.5f, 2.9f, -1);
		right = new Vector3(7.5f,0,-1);
        down = new Vector3(7.5f, -2.5f, -1);
		//Set the vectors to the locs where to place the arrows
	}
	
	// Update is called once per frame
	void Update () 
    {

	}


	public void instantiateArrows()
	{
		upArrow = Instantiate(arrow, upwards, Quaternion.identity) as GameObject;
		//Instantiate arrows to display options for the players to take
		rightArrow = Instantiate(arrow, right, Quaternion.identity) as GameObject;
		rightArrow.transform.Rotate(0f, 0f, 270f);
		downArrow = Instantiate(arrow, down, Quaternion.identity) as GameObject;
		downArrow.transform.Rotate(0f, 0f, 180f);
		//Rotate the arrows
	}

	public void destroyArrows(string direction)
	{
		if (direction == "Up") {
			Destroy(rightArrow);
			Destroy(downArrow);
			//Destroy the other two arrows which weren't chosen
			StartCoroutine(imminentDestruction(upArrow));
			//Start a coroutine for destruction
		}
		if (direction == "Right") {
			Destroy(downArrow);
			Destroy(upArrow);
			StartCoroutine(imminentDestruction(rightArrow));
		}
		if (direction == "Down") {
			Destroy(rightArrow);
			Destroy(upArrow);
			StartCoroutine(imminentDestruction(downArrow));
		}
		//Depends on the chosen direction, destroy the others

        sm.allowBreaking = true;
	}

	public IEnumerator imminentDestruction(GameObject chosenArrow)
	{
		yield return new WaitForSeconds (4.0f);
		Destroy (chosenArrow);
		//Waits 4 seconds before destroying the destruction
	}
}
