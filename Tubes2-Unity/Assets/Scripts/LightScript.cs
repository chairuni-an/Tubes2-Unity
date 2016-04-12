using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {
	public float objectSpeed = 0.00001f;
	float degree = 0;
	
	void Update () {
		Vector3 temp = transform.rotation.eulerAngles;
		degree = (degree+objectSpeed)%360f;
		transform.localEulerAngles = new Vector3(30,degree,0);
	}
}
