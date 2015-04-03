using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	//GUI
	public Font newFont;
	//Create array with Potato objects.
	public GameObject [] model;
	//Start position of Patato
	public Vector3 startPosition;
	//Timer
	public int countSpeed = 5;
	int countNum = 0;
	//Counting number of potatos
	int numberOfPeeled = 5;

	void Start()
	{
	}

	void Update()
	{
		if (countNum > countSpeed) {
			for (int i= 0; i<numberOfPeeled; i++) {
				//Transform.Translate(0f,0f,0f); 
			//for (int i= 0; i<model[]; i++) {
				//Transform o = (Transform)Instantiate (prefab);
				//o.transform.Translate (Random.Range (-5, 5), Random.Range (-1,1), 0f); //Spawning at random x-axis location
				//startPosition= (0f,0f,0f).transform.position;
			//}
				countNum = 0;	
			}
		countNum++;
		}
	}
	void OnCollisionEnter(Collision other)
	{
	if(other.gameObject.tag == "Bucket"){ //If collision between this gameObject and the bucket
		}
	}
	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		GUI.TextField (new Rect (10, 50, 200, 200), "HIGHSCORE", nStyle);
		GUI.TextField (new Rect (10, 100, 200, 200), "Number of potato peeled: " + numberOfPeeled, nStyle);
	}	
}