using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public ScrollManager scrollManager;
	public Messanger messanger;

	void Awake (){
		SetTimers();
	}

	void Update () {
		if(Input.GetKeyDown("escape")){
			Application.Quit();
		}
		CountDown();

	}
	

	void SetTimers(){
		SetBrickTimer();
		SetBuildingTimer();
	}
	void SetBrickTimer() {
		scrollManager.brickTimer = Random.Range(scrollManager.brickMinTime,scrollManager.brickMaxTime);
	}
	void SetBuildingTimer () {
		scrollManager.buildingTimer = Random.Range(scrollManager.buildingMinTime,scrollManager.buildingMaxTime);
	}
	void CountDown (){
		scrollManager.brickTimer = scrollManager.brickTimer - Time.deltaTime;
		scrollManager.buildingTimer = scrollManager.buildingTimer - Time.deltaTime;
		if(scrollManager.brickTimer < 0){
			LayBrick();
		}
		if(scrollManager.buildingTimer < 0){
			LayBuilding();
		}
	}
	void LayBrick (){
		var brick = GameObject.Instantiate(scrollManager.brick,new Vector3(14f,3f,0),Quaternion.identity) as GameObject;
		brick.SendMessage("SetGM",this);
		SetBrickTimer();
	}
	void LayBuilding (){
		var building = GameObject.Instantiate(scrollManager.building,new Vector3(12f,0f,0),Quaternion.identity) as GameObject;
		building.SendMessage("SetGM",this);
		SetBuildingTimer();
	}





}



[System.Serializable]
public class ScrollManager{
	public float brickScrollSpeed;
	public GameObject brick;
	public float brickTimer;
	public float brickMinTime;
	public float brickMaxTime;
	public float buildingScrollSpeed;
	public float buildingTimer;
	public float buildingMinTime;
	public float buildingMaxTime;
	public GameObject building;

}


[System.Serializable]
public class Messanger {
	public GameObject jhonny;

}







