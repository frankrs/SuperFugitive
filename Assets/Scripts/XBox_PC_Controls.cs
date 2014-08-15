using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]

public class XBox_PC_Controls : MonoBehaviour {

	public UserInput userInput;

	private Movement movement;

	void Awake(){
		movement = GetComponent<Movement>();
	}

	void Update () {
		// get axis and bool from input manager
		GetControls();

		//set the movement input variable class
		movement.userInput = userInput;
	}

	void GetControls(){
		userInput.hA = Input.GetAxis("Horizontal");
		userInput.vA = Input.GetAxis("Vertical");
		userInput.jB = Input.GetButton("Jump");
		userInput.jBD = Input.GetButtonDown("Jump");
	}
}
