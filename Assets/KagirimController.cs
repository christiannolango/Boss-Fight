using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagirimController : MonoBehaviour {
	//Animation
	public Animator anim;
	// Movement
	public float speed = 1000.0F;
	public float jumpSpeed = 60.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	//rotation
	public float speedH = 2.0f;
	private float yaw = 0.0f;

	void Start () {
		anim = anim.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
		//Movement
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			//Animation
			if (Input.GetAxis ("Vertical")!=0) {
				anim.SetBool ("IsWalking", true);

			}
			if (Input.GetAxis ("Vertical")==0) {
				anim.SetBool ("IsWalking", false);


				if (Input.GetMouseButtonUp (1)) { //if right mouse click then trigger right jab animation
					anim.SetTrigger ("JabRight");
				}
			}
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;


			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
				anim.SetTrigger ("JumpR");
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		//rotation
		yaw += speedH * Input.GetAxis("Mouse X");
		transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
	}
}
