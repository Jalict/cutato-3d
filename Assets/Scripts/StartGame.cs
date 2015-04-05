using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public AudioClip potSound;
	//GUI
	public Font newFont;
	private int fontSize;

	public GameObject[] potato;
	private float z;
	private bool isShooted = false;
	private bool isPotShot = false;
	private bool isMoving;

	void Start(){
		isMoving = true;
	}
	IEnumerator WaitAndShiftScene()
	{
		Debug.Log("Collision");
        AudioSource.PlayClipAtPoint(potSound, transform.position);
		// suspend execution for 4 seconds
		yield return new WaitForSeconds(4);
		Application.LoadLevel (1);
	}

	void Update () {
		if(isMoving == true){
			MovePotato();
			transform.Translate (z, 0f, 0f);
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				z =-50f * Time.deltaTime;
				isShooted = true;
				//Create a new object when other is shot away.
				Instantiate(gameObject);
				//GameObject [] potato = new GameObject [2];
				//potato[1] = GameObject.Instantiate (Resources.Load ("potato")) as GameObject; 
				//potato[1].transform.position = new Vector3( 0, 0, 0);
			}
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
		isMoving=false;
			if (other.gameObject.tag == "Pot"){
				StartCoroutine(WaitAndShiftScene());
				isPotShot = true;
			//AudioSource.PlayClipAtPoint(potSound, this.transform.position);
		}
	}

	void OnGUI()
	{
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		nStyle.normal.textColor = new Color(100,100,100);
		nStyle.fontSize = 200;
		GUI.TextField (new Rect (0, 0, 200, 200), "Cutato!", nStyle);
	}	
}
