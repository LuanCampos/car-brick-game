using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveInput = 0f;
	private float step = 1.8f;
	private int frameCount = 10;
	private int velocity = 1;
	private Vector3 movement;
	
	void Update()
	{
		if(Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveInput = -1;
        }
		
        if(Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveInput = 1;
        }
		
		AdjustVelocity();
		
		if (Input.GetKey("space"))
		{
			if (velocity < 8)
			{
				velocity = 8;
			}
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
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Car")
		{
			GameOver();
		}
	}
	
	private void AdjustVelocity()
	{
		if (transform.position.y < 15f && velocity != 1)
		{
			velocity = 1;
		}
		
		else if (transform.position.y < 30f && velocity != 2)
		{
			velocity = 2;
		}
		
		else if (transform.position.y < 45f && velocity != 3)
		{
			velocity = 3;
		}
		
		else if (transform.position.y < 60f && velocity != 4)
		{
			velocity = 4;
		}
		
		else if (transform.position.y < 120f && velocity != 5)
		{
			velocity = 5;
		}
		
		else if (transform.position.y < 240f && velocity != 6)
		{
			velocity = 6;
		}
		
		else if (transform.position.y < 480f && velocity != 7)
		{
			velocity = 7;
		}
		
		else if (velocity != 8)
		{
			velocity = 8;
		}
	}
	
	private void GameOver()
	{
		Time.timeScale = 0f;
	}
}
