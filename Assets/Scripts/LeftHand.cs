using UnityEngine;
using System.Collections;

public class LeftHand : MonoBehaviour {
	public Vector3 grabbingLocation;
	public float grabbingRadius;
	private GameObject grabbedObject;
	
	void Start () {
		
	}

	void Update () {
		MoveHand ();

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grabbedObject == null) {
				GrabObject ();
			} else {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
				grabbedObject = null;
			}
		}
		if (grabbedObject != null) {
			grabbedObject.transform.position = grabbingLocation + transform.position;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
		} 
	}
	
	void GrabObject() {
		Collider[] collidedObjects = Physics.OverlapSphere (grabbingLocation + transform.position, grabbingRadius);

		int bestIndex = -1; //IT WORKS, OKEY?! Don't judge me :(
		float bestDist = float.MaxValue;

		for (int i = 0; i < collidedObjects.Length; i++) {
			if(collidedObjects[i].gameObject.CompareTag("Peelable")) {
				float dist = Vector3.Distance(collidedObjects[i].transform.position, transform.position);

				if(dist < bestDist) {
					bestDist = dist;
					bestIndex = i;
				}
			}

		}

		if(bestIndex != -1) 
			grabbedObject = collidedObjects [bestIndex].gameObject;
	}

	void MoveHand() {
		Vector3 nextPos = transform.position;

		if (Input.GetKey (KeyCode.A)) {
			nextPos.x -= Time.deltaTime * 10;
		}
		if (Input.GetKey (KeyCode.D)) {
			nextPos.x += Time.deltaTime * 10;
		}
		if (Input.GetKey (KeyCode.S)) {
			nextPos.z -= Time.deltaTime * 10;
		}
		if (Input.GetKey (KeyCode.W)) {
			nextPos.z += Time.deltaTime * 10;
		}
		if (Input.GetKey (KeyCode.Q)) {
			nextPos.y += Time.deltaTime * 10;
		}
		if (Input.GetKey (KeyCode.E)) {
			nextPos.y -= Time.deltaTime * 10;
		}
		
		transform.position = nextPos;
	}

	void OnDrawGizmos() {
		Color c = Gizmos.color;
		c.a = 0.85f;
		Gizmos.color = c;
		
		Gizmos.DrawSphere (grabbingLocation + transform.position, grabbingRadius);
	}
}
