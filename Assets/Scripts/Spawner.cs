using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	//GUI
	public Font newFont;
	public int fontSize;
	//Create array with Potato objects.
	public GameObject [] model;
	//
	public GameObject potato;
	//Timer
	public int countSpeed = 100; //amount of time between spawns
	int countNum = 0;
	//Counting number of potatos
	int numberOfPeeled = 5;
	//showing highscore
	int count = 0;

	void Update()
	{
		if (numberOfPeeled >0){
			if (countNum > countSpeed) {
				Instantiate(potato, new Vector3(0, 10, 0), Quaternion.identity);
				numberOfPeeled = numberOfPeeled-1;
				countNum = 0;
				count = count+1;
			}
		}
		countNum++;
	}
	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		//nStyle.fontSize = 30;
		nStyle.normal.textColor = new Color(100,100,100);
		//GUI.TextField (new Rect (10, 50, 200, 200), "HIGHSCORE", nStyle);
		nStyle.fontSize = 18;
		GUI.TextField (new Rect (Screen.width/2-50, 10, 200, 200), "Peeled potato : ", nStyle);
		nStyle.fontSize = 200;
		GUI.TextField (new Rect (Screen.width/2-50, 320, 200, 200), "" + count, nStyle);
	}	
}