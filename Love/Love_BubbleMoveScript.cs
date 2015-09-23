using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Love_BubbleMoveScript : MonoBehaviour {
	
	public Slider slajder;
	
	private float speedFactor_x=1.0f;
	private float speedFactor_y=1.0f;
	private float brojac;
	private bool BrojacBroji;
	private bool MoguMicatiMjehur;
	private float DanoVrijeme=2.0f;
	private float CoolDown=3.0f;
	// Use this for initialization
	void Start () {
		brojac=0;
		BrojacBroji=false;
		MoguMicatiMjehur=true;
	}
	
	void FixedUpdate()
	{
		if(BrojacBroji)
			brojac+=Time.deltaTime;
		int tmpInt=Mathf.RoundToInt (brojac);
		if(MoguMicatiMjehur==true && tmpInt>=DanoVrijeme)
		{
			MoguMicatiMjehur=false;
			brojac=0;
		}
		if(MoguMicatiMjehur==false && tmpInt>=CoolDown)
		{
			MoguMicatiMjehur=true;
			brojac=0;
			BrojacBroji=false;
		}
		if(MoguMicatiMjehur==true)
		{
			slajder.value=(float)slajder.maxValue-brojac*1.5f;
		}
		else
		{
			slajder.value=brojac;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 pz2=new Vector2(pz.x,pz.y);
		Vector2 tr2=new Vector2(transform.position.x,transform.position.y);
		float udaljenost=Vector2.Distance(pz2,tr2);
		float a=renderer.bounds.extents.x*3;
		int sp_x,sp_y;
		sp_x=0;
		sp_y=0;
		if(udaljenost<a)
		{
			if(MoguMicatiMjehur)
			{
				BrojacBroji=true;
				if(pz2.x<tr2.x)
					sp_x=1;
				if(pz2.x>tr2.x)
					sp_x=-1;
				if(pz2.y<tr2.y)
					sp_y=1;
				if(pz2.y>tr2.y)
					sp_y=-1;
				rigidbody2D.velocity=new Vector2(sp_x*speedFactor_x,sp_y*speedFactor_y);
			}
		}
		//Debug.Log("Brojac "+brojac.ToString());
	}
}
