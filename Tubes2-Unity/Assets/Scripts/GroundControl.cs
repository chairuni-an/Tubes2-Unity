using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {

	float scrollSpeed = 0.5F;
	Renderer rend;
	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		float offset = Time.time * scrollSpeed;
		rend.material.mainTextureOffset = new Vector2(0, -offset);
	}

}
