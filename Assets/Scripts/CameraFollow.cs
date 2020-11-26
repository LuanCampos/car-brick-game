using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Transform player;
	
	private void Start()
	{
		player = GameObject.Find("Player").GetComponent<Transform>();
	}
	
    private void LateUpdate()
    {
        transform.position = new Vector3(0f, player.position.y + 4f, -10f);
    }
}
