using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class KittiesGameController : MonoBehaviour {

	public GameObject sanja;
	public GameObject[] mace;
	public Text txtPoruka;
	public GameObject marker;
	public GameObject splashScreen;
	public GameObject startButton;
	public GameObject txtPobjeda;
	public GameObject btnDalje;
	public GameObject btnRestart;
	
	// Use this for initialization
	
	private bool igraj;
	private float maxWidth;
	private float maxHeight;
	void Start () {
		Screen.SetResolution(1063,598,false);
		igraj=true;
		Camera cam=Camera.main;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		maxHeight = targetWidth.y;
		
		
		//StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartGame()
	{
		startButton.SetActive(false);
		splashScreen.SetActive(false);
		StartCoroutine(Spawn ());
	}
	
	IEnumerator Spawn()
	{
		while(igraj)
		{
			GameObject maca=mace[Random.Range(0,mace.Length)];
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth*2, -maxWidth),
			                                     Random.Range (-maxHeight*2, -maxHeight),
			                                     0.0f);
			Quaternion spawnRotation = Quaternion.identity; //no rotation
			GameObject mic = (GameObject) Instantiate (maca, spawnPosition, spawnRotation);
			KittiesMaceSkripta kms=mic.GetComponent<KittiesMaceSkripta>();
			kms.sanja=sanja;
			kms.marker=marker;
			kms.gc=this;
			yield return new WaitForSeconds(Random.Range(1.0f,4.0f));
		}
	}
	
	public GameObject DajRefNaSanju()
	{
		return sanja;
	}
	
	void Pobjeda()
	{
		txtPobjeda.SetActive(true);
		Kitties_SanjaScript ksc=sanja.GetComponent<Kitties_SanjaScript>();
		ksc.ToggleUpravljiva();
		btnDalje.SetActive(true);
		btnRestart.SetActive(true);
	}
	
	public void PovecajBroj()
	{
		
		txtPoruka.text=(int.Parse(txtPoruka.text)+1).ToString();
		int brojMaca=int.Parse(txtPoruka.text);
		if(brojMaca>=50)
		{
			igraj=false;
			Pobjeda();
		}		
	}
	
	public void Poruka(string tekst)
	{
		txtPoruka.text=tekst;
	}
}
