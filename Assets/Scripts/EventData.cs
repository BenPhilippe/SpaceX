using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventData : MonoBehaviour{
	public string eventName = "default_name";
	public float triggerDate = 1;
	public float duration = 10;
	public float percentage;
}
