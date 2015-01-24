using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeadChanger : MonoBehaviour {

    public List<Sprite> heads;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHead(int id)
    {
        //GetComponent<SpriteRenderer>().sprite = heads[id];
    }
}
