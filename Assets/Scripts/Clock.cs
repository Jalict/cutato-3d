using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
	public Transform SecondHand;
	public Transform MinuteHand;
	public Transform HourHand;
	
	void Update () {
		DateTime currentTime = DateTime.Now;
		float second = (float) currentTime.Second;
		float minute = (float) currentTime.Minute;
		float hour = (float) currentTime.Hour %12;

		float secondAngle = 360 * (second/60);		
		float minuteAngle = 360 * (minute/60);
		float hourAngle = 360 * (hour/12);

		SecondHand.localRotation = Quaternion.Euler(0,0, secondAngle);
		MinuteHand.localRotation = Quaternion.Euler(0,0, minuteAngle);
		HourHand.localRotation = Quaternion.Euler(0,0, hourAngle);
	}
}
