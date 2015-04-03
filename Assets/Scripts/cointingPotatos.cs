using UnityEngine;
using System.Collections;

public class cointingPotatos : MonoBehaviour 
{
	//GUI
	public Font newFont;
	//To count up when collision
	int numberOfSpawns = 0;

	void Start () {
	}
	
	void Update () {
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("collision");
		if(other.gameObject.tag == "Potatos"){ //If collision between this gameObject and the bucket
			numberOfSpawns = numberOfSpawns+1;
		}
	}
	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		GUI.TextField (new Rect (10, 50, 200, 200), "HIGHSCORE", nStyle);
		GUI.TextField (new Rect (10, 100, 200, 200), "Number of potato peeled: " + numberOfSpawns, nStyle);
	}	
}
