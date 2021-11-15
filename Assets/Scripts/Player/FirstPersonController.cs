using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

	[Range(1f, 5f)]
	public float MovementSpeed = 1f;

	[Range(1, 500f)]
	public float LookSensitivity = 200f;

	[Range(1, 500f)]
	public float MouseSensitivity = 3;

	[Range(1, 100f)]
	public float JumpStrength = 2f;

	private CharacterController characterController;
	private Transform cameraTransform;

	private float cameraTilt = 0f;
	private float verticalSpeed = 0f;
	private float timeInAir = 0f;
	private bool jumpLocked = false;

	public LayerMask CollisionLayers;
	
	void OnEnable() {
		characterController = GetComponent<CharacterController>();
		cameraTransform = GetComponentInChildren<Camera>().transform;
		cameraTilt = cameraTransform.localRotation.eulerAngles.x;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
		bool touchesGround = onGround();
		float runMultiplier = 1f + 2f * Input.GetAxis("Run");
		float y = transform.position.y;
		Vector3 movementVector = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
		if (movementVector.sqrMagnitude > 1) {
			movementVector.Normalize();  // this prevents diagonal movement form being too fast
		}
		characterController.Move(movementVector * Time.deltaTime * MovementSpeed * runMultiplier);
		float verticalMovement = transform.position.y - y;
		if (verticalMovement < 0) {
			transform.position += Vector3.down * verticalMovement;
		}
		transform.localRotation = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * MouseSensitivity, Vector3.up) * transform.rotation;
		cameraTilt = Mathf.Clamp(cameraTilt - Input.GetAxis("Mouse Y") * MouseSensitivity, -90f, 90f);
		cameraTransform.localRotation = Quaternion.AngleAxis(cameraTilt, Vector3.right);

		if (touchesGround) {
			timeInAir = 0;
		} else {
			timeInAir += Time.deltaTime;
		}

		if (touchesGround && verticalSpeed < 0) {
			verticalSpeed = 0;
		} else {
			verticalSpeed -= 9.18f * Time.deltaTime;
		}
		if (Input.GetAxisRaw("Jump") < 0.1f) {
			jumpLocked = false;
		}
		if (!jumpLocked && timeInAir < 0.5f && Input.GetAxisRaw("Jump") > 0.1f) {
			timeInAir = 0.5f;
			verticalSpeed = JumpStrength;
			jumpLocked = true;
		}
		
		characterController.Move(Vector3.up * Time.deltaTime * verticalSpeed);
	}

	public void Enable() {
		verticalSpeed = 0;
	}

	private bool onGround() {
		var ray = new Ray(transform.position, Vector3.down);
		return Physics.SphereCast(ray, characterController.radius, characterController.height / 2 - characterController.radius + 0.1f, CollisionLayers);
	}
}
