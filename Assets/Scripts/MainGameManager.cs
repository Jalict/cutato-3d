using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour {

	public static MainGameManager instance;
	public int score;
	public ArrayList peeledPotatoes = new ArrayList();
	public float timeRemaining = 5; 
	private IEnumerator countdown;
	private bool isCountingDown;

	void Awake(){
		if(instance) {
			DestroyImmediate(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		countdown = CountdownTime();
		isCountingDown = false;

		StartTimer ();
	}

	public void AdjustScore(int i){

		score = score + i;
		Debug.Log ("Score has been adjusted to: " + score);
	}

	public void StartTimer(){
		if (!isCountingDown) {
			isCountingDown = true;
			StartCoroutine (countdown);
		}
	}

	public void StopTimer(){
		isCountingDown = false;
		StopCoroutine (countdown);
	}

	private IEnumerator CountdownTime(){

		while (timeRemaining > 0) {
			timeRemaining = timeRemaining - Time.fixedDeltaTime;
			Debug.Log("Time remaining: " + timeRemaining);
			//Debug.Log("Time remaining: " + timeRemaining);
			yield return new WaitForFixedUpdate();
		}
		Debug.Log ("Time's up!");
		Application.LoadLevel (0);
	}
<<<<<<< HEAD
	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		nStyle.normal.textColor = new Color(100,100,100);
		//Display time countdown
		nStyle.fontSize = 100;
		GUI.TextField (new Rect (Screen.width/2-50, 320, 200, 200), "" + timeRemaining, nStyle);
		//Display score
		//nStyle.fontSize = 50;
		//GUI.TextField (new Rect (Screen.width/4, 50, 200, 200), "Peeled potatoes: " + score, nStyle);
	}	
=======
>>>>>>> 434eb56702fe439b0eafacdd33fb11e214be95ba
}
