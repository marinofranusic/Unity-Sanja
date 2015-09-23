using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Character2d))]
public class RodaMovementScript : MonoBehaviour {

	public Rigidbody2D rbBeba;
	private Character2d character;
	
	private bool imamBebu=true;
	// Use this for initialization
	void Awake () {
		character=GetComponent<Character2d>();
	}
	
	// Update is called once per frame	
	void Update () {
		float h=Input.GetAxis("Horizontal");
		float v=Input.GetAxis("Vertical");
		character.Move(h,v);
		if((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) && imamBebu)
		{
			Shoot ();
		}
	}
	
	void Shoot()
	{
			imamBebu=false;
			rbBeba.isKinematic=false;
			rbBeba.gravityScale=1;
		
	}
}
