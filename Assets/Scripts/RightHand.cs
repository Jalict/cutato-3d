using UnityEngine;
using System.Collections; 

public class RightHand : MonoBehaviour {
	//sound initializing
	public AudioClip peelSound;
    public ParticleSystem peelingEffect;
	public Vector3 PeelingLocation;
	public float PeelingRadius;

    private bool isPeeling;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

        isPeeling = false;
	}

	void Update () {
		MoveHand ();

        if (Input.GetKey(KeyCode.Mouse0) && isPeeling) { 
			PeelPeelables ();
        }
	}

	void PeelPeelables ()
	{
		Collider[] collidedObjects = Physics.OverlapSphere (PeelingLocation + transform.position, PeelingRadius);

		foreach (Collider obj in collidedObjects) {
			if(obj.CompareTag("Peelable")) {
				obj.GetComponent<Peelable>().Peel();
                AudioSource.PlayClipAtPoint(peelSound, obj.transform.position);
            }
		}
	}

	void MoveHand() {
		Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

		Vector3 currentPos = transform.position;
		currentPos.x += mouseMovement.y * Time.deltaTime * 50;
		currentPos.z += mouseMovement.x * Time.deltaTime * 50;
		currentPos.y += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100;

		transform.position = currentPos;

        if (mouseMovement.sqrMagnitude > 0.5f)
            isPeeling = true;
        else
            isPeeling = false;
	}

	void OnDrawGizmos() {
		Color c = Gizmos.color;
		c.a = 0.65f;
		Gizmos.color = c;

		Gizmos.DrawSphere (PeelingLocation + transform.position, PeelingRadius);
	}
}
