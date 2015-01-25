using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    GameObject dynamicObjectHolder;

    public Vector2 speed = new Vector2(-0.5f, 0);
    public Vector2 terminationZone = Vector2.zero;

    public GameObject[] spaceSceneResources;
    public GameObject[] planetResources;
    public GameObject[] particleResources;

	public GameObject[] flybyItemsResources;

    public List<GameObject> spaceScenes = new List<GameObject>();
    public List<GameObject> planets = new List<GameObject>();
	public List<FlybyItem> flybyItems = new List<FlybyItem>();

	private int backgroundsLeftToMove = 0;
	private int direction = 1;

	// Use this for initialization
	void Start ()
    {
        if (GameObject.Find("Dynamic Object Holder") == null)
            dynamicObjectHolder = new GameObject("Dynamic Object Holder");
        else
            dynamicObjectHolder = GameObject.Find("Dynamic Object Holder");

        SpawnSpaceScene();
        SpawnSpaceScene();
        SpawnSpaceScene();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessSpaceBackgrounds();
        ProcessPlanets();
		ProcessFlybys ();

		if (Input.GetKeyDown (KeyCode.UpArrow))
			FauxMoveUp (2);

		if (Input.GetKeyDown (KeyCode.DownArrow))
			FauxMoveDown (2);
	}

    private void ProcessSpaceBackgrounds()
    {
        for (int i = 0; i < spaceScenes.Count; i++)
        {
            spaceScenes[i].transform.Translate(speed);

            if (spaceScenes[i].transform.position.x <= terminationZone.x)
            {
                Destroy(spaceScenes[i]);
                spaceScenes.RemoveAt(i);

                SpawnSpaceScene();
            }
        }
    }

    private void ProcessPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            planets[i].transform.Translate(speed);

            if (planets[i].transform.position.x <= terminationZone.x)
            {
                Destroy(planets[i]);
                planets.RemoveAt(i);
            }
        }
    }

	public void ProcessFlybys()
	{
		if (Random.Range (0, 50) == 0)
		{
			FlybyItem flybyItem = new FlybyItem();

			int direction = 1;

			if (Random.Range (0, 2) == 0)
				direction = -1;

			float startX = 20f;
			float startY = Random.Range (0f, 10.80f);
			float endX = -20f;
			float endY = (startY * 2) * direction;

			flybyItem.destination = new Vector2(endX, endY);
			flybyItem.speed = Random.Range (0.05f, 0.1f);
			flybyItem.item = Instantiate (flybyItemsResources[Random.Range (0, flybyItemsResources.Length)], new Vector2(startX, startY), Quaternion.identity) as GameObject;
			flybyItem.item.transform.parent = dynamicObjectHolder.transform;

			flybyItems.Add (flybyItem);
		}

		for (int i = 0; i < flybyItems.Count; i++)
		{
			flybyItems[i].item.transform.position = Vector2.MoveTowards (flybyItems[i].item.transform.position, flybyItems[i].destination, flybyItems[i].speed);
			
			if (Vector2.Distance (flybyItems[i].item.transform.position, flybyItems[i].destination) < 0.1f)
			{
				Destroy (flybyItems[i].item);
				flybyItems.RemoveAt(i);
			}
		}
	}

    private void SpawnSpaceScene()
    {
        GameObject newScene;

        if (spaceScenes.Count < 1)
        {
            newScene = Instantiate(spaceSceneResources[Random.Range(0, spaceSceneResources.Length)], Vector2.zero, Quaternion.identity) as GameObject;
        }
        else
        {
            newScene = Instantiate(spaceSceneResources[Random.Range(0, spaceSceneResources.Length)], new Vector2(spaceScenes[spaceScenes.Count - 1].transform.position.x + 19f, 0), Quaternion.identity) as GameObject; ;
        }

        spaceScenes.Add(newScene);
        newScene.transform.parent = dynamicObjectHolder.transform;

        //Spawn Particles?
        if (Random.Range(0, 5) == 0)
        {
            GameObject p = Instantiate(particleResources[Random.Range(0, particleResources.Length - 1)], new Vector3(newScene.transform.position.x, newScene.transform.position.y, -10f), Quaternion.identity) as GameObject;
            p.transform.parent = newScene.transform;
        }

        SpawnPlanets(newScene.transform.position, newScene);

		if (backgroundsLeftToMove > 0)
		{
			SpawnAboveAndBelowAndMove (newScene, direction);
			backgroundsLeftToMove--;
		}
    }

    private void SpawnPlanets(Vector2 backgroundPosition, GameObject requestBackground)
    {
        for (int i = 0; i < Random.Range(0, 2); i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(backgroundPosition.x - 9.6f, backgroundPosition.x + 9.6f), Random.Range(-5.4f, 5.4f));
            GameObject planet = Instantiate(planetResources[Random.Range(0, planetResources.Length)], spawnPosition, Quaternion.identity) as GameObject;

            float size = Random.Range(0.1f, 1f);

            //Personalise Planet
            planet.transform.localScale = new Vector3(size, size, 1);
            planet.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

			planet.transform.parent = requestBackground.transform;
            planets.Add(planet);
        }
    }

	public void FauxMoveUp(int backgroundsToMove)
	{
		foreach(GameObject g in spaceScenes)
		{
			SpawnAboveAndBelowAndMove (g, -1);
		}

		//backgroundsLeftToMove = backgroundsToMove;
		direction = 1;
	}

	public void FauxMoveDown(int backgroundsToMove)
	{
		foreach(GameObject g in spaceScenes)
		{
			SpawnAboveAndBelowAndMove (g, 1);
		}
		
		//backgroundsLeftToMove = backgroundsToMove;
		direction = -1;
	}

	public void SpawnAboveAndBelowAndMove(GameObject g, int direction)
	{
		GameObject up = Instantiate (spaceSceneResources[Random.Range (0, spaceSceneResources.Length)], new Vector3(g.transform.position.x, 10.80f, g.transform.position.z), Quaternion.identity) as GameObject;
		GameObject down = Instantiate (spaceSceneResources[Random.Range (0, spaceSceneResources.Length)], new Vector3(g.transform.position.x, -10.80f, g.transform.position.z), Quaternion.identity) as GameObject;
		
		up.transform.parent = g.transform;
		down.transform.parent = g.transform;
		
		StartCoroutine (MoveBackground(g, g.transform.position.y + 8.4f * direction));
	}

	IEnumerator MoveBackground(GameObject background, float destinationY)
	{
		float y = background.transform.position.y;

		while (true)
		{
			if (background == null)
				break;

			y = background.transform.position.y;

			background.transform.position = Vector2.MoveTowards (background.transform.position, new Vector2(background.transform.position.x, destinationY), 0.05f);
			yield return null;
		}
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(terminationZone, 2f);
    }
}
