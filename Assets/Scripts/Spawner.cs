using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	//GUI
	public Font newFont;
	private int fontSize;
	//Create array with Potato objects.
	public GameObject [] model;
	//
	public GameObject potato;
	//Timer
	public int countSpeed = 100; //amount of time between spawns
	private int countNum = 0;
	//Counting number of potatos
	private int numberOfFullyPeeled; //create data from numberOfPeeled since list only readable.
	ArrayList numberOfPeeled; //storing data from GameManager.
	//showing highscore/number of peeled potatos.
	private int count = 0;

	void Start() {
		numberOfPeeled = MainGameManager.instance.peeledPotatoes;
		numberOfFullyPeeled = numberOfPeeled.Count;
 	}

	void Update()
	{
		if (numberOfFullyPeeled >0){
			if (countNum > countSpeed) {
				Instantiate(potato, new Vector3(0, 10, 0), Quaternion.identity);
				numberOfFullyPeeled = numberOfFullyPeeled-1;
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