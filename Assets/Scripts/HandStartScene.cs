using UnityEngine;
using System.Collections;

public class HandStartScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveHand();
	
	}
	void MoveHand() {
			Vector2 mouseMovement = new Vector2(0, Input.GetAxis("Mouse X")); //only able to move right and left.
			Vector3 currentPos = transform.position;
			currentPos.x += mouseMovement.y * Time.deltaTime * 50;
			currentPos.z += mouseMovement.x * Time.deltaTime * 50;
			currentPos.y = 0;
			transform.position = currentPos;
	}
}
