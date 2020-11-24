using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveInput = 0f;
	private float step = 1.8f;
	private bool isMoving = false;
	
	void Update()
	{
		if (isMoving == false)
		{
			moveInput = Input.GetAxis("Horizontal");
			isMoving = true;
		}
		
		if (Input.GetAxis("Horizontal") == 0f && isMoving == true)
		{
			isMoving = false;
		}
	}
	
	void FixedUpdate()
	{
		if (moveInput > 0f && transform.position.x < step)
		{
			transform.position = new Vector3 (transform.position.x + step, transform.position.y, 0f);
			moveInput = 0f;
		}
		
		if (moveInput < 0f && transform.position.x > -step)
		{
			transform.position = new Vector3 (transform.position.x - step, transform.position.y, 0f);
			moveInput = 0f;
		}
	}
}
