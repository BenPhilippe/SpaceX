using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public UIManager UIM;
	public WebComManager WebCom;
	public float timeValue = -10f;
	public float minTimeValue, maxTimeValue;
	public float timeMultiplier = 1f;
	public bool isPlayMode = false;

	// Use this for initialization
	void Start () {
		if(UIM == null){
			Object.FindObjectOfType<UIManager>();
		}
		UIM.timeSlider.minValue = minTimeValue;
		UIM.timeSlider.maxValue = maxTimeValue;
		UIM.timeSlider.value = UIM.timeSlider.minValue;
	}
	
	// Update is called once per frame
	void Update () {
		if(isPlayMode){
			timeValue += Time.deltaTime * timeMultiplier;
			UIM.timeSlider.value = timeValue;
		}else{
			timeValue = UIM.timeSlider.value;
		}
	}
}
