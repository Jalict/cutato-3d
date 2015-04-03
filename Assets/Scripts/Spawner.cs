using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

public GameObject [] model;
//public Vector3 startPosition;

	// Use this for initialization
	void Start () {
		transform.Translate (-5f * Time.deltaTime, 0f, 0f);
		rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
