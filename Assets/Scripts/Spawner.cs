using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour 
{
    public Font newFont;

	//showing highscore/number of peeled potatos.
	private int count = 0;

	void Start() {
        StartCoroutine(SpawnPotatoes());
 	}

	void Update()
	{
		/*if (numberOfFullyPeeled >0){
			if (countNum > countSpeed) {
				Instantiate(potato, new Vector3(0, 10, 0), Quaternion.identity);
				numberOfFullyPeeled = numberOfFullyPeeled-1;
				countNum = 0;
				count = count+1;
			}
		}
		countNum++;*/
	}

    IEnumerator SpawnPotatoes() {
        foreach(GameObject obj in MainGameManager.instance.peeledPotatoes) {
            Instantiate(obj, new Vector3(0, 10, 0), Quaternion.identity);
            count++;

            yield return new WaitForSeconds(0.5f);
        }
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