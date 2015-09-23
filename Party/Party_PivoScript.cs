using UnityEngine;
using System.Collections;

public class Party_PivoScript : MonoBehaviour {

	public PartyGameController gc;
	public int Identifikator;
	void OnMouseDown()
	{
		gc.PritisnutaCuga(Identifikator);
		Destroy(gameObject);
	}
}
