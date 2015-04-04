using UnityEngine;
using System.Collections;

public class SimonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MainGameManager.instance.StopTimer();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.D))
			Debug.Log(MainGameManager.instance.score);
	}
}
