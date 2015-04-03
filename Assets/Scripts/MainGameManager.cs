using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour {

	public static MainGameManager instance;
	public int score;
	public float timeRemaining = 60;
	public IEnumerator countdown;
	public bool isCountingDown;

	void Awake(){

		if (instance == null)
			instance = this;

		DontDestroyOnLoad (instance);
		countdown = CountdownTime();
		isCountingDown = false;
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
			yield return new WaitForFixedUpdate();
		}
		Debug.Log ("Time's up!");
	}
}
