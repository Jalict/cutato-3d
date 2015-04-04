using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Vibrator : MonoBehaviour {

	public float maxForce = 50;
	private Rigidbody rb;
	private bool isVibrating = false;
	private IEnumerator vibrateObject;

	void Awake(){
		rb = this.GetComponent<Rigidbody> ();
		vibrateObject = VibrateObject ();
	}

	void OnEnable() {
		MainGameManager.timeout += StartVibrate;
	}

	void OnDisable() {
		MainGameManager.timeout -= StartVibrate;
	}

	public void StartVibrate(){
		if(!isVibrating){
			isVibrating = true;
			StartCoroutine(vibrateObject);
		}
	}

	public void StopVibrate(){
			isVibrating = false;
			StopCoroutine(vibrateObject);
	}

	private IEnumerator VibrateObject(){
		while (true) {
			Vector3 randVector = new Vector3(Random.Range(-1.0f, 1.0f) * maxForce, Random.Range(-1.0f, 1.0f) * maxForce, Random.Range(-1.0f, 1.0f) * maxForce);
			rb.AddForce(randVector);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
