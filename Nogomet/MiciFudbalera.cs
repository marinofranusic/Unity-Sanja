using UnityEngine;
using System.Collections;

public class MiciFudbalera : MonoBehaviour {

	// Use this for initialization
	private bool goingUp=true;
	
	private float krajnja;
	private float brzina;
	private float minSpeed;
	
	private bool radi;
	void Start () {
		
		krajnja=Random.Range(1,7);
		brzina=Random.Range(1,5);
	}
	
	// Update is called once per frame
	void Update () {
		if(radi)
		{
			if(goingUp==true)
			{
				if(transform.position.y>=krajnja)
					SwitchSmjer();
				transform.Translate(0,brzina*Time.deltaTime,0);		
			}
			else
			{
				if(transform.position.y<=krajnja)
					SwitchSmjer();
				transform.Translate(0,-brzina*Time.deltaTime,0);
			}
		}
	}
	
	void SwitchSmjer()
	{
		if(goingUp)
		{
			goingUp=false;
			krajnja=Random.Range(-5,-2);
			brzina=Random.Range(minSpeed,5);
		}
		else
		{
			goingUp=true;
			krajnja=Random.Range(1,7);
			brzina=Random.Range(minSpeed,5);
		}
	}
	
	public void SetMinSpeed(int num)
	{
		minSpeed=num;
	}
	
	public void Mici(bool daNE)
	{
		radi=daNE;
	}
}
