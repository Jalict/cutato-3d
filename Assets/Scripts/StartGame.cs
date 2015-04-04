using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	//GUI
	public Font newFont;
	private int fontSize;

	public GameObject potato;
	float z;
		//public float speedForce = 1f;
		//public Vector3 u;
void Start(){
//if(Input.GetKey(KeyCode.Mouse0)){
			
		//}
}

	void Update () {
		MovePotato();
		transform.Translate (z, 0f, 0f);
		if(Input.GetKey(KeyCode.Mouse0)){
		z =-50f * Time.deltaTime;
	}
		//	transform.Translate (-50f * Time.deltaTime, 0f, 0f);
			//rigidbody.AddForce(0,10,0);


			//rigidbody.velocity = new Vector3 (0,0,-speedForce);
			//Rigidbody.AddForce(u,0);
			//z*=5;
		//}
		if(Input.GetKey(KeyCode.Space)){
			Application.LoadLevel (2);
		}
	}

	void MovePotato() {
		Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

		Vector3 currentPos = transform.position;
		currentPos.x += mouseMovement.y * Time.deltaTime * 50;
		currentPos.z += mouseMovement.x * Time.deltaTime * 50;
		currentPos.y = 0;

		transform.position = currentPos;
	}
	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		nStyle.normal.textColor = new Color(100,100,100);
		nStyle.fontSize = 18;
		GUI.TextField (new Rect (Screen.width/2-50, 10, 200, 200), "Start peeling to begin!", nStyle);
		nStyle.fontSize = 200;
		GUI.TextField (new Rect (Screen.width/2-50, 320, 200, 200), "Cutato!", nStyle);
	}	
}
