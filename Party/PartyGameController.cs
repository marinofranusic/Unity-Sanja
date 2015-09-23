using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PartyGameController : MonoBehaviour {
	public Text Nodilo;
	public GameObject goNodilo;
	public GameObject splashScreen;
	public Text Alkometar;
	public GameObject goAlkometar;
	public Transform marker;
	public GameObject[] cugaObjekti;
	public GameObject Sanja;
	public AudioSource NajavaCuge;
	public GameObject GameOverText;
	public GameObject btnDalje;
	public GameObject btnRestart;
	public GameObject btnStart;
	public GameObject upute;
	private string[] cuge=new string[]{"Pivo","Vino","Konjak","Whisky","Margarita","Martini","Rakija","Šampanjac","Voda"};
	private float brojac;
	private float brojacCuga;
	private int OdabranaCuga;
	private int VrijemeNajaveCuge=6;
	private int VrijemeCuge=2;
	private float bodovi;
	private bool Igramo=false;
	private float BodoviZaPobjedu=2.0f;
	// Use this for initialization
	void Start () {
		OdabranaCuga=0;
		brojac=0.0f;
		bodovi=0.0f;
		brojacCuga=0.0f;
		
	}
	
	public void ZapocniIgru()
	{
		goNodilo.SetActive(true);
		goAlkometar.SetActive(true);
		splashScreen.SetActive(false);
		btnStart.SetActive(false);
		upute.SetActive(false);
		Igramo=true;
	}
	
	void FixedUpdate()
	{
		int tmpInt;
		int tmpIntCuga;
		if(Igramo)
		{
			brojac+=Time.deltaTime;
			brojacCuga+=Time.deltaTime;
			tmpInt=Mathf.RoundToInt (brojac);
			tmpIntCuga=Mathf.RoundToInt (brojacCuga);
			//Nodilo.text=cuge[0];
			if(tmpInt>=VrijemeNajaveCuge)
			{
				OdabranaCuga=Mathf.RoundToInt(Random.Range(0,cuge.Length));
				brojac=0;
				NajavaCuge.Play ();
				
			}
			if(tmpIntCuga>=VrijemeCuge)
			{
				brojacCuga=0;
				StartCoroutine(Spawn ());
			}
			Nodilo.text="Sad pijemo:\n"+cuge[OdabranaCuga];
			Alkometar.text="Alkometar: "+bodovi.ToString("F2")+"‰";
			if(bodovi>=BodoviZaPobjedu)
				Pobjeda();
		}
	}
	
	
	
	public IEnumerator Spawn()
	{
		Vector3 spawnPosition = marker.position;
		Quaternion spawnRotation = Quaternion.identity;
		int odabir=Random.Range(0,cugaObjekti.Length);
		GameObject cugaOdabrana=cugaObjekti[odabir];
		
		GameObject cuga=(GameObject) Instantiate (cugaOdabrana, spawnPosition, spawnRotation);
		Party_PivoScript cugaScript=cuga.GetComponent<Party_PivoScript>();
		cugaScript.Identifikator=odabir;
		cugaScript.gc=this;
		cuga.rigidbody2D.velocity=new Vector2(-10,0);
		yield return new WaitForSeconds(0.0f);
	}
	
	void Update () {
	
	}
	
	public void PritisnutaCuga(int broj)
	{
		
		float vrijed=Random.Range(0.08f,0.3f);
		Mathf.Round(vrijed);
		if(OdabranaCuga==broj)
		{
			if(OdabranaCuga!=8)
				bodovi+=vrijed;
			else
				bodovi-=0.05f;
					
		}
		else
		{
			bodovi-=0.1f;
		}
	}
	void Pobjeda()
	{
		Igramo=false;
		Animator anim=Sanja.GetComponent<Animator>();
		anim.enabled=false;
		GameOverText.SetActive(true);
		btnDalje.SetActive(true);
		btnRestart.SetActive(true);	
	}
}
