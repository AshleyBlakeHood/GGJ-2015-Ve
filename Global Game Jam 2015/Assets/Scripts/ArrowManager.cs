using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {
	public Vector3 upwards;
	public Vector3 right;
	public Vector3 left;
	public GameObject arrow;

	private GameObject upArrow;
	private GameObject rightArrow;
	private GameObject leftArrow;
	// Use this for initialization
	void Start () {
		upwards = new Vector3(0,2.9f,-1);
		right = new Vector3(5,2.9f,-1);
		left = new Vector3(-5,2.9f,-1);
		//Set the vectors to the locs where to place the arrows
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void instantiateArrows()
	{
		upArrow = Instantiate(arrow, upwards, Quaternion.identity) as GameObject;
		//Instantiate arrows to display options for the players to take
		rightArrow = Instantiate(arrow, right, Quaternion.identity) as GameObject;
		rightArrow.transform.Rotate(0f, 0f, 270f);
		leftArrow = Instantiate(arrow, left, Quaternion.identity) as GameObject;
		leftArrow.transform.Rotate(0f, 0f, 90f);
		//Rotate the arrows
	}

	public void destroyArrows(string direction)
	{
		if (direction == "Up") {
			Destroy(rightArrow);
			Destroy(leftArrow);
			//Destroy the other two arrows which weren't chosen
			StartCoroutine(imminentDestruction(upArrow));
			//Start a coroutine for destruction
		}
		if (direction == "Right") {
			Destroy(leftArrow);
			Destroy(upArrow);
			StartCoroutine(imminentDestruction(rightArrow));
		}
		if (direction == "Left") {
			Destroy(rightArrow);
			Destroy(upArrow);
			StartCoroutine(imminentDestruction(leftArrow));
		}
		//Depends on the chosen direction, destroy the others
	}

	public IEnumerator imminentDestruction(GameObject chosenArrow)
	{
		yield return new WaitForSeconds (4.0f);
		Destroy (chosenArrow);
		//Waits 4 seconds before destroying the destruction
	}
}
