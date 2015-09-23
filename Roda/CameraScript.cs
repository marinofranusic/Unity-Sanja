using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform igrac;
	
	void Update () {
		if(transform!=null && igrac!=null)
			transform.position=new Vector3(igrac.position.x+6,0,-10);
	}
}
