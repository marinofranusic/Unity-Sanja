using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NogometGameController : MonoBehaviour {

	public Camera cam;
	public GameObject ball;
	public Slider slide;
	public GameObject marker1;
	public GameObject marker2;
	public Text txtBodovi;
	public MiciFudbalera mf;
	public GameObject upute;
	public GameObject gameOverText;
	public GameObject btnDalje;
	public GameObject btnRestart;
	
	//private float maxHeight;
	// Use this for initialization
	void Start () {
		Screen.SetResolution(1063,598,false);
		if (cam == null) {
			cam = Camera.main;
		}
		//Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		//Vector3 targetHeight = cam.ScreenToWorldPoint (upperCorner);
		//float ballHeight = ball.renderer.bounds.extents.y;
		//maxHeight = targetHeight.y - ballHeight;
		mf.Mici(true);
	}
	
	void Update()
	{
		if(int.Parse(txtBodovi.text)==1)
		{
			mf.SetMinSpeed(2);
		}
		else if(int.Parse(txtBodovi.text)==2)
		{
			mf.SetMinSpeed(3);
		}
		else if(int.Parse(txtBodovi.text)>=3)
		{
			mf.Mici(false);
			upute.SetActive(false);
			gameOverText.SetActive(true);
			btnDalje.SetActive(true);
			btnRestart.SetActive(true);
		}
	}
	
	public void DajLoptu()
	{
		if(int.Parse(txtBodovi.text)<3)
			StartCoroutine(Spawn());
	}
	
	public IEnumerator Spawn()
	{
		float x=marker1.transform.position.x;
		float y=Random.Range(marker1.transform.position.y,marker2.transform.position.y);
		Vector3 spawnPosition = new Vector3 (
			x, 
			y, 
			0.0f
			);
		//Vector3 spawnPosition = new Vector3(0f,0f,0f);
		Quaternion spawnRotation = Quaternion.identity;
		GameObject lopta=(GameObject) Instantiate (ball, spawnPosition, spawnRotation);
		fudbalerkaDragging fd=lopta.GetComponent<fudbalerkaDragging>();
		fd.snaga=slide;
		yield return new WaitForSeconds(0.0f);
	}
}
