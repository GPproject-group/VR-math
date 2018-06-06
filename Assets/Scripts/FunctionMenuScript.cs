using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionMenuScript : MonoBehaviour {
	public GameObject linearInput;
	public GameObject quadraticInput;
	public GameObject cubicInput;
	public GameObject powerInput;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onLinearClick(){
		gameObject.SetActive (false);
		linearInput.SetActive (true);
	}
	public void onQuadraticClick(){
		gameObject.SetActive (false);
		quadraticInput.SetActive (true);
	}
	public void onCubicClick(){
		gameObject.SetActive (false);
		cubicInput.SetActive (true);
	}
	public void onPowerClick(){
		gameObject.SetActive (false);
		powerInput.SetActive (true);
	}
}
