using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour, IPointerClickHandler {
	// Use this for initialization
	public GameObject keyboard;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData eventData){
		
		keyboard.SetActive (false);
		Vector3 pos = gameObject.transform.position;
		pos.y -= float.Parse ("1.15");
		Debug.Log (pos);
		keyboard.transform.localPosition = pos;
		keyboard.GetComponent<UI_Keyboard>().input = gameObject.GetComponent<InputField>();
		keyboard.SetActive (true);
	}
}
