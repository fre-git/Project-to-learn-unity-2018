using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CursorMode))]
[RequireComponent (typeof (plGravity))]

public class firstPersonController : MonoBehaviour {
	
	// public vars
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
	public float walkSpeed;
	public float sprintSpeed;
	public float sprintSpeedNorm;
	public float jumpForce;
	public float runningJumpForce;
	public LayerMask groundedMask;
	
	
	
	// System vars
	public bool grounded;
	bool running = false;
	public bool jumping = false;
	public bool moving = false;
	public bool runForT = false;
	private float t = 0.0f;
	//private CharacterController characterController;
	//private float inputX = 0;
	//private float inputY = 0;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	float horizontalLookRotation;
	float verticalLookRotation;
	Transform cameraTransform;
	Rigidbody rigidbody;
	
	
	void Awake() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cameraTransform = Camera.main.transform;
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	void Update() {
		
		
		//Look rotation:
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation,-60,60);
		cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
		
		
		// Calculate movement:
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
				
		Vector3 moveDir = new Vector3(inputX,0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
	
		
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);

		//if(!right && !left && !up && !down)
	//	{
	//		moving = true;
	//	}
		
		// mouseactivation
		
		if (Input.GetButton("Activate"))
			{
				//GetComponent<Renderer>().material.color = Color.green;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		else
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		
			
	
		
		// Jump
		if (Input.GetButtonDown("Jump"))
		{
			if (grounded)
			{
				if (runForT)
				{
					jumping = true;
					rigidbody.AddForce(transform.up * runningJumpForce);
				}
				else
				{
					jumping = true;
					rigidbody.AddForce(transform.up * jumpForce);
				}
			}
		}
		else
		{
			jumping = false;
		}

	
		
	
		
		// Grounded 
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, 1 + .99f, groundedMask)) {
			grounded = true;
		}
		else {
			grounded = false;
		}
		
	}
	
	
	void FixedUpdate() {

		// Grounded 
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, 1 + .02f, groundedMask)) {
			grounded = true;
		}
		else {
			grounded = false;
		}


		if ((Input.GetAxisRaw("Horizontal") != 0) || Input.GetAxisRaw("Vertical") != 0) // || inputY > 0)
		{
			//t = t + Time.deltaTime;
			//if (t > 2f)
			{
				moving = true;
			}
		}
		else
		{
			moving = false;
			//t = 0f;
			//Debug.Log("Not moving");
		}


		if (moving && running)
		{
			t = t + Time.deltaTime;
			if (t > 0.5f)
			{
				runForT = true;
			}
		}
		else// if (t < 1f)
		{
			t = 0f;
			runForT = false;
		}
					
		
		if (Input.GetButton("Fire3"))
		{
			running = true;
			walkSpeed = sprintSpeed;
		}
		else
		{
			running = false;
			walkSpeed = 5;
		}

		

		// Apply movement to rigidbody
		
		
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);
	}
}