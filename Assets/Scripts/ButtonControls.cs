using UnityEngine;
using System.Collections;

public class ButtonControls : MonoBehaviour {

	public Messanger messanger;
	public Buttons buttons;


	// Use this for initialization
	void Start () {
		// set buttons in place on screen
		var h = Screen.height/4;
		var w = Screen.width/3;
		var jY = Screen.height-h;
		buttons.jumpButton.pixelInset = new Rect(0f,0f,w,h);
		buttons.diveButton.pixelInset = new Rect(Screen.width-(2*w),0f,w,h);
		buttons.attackButton.pixelInset = new Rect(Screen.width-w,0f,w,h);
	}
	
	// Update is called once per frame
	void Update () {
	foreach (Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				var v3 = new Vector3(touch.position.x,touch.position.y,0f);
				if(buttons.jumpButton.HitTest(v3)){
					messanger.jhonny.SendMessage("Jump");
				}
				if(buttons.diveButton.HitTest(v3)){
					messanger.jhonny.SendMessage("Dive");
				}
				if(buttons.attackButton.HitTest(v3)){
					messanger.jhonny.SendMessage("Attack");
				}
			}
		}
	}
}


[System.Serializable]
public class Buttons {
	public GUITexture jumpButton;
	public GUITexture attackButton;
	public GUITexture diveButton;
}