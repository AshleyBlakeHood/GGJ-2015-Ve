using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class StartScreenInput : MonoBehaviour {

    GamePadState state1;
    GamePadState state2;
    GamePadState state3;
    GamePadState state4;

    bool p1, p2, p3, p4;
    bool p1Ready, p2Ready, p3Ready, p4Ready;
    int pCount = 0;
    int readyCount = 0;

    public GameObject prompt1, prompt2, prompt3, prompt4;
    public GameObject player1, player2, player3, player4;

    public Sprite start, ready;


	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("P1", 0);
        PlayerPrefs.SetInt("P2", 0);
        PlayerPrefs.SetInt("P3", 0);
        PlayerPrefs.SetInt("P4", 0);

        player1.GetComponent<Animator>().speed = 0;
        player2.GetComponent<Animator>().speed = 0;
        player3.GetComponent<Animator>().speed = 0;
        player4.GetComponent<Animator>().speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        state1 = GamePad.GetState(PlayerIndex.One);
        state2 = GamePad.GetState(PlayerIndex.Two);
        state3 = GamePad.GetState(PlayerIndex.Three);
        state4 = GamePad.GetState(PlayerIndex.Four);

        if (state1.Buttons.A.ToString() == "Pressed" && !p1)
        {
            p1 = true;
            PlayerPrefs.SetInt("P1", 1);
            pCount++;
            prompt1.GetComponent<SpriteRenderer>().sprite = start;
            player1.GetComponent<Animator>().speed = 1;
        }
        if (state2.Buttons.A.ToString() == "Pressed" && !p2)
        {
            p2 = true;
            PlayerPrefs.SetInt("P2", 1);
            pCount++;
            prompt2.GetComponent<SpriteRenderer>().sprite = start;
            player2.GetComponent<Animator>().speed = 1;
        }
        if (state3.Buttons.A.ToString() == "Pressed" && !p3)
        {
            p3 = true;
            PlayerPrefs.SetInt("P3", 1);
            pCount++;
            prompt3.GetComponent<SpriteRenderer>().sprite = start;
            player3.GetComponent<Animator>().speed = 1;
        }
        if (state4.Buttons.A.ToString() == "Pressed" && !p4)
        {
            p4 = true;
            PlayerPrefs.SetInt("P4", 1);
            pCount++;
            prompt4.GetComponent<SpriteRenderer>().sprite = start;
            player4.GetComponent<Animator>().speed = 1;
        }

        if (state1.Buttons.Start.ToString() == "Pressed" && p1 && !p1Ready)
        {
            p1Ready = true;
            readyCount++;
            prompt1.GetComponent<SpriteRenderer>().sprite = ready;
        }
        if (state2.Buttons.Start.ToString() == "Pressed" && p2 && !p2Ready)
        {
            p2Ready = true;
            readyCount++;
            prompt2.GetComponent<SpriteRenderer>().sprite = ready;
        }
        if (state3.Buttons.Start.ToString() == "Pressed" && p3 && !p3Ready)
        {
            p3Ready = true;
            readyCount++;
            prompt3.GetComponent<SpriteRenderer>().sprite = ready;
        }
        if (state4.Buttons.Start.ToString() == "Pressed" && p4 && !p4Ready)
        {
            p4Ready = true;
            prompt4.GetComponent<SpriteRenderer>().sprite = ready;
            readyCount++;
        }

        if (readyCount == pCount && readyCount != 0)
        {
           StartGame();
        }
	}

    void StartGame()
    {
        PlayerPrefs.SetInt("Player Count", pCount);
        Application.LoadLevel("Game Load Scene");
    }
}
