using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventActions : MonoBehaviour {
	public EventData ed;
	private void Awake() {
		if(ed == null){
			ed = GetComponent<EventData>();
		}
	}
	
	public void LogCurrentState(float currentTime){
		float f = (currentTime - ed.triggerDate) / ed.duration;
		if(currentTime < ed.triggerDate){
			Debug.Log(ed.eventName + " not yet started");
			ed.percentage = 0f;
		}else if(currentTime > (ed.triggerDate + ed.duration)){
			ed.percentage = 100f;
			Debug.Log(ed.eventName + " finished");
		}else if ((currentTime > ed.triggerDate) && (currentTime < (ed.triggerDate + ed.duration))){
			ed.percentage = f * 100;
			Debug.Log(ed.eventName + " completion: " + (ed.percentage).ToString("F2") + "%");
		}
	}
}
