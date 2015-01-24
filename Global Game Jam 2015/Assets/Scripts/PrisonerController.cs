using UnityEngine;
using System.Collections;

public class PrisonerController : MonoBehaviour {

    public float speed = 10;
    public 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveForwards();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackwards();
        }
	
	}

    void MoveLeft()
    {

        transform.position = transform.position - new Vector3(speed/100f,0,0);
        //transform.position.y -= speed;
    }

    void MoveRight()
    {
        transform.position = transform.position + new Vector3(speed / 100f, 0, 0);
    }

    void MoveForwards()
    {
        transform.position = transform.position + new Vector3(0 ,speed / 100f, 0);
    }

    void MoveBackwards()
    {
        transform.position = transform.position - new Vector3(0, speed / 100f, 0);
    }

}
