using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

<<<<<<< HEAD
public GameObject [] model;
//public Vector3 startPosition;

=======
public GameObject [] models;
>>>>>>> Making timer to work MainGameManager and coroutines :v
	// Use this for initialization
	void Start () {
		transform.Translate (-5f * Time.deltaTime, 0f, 0f);
		rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);

	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
