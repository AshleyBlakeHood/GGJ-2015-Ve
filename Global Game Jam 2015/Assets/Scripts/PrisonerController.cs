using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class PrisonerController : MonoBehaviour
{
    GameManager gameManager;

    public float speed = 10;
    int playerID;
    GamePadState gpState;
    PlayerIndex playerIndex;
    public bool canMove = true;
    Animator anims;

    public List<Sprite> heads;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        gameManager.players.Add(this);

        anims = GetComponent<Animator>();
	}

    public void SetUpGamePad(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                playerIndex = PlayerIndex.One;
                Debug.Log("YUP");
                break;
            case 2:
                playerIndex = PlayerIndex.Two;
                break;
            case 3:
                playerIndex = PlayerIndex.Three;
                break;
            case 4:
                playerIndex = PlayerIndex.Four;
                break;
            default:
                break;
        }
        playerID = playerNumber;
        SwitchHead();
    }

    void SwitchHead()
    {
        switch (playerID)
        {
            case 1:
                transform.FindChild("Body").FindChild("Head").GetComponent<SpriteRenderer>().sprite = heads[0];
                break;
            case 2:
                transform.FindChild("Body").FindChild("Head").GetComponent<SpriteRenderer>().sprite = heads[1];
                break;
            case 3:
                transform.FindChild("Body").FindChild("Head").GetComponent<SpriteRenderer>().sprite = heads[2];
                break;
            case 4:
                transform.FindChild("Body").FindChild("Head").GetComponent<SpriteRenderer>().sprite = heads[3];
                break;
            default:
                break;
        }
    }

	// Update is called once per frame
	void Update () {

        if (canMove == true)
        {

            gpState = GamePad.GetState(playerIndex);

            if (Input.GetKey(KeyCode.A) || gpState.ThumbSticks.Left.X <= -0.3f)
            {
                anims.CrossFade("left", 0f);
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.D) || gpState.ThumbSticks.Left.X >= 0.3f)
            {
                MoveRight();
                anims.CrossFade("right", 0f);
            }
            if (Input.GetKey(KeyCode.W) || gpState.ThumbSticks.Left.Y >= 0.3f)
            {
                MoveForwards();
                anims.CrossFade("stationary", 0.5f);
            }
            if (Input.GetKey(KeyCode.S) || gpState.ThumbSticks.Left.Y <= -0.3f)
            {
                MoveBackwards();
                anims.CrossFade("stationary", 0.5f);
            }
        }
	
	}

    void MoveLeft()
    {
        transform.position = transform.position - new Vector3(speed/100f,0,0);
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
