using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
	{
		Destroy(col.gameObject);
	}
}
