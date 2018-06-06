using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confirmFunction : MonoBehaviour {
	public GameObject functionMenu;
	public GameObject keyBoard;
	public GameObject x1;
	public GameObject x2;
	public GameObject x3;
	public GameObject x4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onLinearClick(){
		float k = float.Parse (x1.GetComponent<InputField> ().text);
		float b = float.Parse (x2.GetComponent<InputField> ().text);
		float[] args = {k,b};
		GameObject function = GameObject.Find ("Axis/FunctionRender");
		function.GetComponent<FunctionDisplayScript>().args = args;
		function.GetComponent<FunctionDisplayScript>().draw = true;

		GameObject.Find ("Canvas/LinearInput").SetActive (false);
		keyBoard.SetActive (false);
		functionMenu.SetActive (true);
	}

	public void onQuadraticClick(){
		float k1 = float.Parse (x1.GetComponent<InputField> ().text);
		float k2 = float.Parse (x2.GetComponent<InputField> ().text);
		float b = float.Parse (x3.GetComponent<InputField> ().text);
		float[] args = { k1, k2, b };

		GameObject function = GameObject.Find ("Axis/FunctionRender");
		function.GetComponent<FunctionDisplayScript>().args = args;
		function.GetComponent<FunctionDisplayScript>().draw = true;

		GameObject.Find ("Canvas/QuadraticInput").SetActive (false);
		keyBoard.SetActive (false);
		functionMenu.SetActive (true);
	}

	public void onCubicClick(){
		float k1 = float.Parse (x1.GetComponent<InputField> ().text);
		float k2 = float.Parse (x2.GetComponent<InputField> ().text);
		float k3 = float.Parse (x3.GetComponent<InputField> ().text);
		float b = float.Parse (x4.GetComponent<InputField> ().text);
		float[] args = { k1, k2, k3, b };

		GameObject function = GameObject.Find ("Axis/FunctionRender");
		function.GetComponent<FunctionDisplayScript>().args = args;
		function.GetComponent<FunctionDisplayScript>().draw = true;

		GameObject.Find ("Canvas/CubicInput").SetActive (false);
		keyBoard.SetActive (false);
		functionMenu.SetActive (true);
	}

	public void onPowerClick(){
		int k = int.Parse (x1.GetComponent<InputField> ().text);
		float[] args = new float[k+1];
		args [0] = k;
		for (int i = 1; i < k + 1; ++i) {
			args [i] = 0;
		}
		GameObject function = GameObject.Find ("Axis/FunctionRender");
		function.GetComponent<FunctionDisplayScript>().args = args;
		function.GetComponent<FunctionDisplayScript>().draw = true;

		GameObject.Find ("Canvas/PowerInput").SetActive (false);
		keyBoard.SetActive (false);
		functionMenu.SetActive (true);
	}
}
