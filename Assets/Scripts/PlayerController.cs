using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	private float moveInput = 0f;
	private float step = 1.8f;
	private int frameCount = 10;
	private int velocity = 1;
	private bool boost = false;
	private Vector3 movement;
	private Text scoreText;
	private GameObject retryPanel;
	
	void Start()
	{
		FindGameObjects();
	}
	
	void Update()
	{
		GetInput();
	}
	
	void FixedUpdate()
	{
		AdjustVelocity();
		HandleMovement();
		SetScore();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Car")
		{
			GameOver();
		}
	}
	
	public void Retry()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	private void GetInput()
	{
		if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveInput = -1;
        }
		
        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveInput = 1;
        }
		
		if (Input.GetKey("space"))
		{
			boost = true;
		}
		
		else
		{
			boost = false;
		}
	}
	
	private void HandleMovement()
	{
		movement = Vector3.zero;
		
		if (frameCount - velocity <= 0)
		{
			movement.y = .6f;
			frameCount = 10;
		}
		
		if (moveInput != 0f && transform.position.x * moveInput < step)
		{
			movement.x += step * moveInput;
			moveInput = 0f;
		}
		
		transform.position += movement;
		frameCount --;
	}
	
	private void SetScore()
	{
		scoreText.text = transform.position.y.ToString("#.");
	}
	
	private void FindGameObjects()
	{
		scoreText = GameObject.Find("Score Text").GetComponent<Text>();
		retryPanel = GameObject.Find("Game Over Panel");
		scoreText.text = "";
		retryPanel.SetActive(false);
	}
	
	private void AdjustVelocity()
	{
		if (transform.position.y < 15f && !boost)
		{
			velocity = 1;
		}
		
		else if (transform.position.y < 30f && !boost)
		{
			velocity = 2;
		}
		
		else if (transform.position.y < 45f && !boost)
		{
			velocity = 3;
		}
		
		else if (transform.position.y < 60f && !boost)
		{
			velocity = 4;
		}
		
		else if (transform.position.y < 120f && !boost)
		{
			velocity = 5;
		}
		
		else if (transform.position.y < 240f && !boost)
		{
			velocity = 6;
		}
		
		else if (transform.position.y < 480f && !boost)
		{
			velocity = 7;
		}
		
		else
		{
			velocity = 8;
		}
	}
	
	private void GameOver()
	{
		retryPanel.SetActive(true);
		Time.timeScale = 0f;
	}
}
