using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {
	public BezierSolution.BezierWalkerWithSpeed bzWalker;
	public string currentPhase = "";	// liftoff, landing
	public bool deployLegs = false;
	public float acceleration;
	private void Update() {
		Accelerate(acceleration);
	}
	public void Accelerate(float factor){
		bzWalker.speed += bzWalker.speed * factor * Time.deltaTime;
	}
	public void Decelerate(float factor){
		bzWalker.speed -= bzWalker.speed * factor;
	}
}
