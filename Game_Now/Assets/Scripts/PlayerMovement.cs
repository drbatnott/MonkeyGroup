using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveVector;
	private float speed = 5.0f;
	private float verticalVelcoity = 0.0f;
	private float gravity = 12.0f;
	// Use this for initialization
	void Start () {

		controller = GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		moveVector = Vector3.zero;

		if (controller.isGrounded) {
			verticalVelcoity = -0.5f;
		} else {
			verticalVelcoity -= gravity *Time.deltaTime;
		}
	


		//X LEFT and Right
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

		//Y UP and Down
		moveVector.y = verticalVelcoity;

		//Z Forward and back
		moveVector.z = speed;
		controller.Move (moveVector * Time.deltaTime);
		
	}
}
