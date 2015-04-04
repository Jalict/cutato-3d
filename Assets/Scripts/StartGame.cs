using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	//GUI
	public Font newFont;
	private int fontSize;

	public GameObject potato;
	float z;
	private bool isShooted = false;

	void Update () {
		MovePotato();
		transform.Translate (z, 0f, 0f);
		if(Input.GetKey(KeyCode.Mouse0)){
			z =-50f * Time.deltaTime;
			isShooted = true;
		}
	}

	void MovePotato() {
		if(isShooted == false){ //bool so it does not move after being shoot away.
			Vector2 mouseMovement = new Vector2(0, Input.GetAxis("Mouse X")); //only able to move right and left.
			Vector3 currentPos = transform.position;
			currentPos.x += mouseMovement.y * Time.deltaTime * 50;
			currentPos.z += mouseMovement.x * Time.deltaTime * 50;
			currentPos.y = 0;
			transform.position = currentPos;
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pot"){
			Application.LoadLevel (2);
		}
	}

	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		nStyle.normal.textColor = new Color(100,100,100);
		nStyle.fontSize = 200;
		GUI.TextField (new Rect (Screen.width/2-50, 320, 200, 200), "Cutato!", nStyle);
	}	
}
