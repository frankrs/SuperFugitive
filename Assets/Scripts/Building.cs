using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	public GameManager gameManager;


	void SetGM (GameManager gm) {
		gameManager = gm;
	}

	void Awake () {
		transform.localScale  = new Vector2 (Random.Range(.75f,1.25f),Random.Range(.75f,1.25f));
	}
	

	void LateUpdate () {
		transform.Translate(-gameManager.scrollManager.buildingScrollSpeed * Time.deltaTime,0f,0f);
		if(transform.position.x < - 20f){
			Destroy(gameObject);
		}
	}
}
