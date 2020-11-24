using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveInput = 0f;
	
	void Update()
	{
		moveInput = Input.GetAxis("Horizontal");
	}
	
	void FixedUpdate()
	{
		if (moveInput > 0)
		{
			Debug.Log("MoveInput maior do que zero");
		}
		
		if (moveInput < 0)
		{
			Debug.Log("MoveInput menor do que zero");
		}
	}
}
