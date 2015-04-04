using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	//GUI
	public Font newFont;
	private int fontSize;

	public GameObject potato;
	//float z = 0;
		//public float speedForce = 1f;
		//public Vector3 u;


	void Update () {
		if(Input.GetKey(KeyCode.Mouse0)){
			//rigidbody.velocity = new Vector3 (0,0,-speedForce);
			//Rigidbody.AddForce(u,0);
			//z*=5;
		}
		if(Input.GetKey(KeyCode.Space)){
			Application.LoadLevel (2);
		}
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
