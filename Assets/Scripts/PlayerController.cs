using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveInput = 0f;
	private float step = 2f;
	
	void Update()
	{
		moveInput = Input.GetAxis("Horizontal");
	}
	
	void FixedUpdate()
	{
		if (moveInput > 0f && transform.position.x < step)
		{
			transform.position = new Vector3 (transform.position.x + step, transform.position.y, 0f);
		}
		
		if (moveInput < 0f && transform.position.x > -step)
		{
			transform.position = new Vector3 (transform.position.x - step, transform.position.y, 0f);
		}
	}
}
