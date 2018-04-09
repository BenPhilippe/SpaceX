using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	//UI Components
	public Text timeText, timeMultText;
	public Slider timeSlider, timeMultSlider;

	public GameManager GM;
	private void Awake() {
		GM = Object.FindObjectOfType<GameManager>();
		if(GM == null){
			Debug.Log("No GameManager found.");
		}
	}
	private void Update() {
		timeText.text = FormatTime(GM.timeValue);
	}
	public void PauseButton(){
		GM.isPlayMode = !GM.isPlayMode;
	}
	public void ChangeTimeSpeed(){
		GM.timeMultiplier = timeMultSlider.value;
		timeMultText.text = GM.timeMultiplier.ToString() + "x";
	}
	public void PauseButton(bool b){
		GM.isPlayMode = b;
	}
	public string FormatTime(float t){
		int sec = (int)(Mathf.Abs(t) % 60);
		int min = (int)(Mathf.Abs(t) / 60) % 60;
		int ct = (int)(Mathf.Abs(t) * 100) % 100;
		string s = "";
		if(t<0){
			s = "- ";
		}
		s += string.Format("{0:00}:{1:00}:{2:00}", min, sec, ct);
		return s;
	}
}
