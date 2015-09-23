using UnityEngine;
using System.Collections;

public class MiciNPC : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public Transform igrac;
	
	// Use this for initialization
	private Rigidbody2D rb;
	void Start () {
		rb=GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		float vrijed=transform.position.x-igrac.position.x;
		if(Mathf.Abs(vrijed)<40)
		{
			rb.velocity=new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
		}
		if( vrijed<-80)
			Destroy(gameObject);
	}
}
