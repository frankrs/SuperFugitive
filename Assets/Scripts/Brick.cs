using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	public GameManager gameManager;


	void SetGM (GameManager gm) {
		gameManager = gm;
	}

	void LateUpdate () {
		transform.Translate(-gameManager.scrollManager.brickScrollSpeed * Time.deltaTime,0f,0f);
		if(transform.position.x < - 20f){
			Destroy(gameObject);
		}
	}
}
