﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	//UI Components
	public Text timeText, timeMultText, amountText;
	public Slider timeSlider, timeMultSlider, sendIntSlider;
	public RawImage playRawImage, pauseRawImage;
	public InputField functionNamefield, functionArgsField, intFunctionNamefield;

	public GameManager GM;
	private void Awake() {
		GM = Object.FindObjectOfType<GameManager>();
		if(GM == null){
			Debug.Log("No GameManager found.");
		}
		ChangePauseButtonTexture(GM.isPlayMode);
	}
	private void Update() {
		timeText.text = FormatTime(GM.timeValue);
		//amountText.text = sendIntSlider.value.ToString();
	}
	public void PauseButton(){
		GM.isPlayMode = !GM.isPlayMode;
		ChangePauseButtonTexture(GM.isPlayMode);
	}
	public void ChangePauseButtonTexture(bool b){
		playRawImage.gameObject.SetActive(!b);
		pauseRawImage.gameObject.SetActive(b);
	}
	public void ParseAndSendToWebpage(){
		string functionName = functionNamefield.text;
		string[] functionArgs = functionArgsField.text.Split(',');
		string arg = "";
		foreach (string s in functionArgs){
			arg += s + " ";
		}
		GM.WebCom.SendDataToWebPage(functionName, functionArgs);
	}
	public void SendIntToWebPage(){
		string functionName = intFunctionNamefield.text;
		GM.WebCom.SendDataToWebPage(functionName, sendIntSlider.value);
	}
	public void ChangeTimeSpeed(){
		GM.timeMultiplier = timeMultSlider.value/2;
		timeMultText.text = GM.timeMultiplier.ToString() + "x";
	}
	public void PauseButton(bool b){
		GM.isPlayMode = b;
	}
	public void QuitButton(){
		GM.QuitGame();
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
