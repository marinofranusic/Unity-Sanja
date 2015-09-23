using UnityEngine;
using System.Collections;

public class fudbalerKolajder : MonoBehaviour {

	public AudioSource zvizd;
	public NogometGameController ngc;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Lopta")
		{
			zvizd.Play();
			Destroy(other.gameObject);
			ngc.DajLoptu();
		}
	}
}
