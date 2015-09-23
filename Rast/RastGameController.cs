using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RastGameController : MonoBehaviour {

	public float timeLeft;
	public Rigidbody2D rb;
	public Text txtStatus;
	public GameObject sanja;
	public GameObject btnDalje;
	public GameObject btnRestart;
	
	
	private float brzina=0.2f;
	void Start () {
		Screen.SetResolution(1063,598,false);
	}
	
	void Update()
	{
		rb.velocity=new Vector2(brzina,0.0f);
	}
	
	void FixedUpdate () {
		timeLeft-=Time.deltaTime;
		//txtStatus.text =(Mathf.RoundToInt(timeLeft)).ToString();
		if(timeLeft<0)
		{
			timeLeft=0;
			btnDalje.SetActive(true);
			btnRestart.SetActive(true);
			return;
		}
		if(timeLeft>=170)
		{
			txtStatus.text="Sad ne moraš ništa.\nSad samo odrastaš.\nI čekaš da budeš velika";
		}
		else if(timeLeft>165 && timeLeft<170 )
		{
			sanja.transform.localScale=new Vector3(0.55f,0.55f,1.0f);
			txtStatus.text="Samo se opusti i prepusti";
		}
		else if (timeLeft>155 && timeLeft<160 )
		{
			sanja.transform.localScale=new Vector3(0.6f,0.6f,1.0f);
			txtStatus.text="Prošeći i ti u ovom snu ispod zvjezdanog neba.";
		} 
		else if (timeLeft>145 && timeLeft<150 )
		{
			sanja.transform.localScale=new Vector3(0.65f,0.65f,1.0f);
			txtStatus.text="Čovječe pazi\n";
		} 
		else if (timeLeft>135 && timeLeft<140 )
		{
			sanja.transform.localScale=new Vector3(0.7f,0.7f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\n";
		} 
		else if (timeLeft>125 && timeLeft<130 )
		{
			sanja.transform.localScale=new Vector3(0.75f,0.75f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\n";
		} 
		else if (timeLeft>115 && timeLeft<120 )
		{
			sanja.transform.localScale=new Vector3(0.8f,0.8f,1.0f);
		} 
		else if (timeLeft>105 && timeLeft<110 )
		{
			sanja.transform.localScale=new Vector3(0.85f,0.85f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\n";
		} 
		else if (timeLeft>95 && timeLeft<100 )
		{
			sanja.transform.localScale=new Vector3(0.9f,0.9f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\n";
		}
		else if (timeLeft>85 && timeLeft<90 )
		{
			sanja.transform.localScale=new Vector3(0.95f,0.95f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\n";
		}
		else if (timeLeft>75 && timeLeft<80 )
		{
			sanja.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\nDa ni za čim ne žališ\n";
		}
		else if (timeLeft>65 && timeLeft<70 )
		{
			sanja.transform.localScale=new Vector3(1.05f,1.05f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\nDa ni za čim ne žališ\nkad se budeš zadnjim pogledima\n";
		}
		else if (timeLeft>55 && timeLeft<60 )
		{
			sanja.transform.localScale=new Vector3(1.1f,1.1f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\nDa ni za čim ne žališ\nkad se budeš zadnjim pogledima\nrastajo od zvijezda!\n\n";
		}
		else if (timeLeft>45 && timeLeft<50 )
		{
			sanja.transform.localScale=new Vector3(1.15f,1.15f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\nDa ni za čim ne žališ\nkad se budeš zadnjim pogledima\nrastajo od zvijezda!\n\nNa svom koncu\n";
		}
		else if (timeLeft>35 && timeLeft<40 )
		{
			sanja.transform.localScale=new Vector3(1.2f,1.2f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\nDa ni za čim ne žališ\nkad se budeš zadnjim pogledima\nrastajo od zvijezda!\n\nNa svom koncu\nmjesto u prah\n";
		}
		else if (timeLeft>25 && timeLeft<30 )
		{
			sanja.transform.localScale=new Vector3(1.25f,1.25f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\nDa ni za čim ne žališ\nkad se budeš zadnjim pogledima\nrastajo od zvijezda!\n\nNa svom koncu\nmjesto u prah\nprijeđi sav u zvijezde!\n\n";
		}
		else if (timeLeft>15 && timeLeft<20 )
		{
			sanja.transform.localScale=new Vector3(1.3f,1.3f,1.0f);
			txtStatus.text="Čovječe pazi\nda ne ideš malen\nispod zvijezda!\n\nPusti\nda cijelog tebe prođe\nblaga svjetlost zvijezda!\n\nDa ni za čim ne žališ\nkad se budeš zadnjim pogledima\nrastajo od zvijezda!\n\nNa svom koncu\nmjesto u prah\nprijeđi sav u zvijezde!\n\nA.B. Šimić";
		}
	}
	
	
}
