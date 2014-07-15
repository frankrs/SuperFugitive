using UnityEngine;
using System.Collections;

public class Jhonny : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rigid;
	private float startX;
	public bool grounded;
	public LayerMask groundLayers;
	public Floor floor;
	public enum Floor{
		ground,
		brick,
		air
	}
	public float fallbackSpeed;
	public GameManager gameManager;


	void Start () {
		anim = GetComponent<Animator>();
		rigid = GetComponent<Rigidbody2D>();
		startX = transform.position.x;
	}
	


	void Update(){
		GroundTest();
		anim.SetBool("Grounded",grounded);
		if(floor == Floor.ground){
			//var x = transform.position.x;
			//Mathf.Lerp(x,startX,fallbackSpeed * Time.deltaTime);
			//transform.position = new Vector3(Mathf.Lerp(x,startX,fallbackSpeed * Time.deltaTime),transform.position.y,transform.position.z);
			if(transform.position.x > startX){
				var x = transform.position.x;
				x = x - fallbackSpeed * Time.deltaTime;
				transform.position = new Vector3(x,transform.position.y,transform.position.z);
			}
			if(transform.position.x < startX){
				var x = transform.position.x;
				x = x + fallbackSpeed * Time.deltaTime;
				transform.position = new Vector3(x,transform.position.y,transform.position.z);
			}
		}
	}

//	void FixedUpdate(){
//		if(floor == Floor.brick){
//			rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(-gameManager.scrollManager.brickScrollSpeed * Time.deltaTime,0));
//		}
//
//	}

//	void OnCollisionEnter2D(Collision2D col){
//		if(col.gameObject.tag == "Ground"){
//			grounded = true;
////			if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump")){
////				Debug.Log("landy");
////				//anim.SetBool("Grounded",true);
////				anim.SetTrigger("Grounded");
////			}
//
//		}
//	}
//
//
//	void OnCollisionExit2D(Collision2D col){
//		if(col.gameObject.tag == "Ground"){
//			grounded = false;
//		}
//	}
//
//
//
//	void OnCollisionStay2D(Collision2D col){
//		Debug.Log(col.gameObject);
//		if(col.gameObject.tag == "Ground"){
//			grounded = true;
//			}
//	}


	void GroundTest (){
		RaycastHit2D hit = Physics2D.Raycast(gameObject.collider2D.transform.position,-Vector2.up,1.05f,groundLayers);
		if(hit.collider == null){
			grounded = false;
			floor = Floor.air;
		}
		else{
			grounded = true;
			var f = hit.collider.tag;
			if(f == "Ground"){
				floor = Floor.ground;
			}
			else if(f == "Brick"){
				floor = Floor.brick;
			}
		}

	}

	void Jump (){
		if(grounded == false){
			return;
		}
		anim.SetTrigger("Jump");
		rigid.AddForce(new Vector2(0f,450f));
	}


	void Dive (){
		rigid.AddForce(new Vector2(350f,-650f));
	}

	void Attack (){
		//Debug.Log("fwd");
		anim.SetTrigger("Attack");
		//rigid.AddForce(new Vector2(150f,0f));
	}



}
