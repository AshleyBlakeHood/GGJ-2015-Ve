using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PrisonerController : MonoBehaviour
{
    GameManager gameManager;

    public float speed = 10;
    int playerID;
    GamePadState gpState;
    PlayerIndex playerIndex;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        gameManager.players.Add(this);
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
    }
	
	// Update is called once per frame
	void Update () {

        gpState = GamePad.GetState(playerIndex);

        if (Input.GetKey(KeyCode.A) || gpState.ThumbSticks.Left.X <= -0.3f)
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D) || gpState.ThumbSticks.Left.X >= 0.3f)
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W) || gpState.ThumbSticks.Left.Y >= 0.3f)
        {
            MoveForwards();
        }
        if (Input.GetKey(KeyCode.S) || gpState.ThumbSticks.Left.Y <= -0.3f)
        {
            MoveBackwards();
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
