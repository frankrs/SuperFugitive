using UnityEngine;
using System.Collections;

public class FollowGuy : MonoBehaviour {

	public Transform guyTransform;
	

	void LateUpdate () {
		Vector3 v;
		v = new Vector3(guyTransform.position.x,transform.position.y,transform.position.z);
		transform.position = v;
	}
}
