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

	public EventData[] events;

	// Use this for initialization
	void Start () {
		if(UIM == null){
			Object.FindObjectOfType<UIManager>();
		}
		UIM.timeSlider.minValue = minTimeValue;
		UIM.timeSlider.maxValue = maxTimeValue;
		UIM.timeSlider.value = timeValue;
	}
	
	// Update is called once per frame
	void Update () {

		if(isPlayMode){
			timeValue += Time.deltaTime * timeMultiplier;
			UIM.timeSlider.value = timeValue;
			UIM.timeSlider.interactable = false;

			foreach(EventData e in events){
				e.gameObject.GetComponent<EventActions>().LogCurrentState(timeValue);
			}

		}else{
			timeValue = UIM.timeSlider.value;
			UIM.timeSlider.interactable = true;
		}
	}
	public void QuitGame(){
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
    Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
#endif
#if (UNITY_EDITOR)
    UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
	}
}
