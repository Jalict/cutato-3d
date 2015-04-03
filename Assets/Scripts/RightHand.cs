﻿using UnityEngine;
using System.Collections; 

public class RightHand : MonoBehaviour {
	public Vector3 PeelingLocation;
	public float PeelingRadius;
	
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		MoveHand ();

		if (Input.GetKey (KeyCode.Mouse0)) 
			PeelPeelables ();
	}

	void PeelPeelables ()
	{
		Collider[] collidedObjects = Physics.OverlapSphere (PeelingLocation + transform.position, PeelingRadius);

		foreach (Collider obj in collidedObjects) {
			if(obj.CompareTag("Peelable")) {
				//TODO Reduce peeling factor
				//TODO Change texture (?)
				obj.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
			}
		}
	}

	void MoveHand() {
		Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);

		Vector3 currentPos = transform.position;
		currentPos.x += mouseMovement.y * Time.deltaTime * 50;
		currentPos.z += mouseMovement.x * Time.deltaTime * 50;
		currentPos.y += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100;

		transform.position = currentPos;
	}

	void OnDrawGizmos() {
		Color c = Gizmos.color;
		c.a = 0.65f;
		Gizmos.color = c;

		Gizmos.DrawSphere (PeelingLocation + transform.position, PeelingRadius);
	}
}