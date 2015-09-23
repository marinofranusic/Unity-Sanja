using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fudbalerkaDragging : MonoBehaviour {

	public Slider snaga;
	
	private bool clickedOn;
	private float timePressed;
	
	void Awake()
	{
		
	}
	
	void Start () {
		//rayToMouse = new Ray(transform.position, Vector3.zero);
		timePressed=0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (clickedOn)
		{
			timePressed+=Time.deltaTime;
			if(timePressed>1)
				timePressed=0;
			snaga.value=timePressed;
		}
		
	}
	
	void OnMouseDown()
	{
		clickedOn = true;
	}
	
	void OnMouseUp()
	{
		rigidbody2D.isKinematic=false;
		clickedOn = false;
		Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = (Input.mousePosition - sp).normalized;
		rigidbody2D.AddForce(dir*800*timePressed);
		
	}
	
}
