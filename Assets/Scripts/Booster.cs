using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {
	//public BezierSolution.BezierWalkerWithSpeed bzWalker;
	public string currentPhase = "";	// liftoff, landing
	public bool deployLegs = false;
	public bool isDetached = false;
	public bool enablePlume = false;
	public BezierSolution.BezierSpline nextSplineToFollow;
	public BezierSolution.BezierWalkerWithSpeed walkerWithSpeed;
	public Vector3 nextSplineFirstPoint;
	public float distanceTreshold;
	public Transform defaultParent;
	Renderer r;
	private void Awake() {
		nextSplineFirstPoint = nextSplineToFollow.GetPoint(0f);
		walkerWithSpeed = GetComponent<BezierSolution.BezierWalkerWithSpeed>();
		if(walkerWithSpeed == null){
			Debug.Log("Couldn't find walker for " + name);
		}else{
			walkerWithSpeed.spline = nextSplineToFollow;
		}
		defaultParent = transform.parent;
	}
	private void Update() {
		if(isDetached){
			transform.position = Vector3.Lerp(transform.position, nextSplineFirstPoint, .5f);
			if(Vector3.Distance(transform.position, nextSplineFirstPoint) < distanceTreshold){
				walkerWithSpeed.enabled = true;
			}
		}else{
			transform.position = Vector3.Lerp(transform.position, nextSplineFirstPoint, .5f);
			if(Vector3.Distance(transform.position, nextSplineFirstPoint) < distanceTreshold){
				walkerWithSpeed.enabled = false;
			}
		}
	}
	public void Detach(){
		isDetached = true;
		transform.parent = null;
		Debug.Log("Detach " + name);
	}
	public void ReAttach(){
		isDetached = false;
		transform.parent = defaultParent;
		
		Debug.Log("Reattach " + name);
	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "EventTrigger"){
			//other.GetComponent<EventTrigger>().triggeredEvent.Invoke();
			if(!isDetached){
				Detach();
			}else{
				ReAttach();
			}
		}
	}
}
