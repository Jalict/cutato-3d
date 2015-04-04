using UnityEngine;
using System.Collections;

public class Peelable : MonoBehaviour {
	//GUI
	public Font newFont;
	private int fontSize;
	//how peeled
	public int amountOfPeel = 0; //0 = not peeled
	public bool isPeeled = false;
	//static for each potato
	public static int score = 0;
	//Textures
	public Texture2D Tex0;
	public Texture2D Tex1;
	public Texture2D Tex2;
	public Texture2D Tex3;
	public Texture2D Tex4;
	
	private Texture2D TexVisible;

	void Start () {
		TexVisible = new Texture2D(1,1);
	}
	
	void Update () {
		showPeelTex();
		if(amountOfPeel >=100 && !isPeeled){ //if fully peeled.
			score +=1; //add one potato to score.
			amountOfPeel = 0;
			isPeeled = true;
		}
	}
	public void peeling(){
		if(!isPeeled){
			amountOfPeel+=100/5; //5 is number of peels it take to 100/full.
		}
	}
	void showPeelTex(){
		if (amountOfPeel == 0) {
			TexVisible = Tex0;
		}
		if(amountOfPeel == 20){
			TexVisible = Tex1;
		}
		if (amountOfPeel == 60) {
			TexVisible = Tex2;
		}
		if (amountOfPeel == 80) {
			TexVisible = Tex3;
		}
		if(amountOfPeel == 100){
			TexVisible = Tex4;
		}
	}
	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		//Display score
		nStyle.fontSize = 50;
		GUI.TextField (new Rect (Screen.width/6, 150, 200, 200), "Peeled potatoes: " + amountOfPeel, nStyle);
		GUI.TextField (new Rect (Screen.width/6, 250, 200, 200), "Score: " + score, nStyle);
		//Display texture
		GUI.DrawTexture(new Rect(50, 150, 300, 50), TexVisible);
	}
}
