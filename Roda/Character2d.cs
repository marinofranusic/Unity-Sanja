using UnityEngine;
using System.Collections;

public class Character2d : MonoBehaviour {

	public Camera cam;
	bool facingRight = true;
	public float maxSpeed=10f;
	public GameController gc;
	public Transform qTrans;
	
	private bool alive=true;
	private float maxHeight;
	private float maxWidth;
	private Animator anim;
	private bool pobjeda=false;
	// Use this for initialization
	void Start () {
		Vector3 upperCorner=new Vector3(Screen.width,Screen.height,0.0f);
		Vector3 targetSize=cam.ScreenToWorldPoint(upperCorner);
		maxHeight=targetSize.y-renderer.bounds.extents.y;
		anim=GetComponent<Animator>();
		maxWidth=targetSize.x;
	}
	
	void FixedUpdate()
	{
		if(transform.position.y>=maxHeight)
			transform.position=new Vector3(transform.position.x,maxHeight,transform.position.z);
		if(transform.position.y<=-maxHeight)
		{
			alive=false;
			return;	
		}
		
		if(transform.position.x<=-maxWidth)
			transform.position=new Vector3(-maxWidth,transform.position.y,transform.position.z);
		
			
		if(transform.position.x>=qTrans.position.x)
		{
			transform.position=new Vector3(qTrans.position.x,transform.position.y,transform.position.z);
			
			}
		//gc.SetTekst("Pos: "+transform.position.x+" MW:"+maxWidth); 
		transform.rotation=Quaternion.identity;
		//gc.SetTekst("X:"+transform.position.x);
	}
	
	public void Move(float moveLR, float moveUD)
	{
		
		if(alive)
		{
			rigidbody2D.velocity=new Vector2(moveLR * maxSpeed,moveUD * maxSpeed);
			
			if (moveLR >0 && !facingRight)
				Flip();
			else if(moveLR<0 && facingRight)
				Flip();
		}
		else
		{
			rigidbody2D.velocity=new Vector2(0,0);
			anim.speed=0;
		}
			
	}
	
	public bool JesiZiv()
	{
		return alive;
	}
	
	public void PostaviMrtav()
	{
		alive=false;
	}
	
	public bool JelPobjeda()
	{
		return pobjeda;
	}
	
	public void PostaviPobjeda()
	{
		pobjeda=true;
	}
	
	void Flip()
	{
		facingRight=!facingRight;
		Vector3 theScale=transform.localScale;
		theScale.x*=-1;
		transform.localScale=theScale;
	}
	
}
