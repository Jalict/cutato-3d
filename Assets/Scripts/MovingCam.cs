using UnityEngine;
using System.Collections;

public class MovingCam : MonoBehaviour {
	private float z;
	private bool isMovingRight = true;
	
	void Update () {
		transform.Translate (z, 0f, 0f);
		if(Input.GetKeyDown(KeyCode.A)){
			z =-2f * Time.deltaTime;
		}
			if(Input.GetKeyDown(KeyCode.D)){
			z =+ 2f* Time.deltaTime;
		}
			
	}
}
