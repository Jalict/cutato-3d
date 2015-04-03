using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
 
 public float timeRemaining = 60f;
 
 void Start()
 {
     InvokeRepeating("decreaseTimeRemaining", 1.0, 1.0)
 }
 
 void Update()
 {
     if (timeRemaining == 0)
     {
         sendMessageUpward("timeElapsed");
         //load highscoreScene. 1 set to 
         Application.LoadLevel (1); //name "lvl1" of scene. if 0 = first;

     }
 
     GuiText.text = timeRemaining + " Seconds remaining!";
 
 }
 
 void decreaseTimeRemaining()
 {
     timeRemaining --;
 }
 
 //may not be needed, left it in there
 void timeElapsed()
 {}
