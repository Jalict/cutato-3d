using UnityEngine;
using System.Collections;

public class Peelable : MonoBehaviour {
	//GUI
	public Font newFont;
	public int fontSize;
	public int amountOfPeel = 0; //0 = not peeled
	public bool isPeeled = false;
	
	public static int score = 0;

	void Start () {
	}
	
	void Update () {
		if(amountOfPeel >=100 && !isPeeled){ //if fully peeled.
				score +=1; //add one potato to score.
				isPeeled = true;
				amountOfPeel = 0;
			}
	}
	public void peeling(){
		amountOfPeel+=100/5; //5 is number of peels it take to 100/full.
	}
	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		//Display score
		nStyle.fontSize = 50;
		GUI.TextField (new Rect (Screen.width/6, 150, 200, 200), "Peeled potatoes: " + amountOfPeel, nStyle);
		GUI.TextField (new Rect (Screen.width/6, 250, 200, 200), "Score: " + score, nStyle);
	}
}
