using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
	public Transform SecondHand;
	
	float timer = 0;
    float second = 0;

    //Timer
	public int countSpeed = 50; //amount of time between spawns
	private int countNum = 0;
	
	void Update () {
		if(countNum > countSpeed){
 		second+=1.0f;
 		countNum = 0;	
   }
   if (second>=60)
       		{
        		   second = 0;
       		    timer = 0;
      		 }
   countNum++;
		float secondAngle = -360 * (second/60);		
		SecondHand.localRotation = Quaternion.Euler(0,0, secondAngle);
	}
}
