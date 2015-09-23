using UnityEngine;
using System.Collections;

public class Kittie_House : MonoBehaviour {

	public KittiesGameController gc;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Maca")
		{
			Destroy(other.gameObject);
			gc.PovecajBroj();
		}
	}
}
