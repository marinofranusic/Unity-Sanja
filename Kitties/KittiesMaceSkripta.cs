using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KittiesMaceSkripta : MonoBehaviour {

	public GameObject sanja;
	public GameObject marker;
	public float speed;
	public KittiesGameController gc;
	
	
	private Animator anim;
	private float lastPosX;
	private float lastPosY;
	private bool vidimSanju;
	void Start()
	{
		anim=GetComponent<Animator>();
		lastPosX=transform.position.x;
		lastPosY=transform.position.y;
		vidimSanju=false;
		
	}
	
	void FixedUpdate()
	{
		float udaljenost=Vector3.Distance(transform.position,sanja.transform.position);
		//gc.Poruka("Udalj:"+udaljenost+"Scr:"+Screen.width/20);
		if(udaljenost<renderer.bounds.extents.x*4)
			vidimSanju=true;
		
		float step = speed * Time.deltaTime;
		Vector3 target;
		if(vidimSanju)
		{
			Vector3 sanjaTarget=new Vector3(sanja.transform.position.x-2*sanja.renderer.bounds.extents.x,
							sanja.transform.position.y-2*sanja.renderer.bounds.extents.y,
							0.0f);
			target=sanjaTarget;
		}
		else
		{					
			Vector3 markerTarget=new Vector3(marker.transform.position.x-2*marker.renderer.bounds.extents.x,
		                                 marker.transform.position.y-2*marker.renderer.bounds.extents.y,
		                                 0.0f);
		    target=markerTarget;
		}
		
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		
		float razX=transform.position.x-lastPosX;
		float razY=transform.position.y-lastPosY;
		
		//txtPoruka.text="X1:"+lastPosX+" X2:"+transform.position.x+"Raz:"+razX+"\n"+
		//				"Y1:"+lastPosY+" Y2:"+transform.position.y+"Raz:"+razY;
		
		if(razX!=0 || razY!=0)
		{
			anim.SetBool("walking",true);
			if(Mathf.Abs(razX)>=Mathf.Abs(razY))
			{
				if(transform.position.x<lastPosX)
				{
					anim.SetFloat("speedX",-1);
					anim.SetFloat("speedY",0);
				}
				else if(transform.position.x>lastPosX)
				{
					anim.SetFloat("speedX",1);
					anim.SetFloat("speedY",0);
				}
				else
					anim.SetFloat("speedX",0);
			}
			if(Mathf.Abs(razX)<Mathf.Abs(razY))
			{
				if(transform.position.y<lastPosY)
				{
					anim.SetFloat("speedY",-1);
					anim.SetFloat("speedX",0);
				}
				else if(transform.position.y>lastPosY)
				{
					anim.SetFloat("speedY",1);
					anim.SetFloat("speedX",0);
				}
				else
					anim.SetFloat("speedY",0);
			}
		}
		else
		{
			anim.SetBool("walking",false);
		}
		
		lastPosX=transform.position.x;
		lastPosY=transform.position.y;
		
	}
}
