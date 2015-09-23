using UnityEngine;
using System.Collections;

public class Love_SlotScript : MonoBehaviour {
	public string TagZaSlot;
	public LoveGameControllerScript gc;
	private bool Pogodjen=false;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag==TagZaSlot && !Pogodjen)
		{
			Destroy(other.gameObject);
			TocanSlot();
			Pogodjen=true;
		}
		else
		{
			Destroy(other.gameObject);
			gc.BubbleDestroyed();
		}
	}
	
	void TocanSlot()
	{
		//javiti game controlleru da je bubble u dobrom slotu
		//povecati ovaj slot
		gc.TocanSlot();
		transform.localScale=new Vector3(0.3f,0.3f,1.0f);
	}
	
}
