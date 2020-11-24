using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveInput = 0f;
	private float step = 1.8f;
	private int frameCount = 10;
	private int velocity = 1;
	private bool isMoving = false;
	private Vector3 movement;
	
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
		movement = Vector3.zero;
		
		if (frameCount - velocity <= 0)
		{
			movement.y = .6f;
			frameCount = 10;
		}
		
		if (moveInput > 0f && transform.position.x < step)
		{
			movement.x += step;
			moveInput = 0f;
		}
		
		if (moveInput < 0f && transform.position.x > -step)
		{
			movement.x -= step;
			moveInput = 0f;
		}
		
		transform.position += movement;
		frameCount --;
	}
}
