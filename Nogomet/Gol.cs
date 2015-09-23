using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gol : MonoBehaviour {
	
	public AudioSource zvizd;
	public NogometGameController ngc;
	public Text txtPoruka;
	void OnTriggerEnter2D(Collider2D other)
	{
		txtPoruka.text=(int.Parse(txtPoruka.text)+1).ToString();
		zvizd.Play();
		Destroy(other.gameObject);
		ngc.DajLoptu();
	}
}
