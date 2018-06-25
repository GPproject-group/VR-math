using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charEvent : MonoBehaviour {

	public int mode;
	public GameObject dialog;
	public int isClip;
	private int isRun;

	// Use this for initialization
	void Start () {
		isClip = 0;
		mode = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (mode) {
		case 1:
			Debug.Log ("jaha");
			runAni (1);
			break;
		case 2:
			runAni (2);
			break;
		case 3:
			runAni (3);
			break;
		}
	}

	private void reset(){
		GameObject person = GameObject.Find ("MaleFreeSimpleMovement1");
		Animator ani = person.GetComponent<Animator> ();
		mode = 0;
		ani.SetInteger ("mode", 0);
	}

	private void runAni(int modeNo){
		GameObject person = GameObject.Find ("MaleFreeSimpleMovement1");
		Animator ani = person.GetComponent<Animator> ();
		switch (modeNo) {
		case 1:
			ani.SetInteger ("mode", 1);
			Debug.Log ("mie");
			Invoke ("reset", 3);
			break;
		case 2:
			ani.SetInteger ("mode", 2);
			Invoke ("reset", 3);
			break;
		case 3:
			ani.SetInteger ("mode", 3);
			Invoke ("reset", 3);
			break;
		}
	}

	private void showDialog(){
		dialog.SetActive (true);
	}

	public void btnHightlight(GameObject btn){
		if (isClip == 1) {
			return;
		}
		showDialog ();
		string name = btn.name;

		switch (name) {

		//init menu
		case "MenuButton":
			dialog.GetComponentInChildren<Text> ().text = "查看具体菜单";
			break;
		case "ExitButton":
			dialog.GetComponentInChildren<Text> ().text = "退出程序";
			break;

		//main menu
		case "CreateModelButton":
			dialog.GetComponentInChildren<Text> ().text = "创建模型";
			break;
		case "CreateFunctionButton":
			dialog.GetComponentInChildren<Text> ().text = "创建函数";
			break;
		case "OperationButton":
			dialog.GetComponentInChildren<Text> ().text = "进行操作";
			break;

		//model menu
		case "Cones":
			dialog.GetComponentInChildren<Text> ().text = "创建圆锥模型";
			break;
		case "Cubes":
			dialog.GetComponentInChildren<Text> ().text = "创建棱柱模型";
			break;
		case "Cylinders":
			dialog.GetComponentInChildren<Text> ().text = "创建圆柱模型";
			break;
		case "Planes":
			dialog.GetComponentInChildren<Text> ().text = "创建四边形模型";
			break;
		case "Pyramid":
			dialog.GetComponentInChildren<Text> ().text = "创建棱锥模型";
			break;
		case "Sphere":
			dialog.GetComponentInChildren<Text> ().text = "创建球体模型";
			break;
		case "Triangle":
			dialog.GetComponentInChildren<Text> ().text = "创建三角形模型";
			break;
		case "ImportModels":
			dialog.GetComponentInChildren<Text> ().text = "导入外置模型";
			break;
		case "Reset":
			dialog.GetComponentInChildren<Text> ().text = "清空所有模型";
			break;

		//function menu
		case "PolynomialFuncButton":
			dialog.GetComponentInChildren<Text> ().text = "创建多项式函数\n最高次项为4".ToString();
			break;
		case "ExponentialFuncButton":
			dialog.GetComponentInChildren<Text> ().text = "创建幂函数";
			break;
		case "DrawCancelButton":
			dialog.GetComponentInChildren<Text> ().text = "取消已绘制函数";
			break;

		//operation menu
		case "MidpointButton":
			dialog.GetComponentInChildren<Text> ().text = "选取中点";
			break;
		case "LineButton":
			dialog.GetComponentInChildren<Text> ().text = "选取直线";
			break;
		case "PlaneButton":
			dialog.GetComponentInChildren<Text> ().text = "选取平面";
			break;
		case "LengthButton":
			dialog.GetComponentInChildren<Text> ().text = "返回长度";
			break;
		case "RelationButton":
			dialog.GetComponentInChildren<Text> ().text = "返回几何关系";
			break;
		case "LLAngleButton":
			dialog.GetComponentInChildren<Text> ().text = "返回线线角";
			break;
		case "LPAngleButton":
			dialog.GetComponentInChildren<Text> ().text = "返回线面角";
			break;
		case "PPAngleButton":
			dialog.GetComponentInChildren<Text> ().text = "返回面面角";
			break;
		case "ClipButton":
			dialog.GetComponentInChildren<Text> ().text = "进行切割";
			break;
		case "ResetButton":
			dialog.GetComponentInChildren<Text> ().text = "重制几何选择";
			break;

		//input
		case "edge":
			dialog.GetComponentInChildren<Text> ().text = "输入一个小于20的正整数";
			break;
		case "k1":
		case "k2":
		case "k3":
		case "b":
			dialog.GetComponentInChildren<Text> ().text = "输入一个实数";
			break;
		}
	}

	public void confirmChar(int errorno){
		showDialog ();

		switch (errorno) {
		case 0:
			Debug.Log ("input is not a float");
			dialog.GetComponentInChildren<Text> ().text = "请输入一个实数";
			mode = 2;
			break;
		case 1:
			Debug.Log ("too large");
			dialog.GetComponentInChildren<Text> ().text = "输入过大\n输入请小于20";
			mode = 2;
			break;
		case 2:
			Debug.Log ("too small");
			dialog.GetComponentInChildren<Text> ().text = "输入过小\n请输入正整数";
			mode = 2;
			break;
		case 3:
			dialog.GetComponentInChildren<Text> ().text = "生成成功！";
			mode = 1;
			break;
		}

		Invoke ("hideDialog", 1);
	}

	public void speakSomething(string str){
		Debug.Log ("in speak");
		showDialog ();
		dialog.GetComponentInChildren<Text> ().text = str;
		Invoke ("hideDialog", 1);
	}

	public void clip(){
		isClip = 1;
		showDialog ();
		dialog.GetComponentInChildren<Text> ().text = "请使用射线切割";
	}

	public void unHighlight(){
		if (isClip == 1) {
			return;
		}
		hideDialog ();
	}

	public void hideDialog(){
		dialog.SetActive (false);
	}
}
