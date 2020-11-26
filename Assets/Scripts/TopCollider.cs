using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollider : MonoBehaviour
{
	[SerializeField] private GameObject carPrefab = null;
	[SerializeField] private GameObject trackPrefab = null;
	[SerializeField] private GameObject topColliderPrefab = null;
	
    private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			SpawnTrack();
			SpawnCar();
			SpawnCollider();
			Destroy(gameObject);
		}
	}
	
	private void SpawnTrack()
	{
		Instantiate(trackPrefab, new Vector3(0, transform.position.y + 12f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
	}
	
	private void SpawnCollider()
	{
		Instantiate(topColliderPrefab, new Vector3(0, transform.position.y + 12f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
	}
	
	private void SpawnCar()
	{
		if (transform.position.y < 120f)
		{
			switch (Random.Range(1,4))
			{
			case 3:
				InstantiateCar(1.8f);
				break;
			case 2:
				InstantiateCar(0f);
				break;
			default:
				InstantiateCar(-1.8f);
				break;
			}
		}
		
		else if (transform.position.y < 240f)
		{
			switch (Random.Range(1,7))
			{
			case 6:
				InstantiateCar(1.8f);
				break;
			case 5:
				InstantiateCar(0f);
				break;
			case 4:
				InstantiateCar(-1.8f);
				break;
			case 3:
				InstantiateCar(-1.8f);
				InstantiateCar(1.8f);
				break;
			case 2:
				InstantiateCar(0f);
				InstantiateCar(1.8f);
				break;
			default:
				InstantiateCar(-1.8f);
				InstantiateCar(0f);
				break;
			}
		}
		
		else
		{
			switch (Random.Range(1,4))
			{
			case 3:
				InstantiateCar(-1.8f);
				InstantiateCar(1.8f);
				break;
			case 2:
				InstantiateCar(0f);
				InstantiateCar(1.8f);
				break;
			default:
				InstantiateCar(-1.8f);
				InstantiateCar(0f);
				break;
			}
		}
	}
	
	private void InstantiateCar(float index)
	{
		Instantiate(carPrefab, new Vector3(index, transform.position.y + 14.4f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
