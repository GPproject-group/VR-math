using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFucScript : MonoBehaviour {
	public GameObject detailList;
	public GameObject startButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ShowDetail(){
		//Debug.Log ("test");
		detailList.SetActive(true);
		startButton.SetActive (false);
	}
}

