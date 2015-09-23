using UnityEngine;
using System.Collections;

public class Strijela : MonoBehaviour {
	public Character2d ch2dObj;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Igrac")
			ch2dObj.PostaviMrtav();
	}
}
