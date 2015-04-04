using UnityEngine;
using System.Collections;

public class ThrowBucket : MonoBehaviour {

	public Transform targetTransform;
	public float fromLerpSpeed = 5.0f;
	public float backLerpSpeed = 2.5f;
	private Vector3 startPos;
	private Vector3 targetPos;
	public GameObject[] potatoes = new GameObject[1];

	// Use this for initialization
	void Start () {
	
		startPos = transform.position;
		targetPos = targetTransform.position;
		StartCoroutine ("ThrowSequence");
	}
	
	public IEnumerator ThrowPotatoes(){

		while (Vector3.Distance(transform.position, targetPos) > 0.1f) {
			transform.position = Vector3.Lerp (transform.position, targetPos, fromLerpSpeed * Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate();
		}
		while (Vector3.Distance(transform.position, startPos) > 0.1f) {
			transform.position = Vector3.Lerp(transform.position, startPos, backLerpSpeed * Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator ThrowSequence () {
		int interval = 15;
		float nextThrow = MainGameManager.instance.timeRemaining;

		while (MainGameManager.instance.timeRemaining > 0) {
			if(MainGameManager.instance.timeRemaining < nextThrow){
				Debug.Log("THROW THE POTATOES!");
				StartCoroutine("ThrowPotatoes");
				nextThrow = nextThrow - interval;
			}
			yield return new WaitForFixedUpdate();
		}
	}
}
