using UnityEngine;
using System.Collections;

public class Party_BoozeDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
