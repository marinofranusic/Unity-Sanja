using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Camera cam;
	public Text tekst;
	public Transform igrac;
	public Character2d ch2dObj;
	public Text txtPoruka;
	public GameObject txtPobjeda;
	public GameObject btnDalje;
	public GameObject btnRestart;
	
	private bool alive;
	private float maxWidth;
	private bool pobjeda;
	// Use this for initialization
	void Start () {
		Screen.SetResolution(1063,598,false);
		Vector3 upperCorner=new Vector3(Screen.width,Screen.height,0.0f);
		Vector3 targetSize=cam.ScreenToWorldPoint(upperCorner);
		maxWidth=targetSize.y;
		
		
		alive=ch2dObj.JesiZiv();
		
	}
	
	
	public void SetTekst(string noviTekst)
	{
		tekst.text=noviTekst;
	}
	
	// Update is called once per frame
	void Update () {
		//tekst.text="-->"+Mathf.RoundToInt(maxHeight)+"  Igrac_y:"+igrac.position.y;
		alive=ch2dObj.JesiZiv();
		pobjeda=ch2dObj.JelPobjeda();
		//SetTekst("Max: "+maxWidth.ToString()+" Pos:"+igrac.position.x.ToString());
		if(pobjeda)
		{
			//txtPoruka.text="Da! Tako je u ovom digitalnom snu na svijet došla moja ljubav Sanja!";
			txtPoruka.text="";
			txtPobjeda.SetActive(true);
			
			btnRestart.SetActive(true);
			
			btnDalje.SetActive(true);
			
			return;
		}
		if(!alive)
		{
			txtPoruka.text="Ajaj!! Nije tako bilo!\nProbaj ponovno.";
			btnRestart.SetActive(true);
			return;
		}
		if(igrac.position.x>maxWidth*4 && igrac.position.x<maxWidth*9)
		{
			txtPoruka.text="Kroz oblačne gradove...";
		}
		else if(igrac.position.x>maxWidth && igrac.position.x<maxWidth*4)
		{
			txtPoruka.text="Krenula je na dalek put...";
		}
		else if(igrac.position.x>maxWidth*14 && igrac.position.x<maxWidth*23)
		{
			txtPoruka.text="I vjetrovite zore...";
		}
		else if(igrac.position.x>maxWidth*21 && igrac.position.x<maxWidth*27)
		{
			txtPoruka.text="Tražila svoj cilj...";
		}
		else if(igrac.position.x>maxWidth*29 && igrac.position.x<maxWidth*37)
		{
			txtPoruka.text="Uz opasne puteve...";
		}
		else if(igrac.position.x>maxWidth*38 && igrac.position.x<maxWidth*46)
		{
			txtPoruka.text="I vesele boje...";
		}
		else if(igrac.position.x>maxWidth*47 && igrac.position.x<maxWidth*51)
		{
			txtPoruka.text="A cilj je negdje iza grada Zenice...";
		}
		else if(igrac.position.x>maxWidth*53 && igrac.position.x<maxWidth*57)
		{
			txtPoruka.text="Negdje povrh Žepča...";
		}
		else if(igrac.position.x>maxWidth*57 && igrac.position.x<maxWidth*61)
		{
			txtPoruka.text="Na Karauli!";
		}
		else if(igrac.position.x>maxWidth*61 && igrac.position.x<maxWidth*63)
		{
			txtPoruka.text="Gdje je ugledala cilj!";
		}
		
		else
		{
			txtPoruka.text="";
		}
		
		
		
		//if(!alive)
		//	SetTekst("Ups! Mrtav");
		//SetTekst();
	}
}
