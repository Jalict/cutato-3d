using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGameManager : MonoBehaviour {

	public static MainGameManager instance;
	public List<GameObject> peeledPotatoes;
	public float timeRemaining = 60;
	private IEnumerator countdown;
	private bool isCountingDown;
	public delegate void timeoutEvent();
	public static event timeoutEvent timeout;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        peeledPotatoes = new List<GameObject>();

        countdown = CountdownTime();
        isCountingDown = false;
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
			//Debug.Log("Time remaining: " + timeRemaining);
			yield return new WaitForFixedUpdate();
		}
		if(timeout != null)
			timeout ();
		Debug.Log ("TIME'S UP!");
	}	
}
