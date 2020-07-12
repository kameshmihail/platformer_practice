using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	public bool jump = false;
	bool crouch = false;

	public bool AllowInput = true;

	// Update is called once per frame
	void Update () {
		if (AllowInput)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
				animator.SetBool("Jump", true);
			}

			if (Input.GetButtonDown("Crouch"))
			{
				crouch = true;
			}
			else if (Input.GetButtonUp("Crouch"))
			{
				crouch = false;
			}
		}

	}

	public void OnLanding ()
	{
		animator.SetBool("Jump", false);
	}

	public void OnCrouching (bool checkCrouching)
	{
		animator.SetBool("checkCrouching", checkCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
