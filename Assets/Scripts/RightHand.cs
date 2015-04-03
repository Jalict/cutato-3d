using UnityEngine;
using System.Collections;

public class RightHand : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		MoveHand ();
	}

	void MoveHand() {
		Vector3 mouseMovement = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);

		Vector3 currentPos = transform.position;
		currentPos.x += mouseMovement.y;
		currentPos.z += -mouseMovement.x;
		transform.position = currentPos;
	}
}
