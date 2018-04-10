using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebComManager : MonoBehaviour {

	GameManager GM;

	// Use this for initialization
	void Start () {
		if(GM == null){
			GM = Object.FindObjectOfType<GameManager>();
			if(GM == null){
				GM = GetComponent<GameManager>();
			}
		}
		//Application.ExternalCall("Fonction1", "blah");
		//Application.ExternalCall("Fonction2", 25.7425f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SendDataToWebPage(string functionName, params object[] args){
		Application.ExternalCall(functionName, args);
	}

	public void ExecuteJSScript(string scriptName){
		Application.ExternalEval(scriptName);
	}
}
