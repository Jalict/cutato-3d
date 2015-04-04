using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour {

	public static MainGameManager instance;
	public int score;
	public ArrayList peeledPotatoes = new ArrayList();
	public float timeRemaining = 5; 
	private IEnumerator countdown;
	private bool isCountingDown;
	public delegate void timeoutEvent();
	public static event timeoutEvent timeout;

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
			yield return new WaitForFixedUpdate();
		}
		if(timeout != null)
			timeout ();
	}	
}
