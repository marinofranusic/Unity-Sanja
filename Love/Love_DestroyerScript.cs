using UnityEngine;
using System.Collections;

public class Love_DestroyerScript : MonoBehaviour {
	public LoveGameControllerScript gc;
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
		gc.BubbleDestroyed();
	}
}
