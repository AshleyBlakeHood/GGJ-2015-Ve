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

    public List<GameObject> spaceScenes = new List<GameObject>();
    public List<GameObject> planets = new List<GameObject>();

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
	}

    private void ProcessSpaceBackgrounds()
    {
        for (int i = 0; i < spaceScenes.Count; i++)
        {
            spaceScenes[i].transform.Translate(speed);

            if (spaceScenes[i].transform.position.x <= terminationZone.x && spaceScenes[i].transform.position.y <= terminationZone.y)
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

    private void SpawnSpaceScene()
    {
        GameObject newScene;

        if (spaceScenes.Count < 1)
        {
            newScene = Instantiate(spaceSceneResources[Random.Range(0, spaceSceneResources.Length)], Vector2.zero, Quaternion.identity) as GameObject;
        }
        else
        {
            newScene = Instantiate(spaceSceneResources[Random.Range(0, spaceSceneResources.Length)], new Vector2(spaceScenes[spaceScenes.Count - 1].transform.position.x + 19.20f, 0), Quaternion.identity) as GameObject; ;
        }

        spaceScenes.Add(newScene);
        newScene.transform.parent = dynamicObjectHolder.transform;
        SpawnPlanets(newScene.transform.position);
    }

    private void SpawnPlanets(Vector2 backgroundPosition)
    {
        for (int i = 0; i < Random.Range(0, 2); i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(backgroundPosition.x - 9.6f, backgroundPosition.x + 9.6f), Random.Range(-5.4f, 5.4f));
            GameObject planet = Instantiate(planetResources[Random.Range(0, planetResources.Length)], spawnPosition, Quaternion.identity) as GameObject;

            float size = Random.Range(0.1f, 1f);

            //Personalise Planet
            planet.transform.localScale = new Vector3(size, size, 1);
            planet.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            planet.transform.parent = dynamicObjectHolder.transform;
            planets.Add(planet);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(terminationZone, 2f);
    }
}
