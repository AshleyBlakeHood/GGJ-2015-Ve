using UnityEngine;
using System.Collections;

public class ControllerTesting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("j1HorizontalLeft"))
            Debug.Log("Joystick 1 Horizontal Left Pressed");

        if (Input.GetButton("j1VerticalLeft"))
            Debug.Log("Joystick 1 Vertical Left Pressed");

        if (Input.GetButton("j1HorizontalRight"))
            Debug.Log("Joystick 1 Horizontal Right Pressed");

        if (Input.GetButton("j1VerticalRight"))
            Debug.Log("Joystick 1 Vertical Right Pressed");

        if (Input.GetButton("j1HorizontalDPad"))
            Debug.Log("Joystick 1 Horizontal DPad Pressed");

        if (Input.GetButton("j1VerticalDPad"))
            Debug.Log("Joystick 1 Vertical DPad Pressed");

        if (Input.GetButton("j1Triggers"))
            Debug.Log("Joystick 1 Triggers Pressed");

        if (Input.GetButton("j1TriggerLeft"))
            Debug.Log("Joystick 1 Trigger Left Pressed");

        if (Input.GetButton("j1TriggerRight"))
            Debug.Log("Joystick 1 Trigger Right Pressed");

        if (Input.GetButton("j1A"))
            Debug.Log("Joystick 1 A Pressed");

        if (Input.GetButton("j1B"))
            Debug.Log("Joystick 1 B Pressed");

        if (Input.GetButton("j1X"))
            Debug.Log("Joystick 1 X Pressed");

        if (Input.GetButton("j1Y"))
            Debug.Log("Joystick 1 Y Pressed");

        if (Input.GetButton("j1LB"))
            Debug.Log("Joystick 1 LB Pressed");

        if (Input.GetButton("j1RB"))
            Debug.Log("Joystick 1 RB Pressed");

        if (Input.GetButton("j1Back"))
            Debug.Log("Joystick 1 Back Pressed");

        if (Input.GetButton("j1Start"))
            Debug.Log("Joystick 1 Start Pressed");

        if (Input.GetButton("j1LeftPressed"))
            Debug.Log("Joystick 1 Left Pressed");

        if (Input.GetButton("j1RightPressed"))
            Debug.Log("Joystick 1 Right Pressed");

	}
}
