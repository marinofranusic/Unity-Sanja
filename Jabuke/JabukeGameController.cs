using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JabukeGameController : MonoBehaviour {

	public Camera cam;
	public GameObject[] balls;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public HatController hatController;
	public GameObject oblacic1;
	public GameObject oblacic2;
	public GameObject daljeButton;

	private float maxWidth;
	private bool counting;
	// Use this for initialization
	void Start () {
		Screen.SetResolution(1063,598,false);
		if (cam == null) {
			cam=Camera.main;
		}
		counting = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = balls[0].renderer.bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;

		UpdateText ();
	}

	void FixedUpdate(){
		if (counting) {
				timeLeft -= Time.deltaTime;
				if (timeLeft < 0) {
						timeLeft = 0;		
				}
		}
		UpdateText ();
	}

	public void StartGame(){
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		hatController.ToggleControl (true);
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn() {
		yield return new WaitForSeconds (2.0f);
		counting = true;
		while (timeLeft > 0) {
			GameObject ball=balls[Random.Range(0,balls.Length)];
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth),
                             transform.position.y,
                             0.0f);
			Quaternion spawnRotation = Quaternion.identity; //no rotation
			Instantiate (ball, spawnPosition, spawnRotation);
			if(timeLeft>50)
			{
				yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
			}
			else if(timeLeft<=50 && timeLeft>20)
			{
				yield return new WaitForSeconds(Random.Range(0.6f,1.2f));
			}
			else
			{
				yield return new WaitForSeconds(Random.Range(0.3f,0.7f));
			}
			if (timeLeft<=50 && timeLeft>44)
			{
				oblacic1.SetActive(true);
			}
			else
			{
				oblacic1.SetActive(false);
			}
			if (timeLeft<=20 && timeLeft>14)
			{
				oblacic2.SetActive(true);
			}
			else
			{
				oblacic2.SetActive(false);
			}
		}
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		restartButton.SetActive (true);
		hatController.ToggleControl (false);
		daljeButton.SetActive(true);
	}

	void UpdateText(){
		timerText.text = "Vrijeme:\n" + Mathf.RoundToInt (timeLeft);
	}
}
