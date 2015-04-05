using UnityEngine;
using System.Collections;

public class BucketList : MonoBehaviour {
	public Vector3 PeelingLocation;
	public float PeelingRadius;

	private ArrayList potatoesInBasket;

	void Start () {
		potatoesInBasket = new ArrayList();
	}
	
	void Update () {
		CheckPeelablesInside ();
	}

	void CheckPeelablesInside ()
	{
		Collider[] collidedObjects = Physics.OverlapSphere (PeelingLocation + transform.position, PeelingRadius);

		foreach (Collider obj in collidedObjects) {	
			if(obj.CompareTag("Peelable")) {
                if (obj.gameObject.GetComponent<Peelable>().isPeeled()) {
                    Debug.Log("ADDED POTATO TO LIST");
                    MainGameManager.instance.peeledPotatoes.Add(obj.gameObject);
			        obj.tag = "Untagged";
                    obj.GetComponent<Peelable>().DontKillMe();
                }
			}
		}
	}
	void OnDrawGizmos() {
		Color c = Gizmos.color;
		c.a = 0.65f;
		Gizmos.color = c;
		Gizmos.DrawSphere (PeelingLocation + transform.position, PeelingRadius);
	}
}
