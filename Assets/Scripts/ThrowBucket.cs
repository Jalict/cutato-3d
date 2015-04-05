using UnityEngine;
using System.Collections;

public class ThrowBucket : MonoBehaviour {

	public Transform targetTransform;
	public float fromLerpSpeed = 5.0f;
	public float backLerpSpeed = 2.5f;
	public int numPotatoes = 20;
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
		
		while (Vector3.Distance(transform.position, targetPos) > 5.0f) {
			transform.position = Vector3.Lerp (transform.position, targetPos, fromLerpSpeed * Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate();
		}

		for (int i = 0; i < numPotatoes; i++) {
			Instantiate(potatoes[Random.Range(0, potatoes.Length)], transform.position, Quaternion.identity);
			yield return new WaitForFixedUpdate();
		}
		
		while (Vector3.Distance(transform.position, startPos) > 1.0f) {
			transform.position = Vector3.Lerp(transform.position, startPos, backLerpSpeed * Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator ThrowSequence () {
		int interval = 15;
		float nextThrow = MainGameManager.instance.timeRemaining;

		while (MainGameManager.instance.timeRemaining > 0) {
			if(MainGameManager.instance.timeRemaining < nextThrow){
				StartCoroutine("ThrowPotatoes");
				nextThrow = nextThrow - interval;
			}
			yield return new WaitForFixedUpdate();
		}
	}
}
