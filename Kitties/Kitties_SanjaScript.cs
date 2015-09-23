using UnityEngine;
using System.Collections;

public class Kitties_SanjaScript : MonoBehaviour {

	public Vector2 speed;
	
	private Animator anim;
	private bool Upravljiva;
	void Start () {
		anim=GetComponent<Animator>();
		Upravljiva=true;
	}
	
	// Update is called once per frame
	void Update () {
	
		float inputX=Input.GetAxis("Horizontal");
		float inputY=Input.GetAxis("Vertical");
		anim.SetFloat("SpeedX",inputX);
		anim.SetFloat("SpeedY",inputY);
		Vector3 movement=new Vector3(
		speed.x*inputX,
		speed.y*inputY,
		0);
		
		movement*=Time.deltaTime;
		if(Upravljiva)
			transform.Translate(movement);
	}
	
	void FixedUpdate()
	{
		float lastInputX=Input.GetAxis("Horizontal");
		float lastInputY=Input.GetAxis("Vertical");
		
		if(Upravljiva)
		{
			if(lastInputX!=0 || lastInputY!=0)
			{
				anim.SetBool("walking", true);
			}
			else
			{
				anim.SetBool("walking",false);
			}
		}
		else
		{
			anim.SetBool("walking",false);
		}
	}
	
	public void ToggleUpravljiva()
	{
		Upravljiva=false;
	}
}
