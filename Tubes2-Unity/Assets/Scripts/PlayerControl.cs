﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	CharacterController controller;
	bool isGrounded= false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public GameControlScript control;
	private Vector3 moveDirection = Vector3.zero;
	
	//start 
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update (){
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 
			
			if(controller.isGrounded) {          //set the flag isGrounded to true if character is grounded
				isGrounded = true;
				GetComponent<Animator>().SetBool("OnGround",true);
			}
			if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed;
				moveDirection.y = jumpSpeed; //add the jump height to the character
				GetComponent<Animator>().SetBool("OnGround",false);
			}
		}
		
		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move(moveDirection * Time.deltaTime);      //Move the controller
	}
	
	//check if the character collects the powerups or the snags
	void OnTriggerEnter(Collider other)
	{               
		if(other.gameObject.name == "PowerupPrestasi(Clone)")
		{
			control.PowerupTimeCollected();
		}
		else if((other.gameObject.name == "ObstaclePelanggaran1(Clone)" || other.gameObject.name == "ObstaclePelanggaran2(Clone)") && isGrounded == true)
		{
			control.ObstacleTimeCollected();
		}else if(other.gameObject.name == "PowerupIP(Clone)")
		{
			control.PowerupLiveCollected();
		}
		else if(other.gameObject.name == "ObstacleMengulang(Clone)" && isGrounded == true)
		{
			control.ObstacleLiveCollected();
		}
		
		Destroy(other.gameObject);
		
	}
}