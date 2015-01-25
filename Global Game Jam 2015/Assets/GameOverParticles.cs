using UnityEngine;
using System.Collections;

public class GameOverParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().renderer.sortingOrder = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EndGameExplosion()
    {
        if(!GetComponent<ParticleSystem>().isPlaying)
        GetComponent<ParticleSystem>().Play();

        if(!GetComponent<AudioSource>().isPlaying)
        GetComponent<AudioSource>().Play();
    }
}
