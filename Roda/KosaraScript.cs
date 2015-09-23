using UnityEngine;
using System.Collections;

public class KosaraScript : MonoBehaviour {
	public Character2d ch2dObj;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Beba")
		{
			ch2dObj.PostaviPobjeda();
			Destroy(other.gameObject);
		}
	}
}
