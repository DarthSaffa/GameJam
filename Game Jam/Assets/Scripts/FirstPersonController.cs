using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	
	Transform myTransform;

	public float movementSpeed = 5;
	public int walkSpeed = 5;
	public int sprintSpeed = 10;
	public int mouseSensitivity = 5;
	public int jumpSpeed = 20;

	float verticalRotation = 0;
	public float upDownRange = 90;
	
	float verticalVelocity = 0;
	
	CharacterController characterController;
	
	// Use this for initialization
	void Start () {

		myTransform = transform;
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// Rotation

		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		myTransform.Rotate(0, rotLeftRight, 0);

		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		

		// Movement
		
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
		if( characterController.isGrounded && Input.GetButton("Jump") ) {
			verticalVelocity = jumpSpeed;
		}

		if (Input.GetButton ("Fire3")) {
			movementSpeed += 2*Time.deltaTime;
		} else {
			movementSpeed -= 2*Time.deltaTime;
		}
		
		Vector3 speed = new Vector3( sideSpeed, verticalVelocity, forwardSpeed );
		
		speed = myTransform.rotation * speed;
		
		
		characterController.Move( speed * Time.deltaTime );

		if(movementSpeed > sprintSpeed){
			movementSpeed = sprintSpeed;
		}
		if(movementSpeed < walkSpeed){
			movementSpeed = walkSpeed;
		}
	}
}
