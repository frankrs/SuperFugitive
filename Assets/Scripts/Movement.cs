using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]

public class Movement : MonoBehaviour {

	public SpeedSettings speedSettings;
	public UserInput userInput;
	public Ground ground;


	private Animator anim;


	void Awake(){
		anim = GetComponent<Animator>();
	}





	void FixedUpdate (){
		// get the hovizontal input and flips the guy to face direction
		if(userInput.hA > .1){
			transform.localScale = new Vector3(1f,1f,1f);
			if(ground.isGrounded){
				anim.SetBool("Run",true);
			}
		}
		else if(userInput.hA < -.1){
			transform.localScale = new Vector3(-1f,1f,1f);
			if(ground.isGrounded){
				anim.SetBool("Run",true);
			}
		}
		else{
			if(ground.isGrounded){
				anim.SetBool("Run",false);
			}
		}


		// move guy acrording to input and gravity
		rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(userInput.hA * speedSettings.speed * Time.deltaTime , speedSettings.gravity * Time.deltaTime));

		// see if were on the ground
		ground.isGrounded = TestGround();
	}




	void Update(){
		// jump if button is pressed and grounded
		if(ground.isGrounded && userInput.jBD){
			StartCoroutine("Jump");
		}
	}



	IEnumerator Jump (){
		var t = speedSettings.jumpTime;
		speedSettings.gravity = 0;
		anim.SetBool("Jump",true);
		while(t > 0 && userInput.jB){
			speedSettings.gravity = speedSettings.gravity + (Time.deltaTime * speedSettings.gravityMult);
			t = t-Time.deltaTime;
			yield return null;
		}
		while(ground.isGrounded == false){
			speedSettings.gravity = speedSettings.gravity - (Time.deltaTime * speedSettings.gravityMult);
			yield return null;
		}
		anim.SetBool("Jump",false);
		speedSettings.gravity = -10;
	}






	public bool TestGround(){
		if(Physics2D.Raycast(transform.position, -Vector2.up, ground.groundDist, ground.groundLayer)){
			return true;
		}
		else
		{
			return false;
		}
	}

}


[System.Serializable]
public class UserInput{
	public float hA;
	public float vA;
	public bool rB;
	public bool jB;
	public bool jBD;
}

[System.Serializable]
public class SpeedSettings{
	public float speed = 10f;
	public Vector2 maxVel = new Vector2(1f,1f);
	public float gravity = -1;
	public float gravityMult = 100;
	public float jumpTime = 1f;
}


[System.Serializable]
public class Ground{
	public bool isGrounded;
	public LayerMask groundLayer;
	public float groundDist = 1f;
}


