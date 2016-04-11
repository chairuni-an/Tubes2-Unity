using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {

	public float scrollSpeed = 0.5F;
	public Renderer rend;
	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		float offset = Time.time * scrollSpeed;
		//rend.material.mainTextureOffset = new Vector2(offset, 0);
		rend.material.mainTextureOffset = new Vector2(0, -offset);
	}

}
