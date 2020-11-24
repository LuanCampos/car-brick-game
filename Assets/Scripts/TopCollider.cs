using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollider : MonoBehaviour
{
	public GameObject carPrefab;
	public GameObject trackPrefab;
	public GameObject topColliderPrefab;
	
    void OnTriggerEnter2D(Collider2D col)
	{
		Instantiate(trackPrefab, new Vector3(0, transform.position.y + 12f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
		Instantiate(topColliderPrefab, new Vector3(0, transform.position.y + 12f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
		Destroy(gameObject);
	}
}
