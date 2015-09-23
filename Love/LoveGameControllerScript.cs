using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoveGameControllerScript : MonoBehaviour {
	public GameObject[] bubbles;
	public GameObject[] slots;
	public Transform lijevo;
	public Transform desno;
	public Slider slajd;
	public GameObject heart;
	public GameObject splashScreen;
	public GameObject splashText;
	public GameObject btnStart;
	public GameObject btnRestart;
	public GameObject btnDalje;
	private bool gameStarted=false;
	private bool StvoriBubble=true; // Ovo na true
	private int BrojPopunjenihSlotova=0;
	
	public void StartGame()
	{
		gameStarted=true;
		splashText.SetActive(false);
		splashScreen.SetActive(false);
		btnStart.SetActive(false);
	}
	
	void Start () {
		//Pobjeda(); // Ovo makni
	}
	
	// Update is called once per frame
	void Update () {
		if(StvoriBubble && gameStarted)
		{
			StartCoroutine(Spawn ());
			StvoriBubble=false;
		}
	}
	
	public IEnumerator Spawn()
	{
		Vector3 spawnPosition = new Vector3(
								Random.Range(lijevo.position.x,desno.position.x),
								lijevo.position.y,
								0.0f);
		Quaternion spawnRotation = Quaternion.identity;
		int odabir=Random.Range(0,bubbles.Length);
		GameObject bubbleOdabrani=bubbles[odabir];
		
		GameObject bubblic=(GameObject) Instantiate (bubbleOdabrani, spawnPosition, spawnRotation);
		Love_BubbleMoveScript bubbleScript=bubblic.GetComponent<Love_BubbleMoveScript>();
		bubbleScript.slajder=slajd;
		yield return new WaitForSeconds(0.0f);
	}
	
	public void BubbleDestroyed()
	{
		StvoriBubble=true;
	}
	public void TocanSlot()
	{
		BrojPopunjenihSlotova++;
		if(BrojPopunjenihSlotova<14)
		{
			BubbleDestroyed();
			Debug.Log(BrojPopunjenihSlotova.ToString());
		}
		else
			Pobjeda();
	}
	
	private void Pobjeda()
	{
		Debug.Log ("Pobjeda!");
		CircleCollider2D cc;
		
		foreach(GameObject gob in slots)
		{
			cc=gob.GetComponent<CircleCollider2D>();
			cc.enabled=false;
		}
		
		StartCoroutine(EndAnim());
	}
	IEnumerator EndAnim()
	{
		Animator anim;
		foreach(GameObject gob in slots)
		{
			anim=gob.GetComponent<Animator>();
			anim.enabled=true;
			
			yield return new WaitForSeconds(1.5f);
			
		}
		yield return new WaitForSeconds(3.0f);
		heart.SetActive(true);
		anim=heart.GetComponent<Animator>();
		anim.enabled=true;
		btnDalje.SetActive(true);
		btnRestart.SetActive(true);
	}
}
