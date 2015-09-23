using UnityEngine;
using System.Collections;

public class DaljeScript : MonoBehaviour {

	public void Dalje()
	{
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
	public void PonoviNivo()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
