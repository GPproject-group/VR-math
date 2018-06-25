using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScript : MonoBehaviour {
    public GameObject initMenu;
    public GameObject mainMenu;
    public GameObject modelMenu;
    public GameObject funcMenu;
	public GameObject polynomialFuncMenu;
    public GameObject exponentialFuncMenu;
    public GameObject cancelButton;
	public GameObject cubesMenu;
	public GameObject pyramidMenu;
	public GameObject keyboard;
    public GameObject operationMenu;
    public GameObject infoMenu;
	public GameObject importModelMenu;

	public GameObject wrongInput0;
	public GameObject wrongInput1;
	public GameObject wrongInput2;

	public int charMode;

	public GameObject character;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/* 
	 * show menu part
	 * show submenus or inputs of every button
	 */
    public void showMainMenu()
    {
        initMenu.SetActive(false);
        mainMenu.SetActive(true);
        cancelButton.SetActive(true);
        int cnt = mainMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = mainMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
    }

    public void showModelMenu()
    {
        mainMenu.SetActive(false);
        modelMenu.SetActive(true);
        cancelButton.SetActive(true);
        int cnt = modelMenu.transform.childCount;
        for(int i = 0; i < cnt; i++)
        {
            Transform btn = modelMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
    }

    public void showFuncMenu()
    {
        mainMenu.SetActive(false);
        funcMenu.SetActive(true);
        cancelButton.SetActive(true);
        int cnt = funcMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = funcMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
    }

    public void showOperationMenu()
    {
        mainMenu.SetActive(false);
        operationMenu.SetActive(true);
        cancelButton.SetActive(true);
        int cnt = operationMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = operationMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
    }


    public void showPolynomialFunctionMenu()
	{
		funcMenu.SetActive (false);
        polynomialFuncMenu.SetActive (true);
		cancelButton.SetActive (true);
		int cnt = polynomialFuncMenu.transform.childCount;
		for (int i = 0; i < cnt; i++) {
			Transform btn = polynomialFuncMenu.transform.GetChild (i);
			btn.transform.localScale = Vector3.zero;
			btn.DOScale (Vector3.one, 0.3f).SetDelay (i * 0.1f);
		}
	}

    public void showExponentialFunctionMenu()
    {
        funcMenu.SetActive(false);
        exponentialFuncMenu.SetActive(true);
        cancelButton.SetActive(true);
        int cnt = exponentialFuncMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = exponentialFuncMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
    }

	public void showCubesMenu()
	{
		modelMenu.SetActive (false);
		cubesMenu.SetActive (true);
		cancelButton.SetActive (true);
	}
	public void showPyramidsMemu()
	{
		modelMenu.SetActive (false);
		pyramidMenu.SetActive (true);
		cancelButton.SetActive (true);
	}

	private void wrongInput(int errorno){
		switch (errorno) {
		case 0:
			Debug.Log ("input is not a float");
			wrongInput0.SetActive (true);
			break;
		case 1:
			Debug.Log ("too large");
			wrongInput1.SetActive (true);
			break;
		case 2:
			Debug.Log ("too small");
			wrongInput2.SetActive (true);
			break;
		}
	}

	private void hideWrongInput(){
		wrongInput0.SetActive (false);
		wrongInput1.SetActive (false);
		wrongInput2.SetActive (false);
	}

	/* 
	 * confirm part
	 * confirm the input of keyboard and input field
	 */
    public void confirmPolynomialFunction()
    {      
		hideWrongInput ();
        cancelButton.SetActive(false);
        initMenu.SetActive(true);
		float k1, k2, k3, b;
		if (!float.TryParse (GameObject.Find ("Canvas/PolynomialFuncMenu/Formula/k1").GetComponent<InputField> ().text,out k1) ||
			!float.TryParse (GameObject.Find ("Canvas/PolynomialFuncMenu/Formula/k2").GetComponent<InputField> ().text,out k2) ||
			!float.TryParse (GameObject.Find ("Canvas/PolynomialFuncMenu/Formula/k3").GetComponent<InputField> ().text,out k3) ||
			!float.TryParse (GameObject.Find ("Canvas/PolynomialFuncMenu/Formula/b").GetComponent<InputField> ().text,out b)) {
			character.GetComponent<charEvent> ().confirmChar (0);
			return;
		}
		//float k1 = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/k1").GetComponent<InputField>().text);
        //float k2 = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/k2").GetComponent<InputField>().text);
        //float k3 = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/k3").GetComponent<InputField>().text);
        //float b = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/b").GetComponent<InputField>().text);
        float[] args = { k1, k2, k3, b };
        Vector2 domain = new Vector2(-5, 5);
        GameObject function = GameObject.Find("Axis/FunctionRender");
        function.GetComponent<FunctionDisplayScript>().args = args;
        function.GetComponent<FunctionDisplayScript>().domain = domain;
        function.GetComponent<FunctionDisplayScript>().draw = true;
        polynomialFuncMenu.SetActive(false);
		keyboard.SetActive (false);
		character.GetComponent<charEvent> ().confirmChar (3);
    }

    public void confirmExponentialFunction()
    {
		hideWrongInput ();
        cancelButton.SetActive(false);
        initMenu.SetActive(true);
		float k1;
		int k2;
		if (!float.TryParse (GameObject.Find ("Canvas/ExponentialFuncMenu/Formula/k1").GetComponent<InputField> ().text, out k1) ||
			!int.TryParse (GameObject.Find ("Canvas/ExponentialFuncMenu/Formula/k2").GetComponent<InputField> ().text, out k2)) {
			character.GetComponent<charEvent> ().confirmChar (0);
			return;
		}
        //float k1 = float.Parse(GameObject.Find("Canvas/ExponentialFuncMenu/Formula/k1").GetComponent<InputField>().text);
        //int k2 = int.Parse(GameObject.Find("Canvas/ExponentialFuncMenu/Formula/k2").GetComponent<InputField>().text);
        float[] args = new float[k2 + 1];
        args[0] = k1;
        for(int i = 1; i < args.Length; i++)
        {
            args[i] = 0;
        }
        Vector2 domain = new Vector2(-5, 5);
        GameObject function = GameObject.Find("Axis/FunctionRender");
        function.GetComponent<FunctionDisplayScript>().args = args;
        function.GetComponent<FunctionDisplayScript>().domain = domain;
        function.GetComponent<FunctionDisplayScript>().draw = true;
        exponentialFuncMenu.SetActive(false);
		keyboard.SetActive (false);
		character.GetComponent<charEvent> ().confirmChar (3);
    }

	public void confirmCubeModel()
	{
		hideWrongInput ();
		int edge;
		if (!int.TryParse (GameObject.Find ("Canvas/CubesMenu/Formula/edge").GetComponent<InputField> ().text,out edge)) {
			character.GetComponent<charEvent> ().confirmChar (0);
			return;
		}

		//int edge = int.Parse (GameObject.Find ("Canvas/CubesMenu/Formula/edge").GetComponent<InputField> ().text);

		if (edge > 19) {
			character.GetComponent<charEvent> ().confirmChar (1);
			return;
		}

		if (edge < 1) {
			character.GetComponent<charEvent> ().confirmChar (2);
			return;
		}

		cancelButton.SetActive(false);
		initMenu.SetActive(true);	GameObject model = GameObject.Find ("Axis/ModelCreater");
		model.GetComponent<createModel> ().createCube (edge);
		cubesMenu.SetActive (false);
		keyboard.SetActive (false);
		character.GetComponent<charEvent> ().confirmChar (3);
	}

	public void confirmPyramidModel()
	{
		hideWrongInput ();
		int edge;
		if (!int.TryParse (GameObject.Find ("Canvas/PyramidsMenu/Formula/edge").GetComponent<InputField> ().text,out edge)) {
			character.GetComponent<charEvent> ().confirmChar (0);
			return;
		}

		//int edge = int.Parse (GameObject.Find ("Canvas/PyramidsMenu/Formula/edge").GetComponent<InputField> ().text);

		if (edge > 19) {
			character.GetComponent<charEvent> ().confirmChar (1);
			return;
		}

		if (edge < 1) {
			character.GetComponent<charEvent> ().confirmChar (2);
			return;
		}
		cancelButton.SetActive(false);
		initMenu.SetActive(true);	GameObject model = GameObject.Find ("Axis/ModelCreater");
		model.GetComponent<createModel> ().createPyramid (edge);
		pyramidMenu.SetActive (false);
		keyboard.SetActive (false);
		character.GetComponent<charEvent> ().confirmChar (3);

	}

    public void drawCancel()
    {
        cancelButton.SetActive(false);
        initMenu.SetActive(true);
        funcMenu.SetActive(false);
        GameObject function = GameObject.Find("Axis/FunctionRender");
        function.GetComponent<FunctionDisplayScript>().drawCancel = true;
    }

    public void selectModel()
    {
        modelMenu.SetActive(false);
        initMenu.SetActive(true);
        cancelButton.SetActive(false);
        int cnt = initMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = initMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
    }

	public void selectImportModel()
	{
		importModelMenu.SetActive(false);
		initMenu.SetActive(true);
		cancelButton.SetActive(false);
		int cnt = initMenu.transform.childCount;
		for (int i = 0; i < cnt; i++)
		{
			Transform btn = initMenu.transform.GetChild(i);
			btn.transform.localScale = Vector3.zero;
			btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
		}
	}

	public void selectImportModelMenu()
	{
		modelMenu.SetActive(false);
		importModelMenu.SetActive(true);
		cancelButton.SetActive(false);
		int cnt = importModelMenu.transform.childCount;
		for (int i = 0; i < cnt; i++)
		{
			Transform btn = importModelMenu.transform.GetChild(i);
			btn.transform.localScale = Vector3.zero;
			btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
		}
	}

    public void selectLine()
    {
        if (GlobalData.selectedVertex.Count == 2)
        {
            //operationMenu.SetActive(false);
            //cancelButton.SetActive(false);
            //initMenu.SetActive(true);
            int cnt = initMenu.transform.childCount;
            for (int i = 0; i < cnt; i++)
            {
                Transform btn = initMenu.transform.GetChild(i);
                btn.transform.localScale = Vector3.zero;
                btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
            }
			character.GetComponent<charEvent>().speakSomething("成功选中直线");
        }
        else
        {
            //operationMenu.SetActive(false);
            //cancelButton.SetActive(false);
            //infoMenu.SetActive(true);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select two point before connecting to line.";
			character.GetComponent<charEvent>().speakSomething("请选中两个点");
        }
    }

    public void selectPlane()
    {
        if (GlobalData.selectedVertex.Count == 3)
        {
            //operationMenu.SetActive(false);
            //cancelButton.SetActive(false);
            //initMenu.SetActive(true);
            int cnt = initMenu.transform.childCount;
            for (int i = 0; i < cnt; i++)
            {
                Transform btn = initMenu.transform.GetChild(i);
                btn.transform.localScale = Vector3.zero;
                btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
            }
			character.GetComponent<charEvent>().speakSomething("成功选中平面");
        }
        else
        {
            //operationMenu.SetActive(false);
            //cancelButton.SetActive(false);
            //infoMenu.SetActive(true);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select there point before connecting to plane.";
			character.GetComponent<charEvent>().speakSomething("请选中三个点");
        }
    }

    public void selectLength()
    {
        //operationMenu.SetActive(false);
        //cancelButton.SetActive(false);
        //infoMenu.SetActive(true);
        if (GlobalData.selectedLine.Count != 1)
        {
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select a line before calculate its length.";
			character.GetComponentInChildren<charEvent>().speakSomething("请先选择直线");
        }
        else
        {
            Vector3[] line = GlobalData.selectedLine[0];
            float len = MathCalculate.segmentLength(line);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Length of selected line is " + len.ToString() + ".";
			character.GetComponentInChildren<charEvent>().speakSomething("直线长度为\n"+len.ToString());
        }
    }

    public void selectRelation()
    {
        //operationMenu.SetActive(false);
        //cancelButton.SetActive(false);
        //infoMenu.SetActive(true);
        int linecnt = GlobalData.selectedLine.Count;
        int planecnt = GlobalData.selectedPlane.Count;
        if (linecnt == 2 && planecnt == 0)
        {
            Vector3[] line1 = GlobalData.selectedLine[0];
            Vector3[] line2 = GlobalData.selectedLine[1];
            LLRELATION relation = MathCalculate.llRelation(line1,line2);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Relation of the two selected lines is : " + MathCalculate.toString(relation) + ".";
			character.GetComponentInChildren<charEvent>().speakSomething("线线间几何关系为\n" + MathCalculate.toString(relation));
        }
        else if (linecnt == 1 && planecnt == 1)
        {
            Vector3[] line = GlobalData.selectedLine[0];
            Vector3[] plane = GlobalData.selectedPlane[0];
            LPRELATION relation = MathCalculate.lpRelation(line, plane);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Relation of selected line and plane is : " + MathCalculate.toString(relation) + ".";
			character.GetComponentInChildren<charEvent>().speakSomething("线面间几何关系为\n" + MathCalculate.toString(relation));
        }
        else if (linecnt == 0 && planecnt == 2)
        {
            Vector3[] plane1 = GlobalData.selectedPlane[0];
            Vector3[] plane2 = GlobalData.selectedPlane[1];
            PPRELATION relation = MathCalculate.ppRelation(plane1, plane2);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Relation of two selected planes is : " + MathCalculate.toString(relation) + ".";
			character.GetComponentInChildren<charEvent>().speakSomething("面面间几何关系为\n" + MathCalculate.toString(relation));
        }
        else
        {
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Selection is not correct.";
			character.GetComponentInChildren<charEvent>().speakSomething("选择存在错误");
        }
    }

    public void selectClip()
    {
        //operationMenu.SetActive(false);
        //cancelButton.SetActive(false);
        //initMenu.SetActive(true);
        int cnt = initMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = initMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
        foreach(GameObject model in createModel.modelList)
        {
            model.GetComponent<VRTK.Examples.TouchToPlane>().flag = true;
        }
    }

    public void selectMidpoint()
    {
        if (GlobalData.selectedVertex.Count == 2)
        {
            //operationMenu.SetActive(false);
            //cancelButton.SetActive(false);
            //initMenu.SetActive(true);
            int cnt = initMenu.transform.childCount;
            for (int i = 0; i < cnt; i++)
            {
                Transform btn = initMenu.transform.GetChild(i);
                btn.transform.localScale = Vector3.zero;
                btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
            }
        }
        else
        {
            //operationMenu.SetActive(false);
            //cancelButton.SetActive(false);
            //infoMenu.SetActive(true);
            int cnt = initMenu.transform.childCount;
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select two points before select midpoint.";
			character.GetComponentInChildren<charEvent>().speakSomething("请先选择两个点");
        }   
    }

    public void selectLLAngle()
    {
        //operationMenu.SetActive(false);
        //cancelButton.SetActive(false);
        //infoMenu.SetActive(true);
        int linecnt = GlobalData.selectedLine.Count;
        if (linecnt == 2)
        {
            Vector3[] line1 = GlobalData.selectedLine[0];
            Vector3[] line2 = GlobalData.selectedLine[1];
            float angle = MathCalculate.llAngle(line1, line2);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Angle of the two selected lines is : " + angle.ToString() + ".";
			character.GetComponentInChildren<charEvent>().speakSomething("两选中直线的夹角为\n" + angle.ToString());
        }
        else
        {
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select two lines before calculate the angle between line and line.";
			character.GetComponentInChildren<charEvent>().speakSomething("请先选择两条直线");
        }
    }

    public void selectLPAngle()
    {
        //operationMenu.SetActive(false);
        //cancelButton.SetActive(false);
        //infoMenu.SetActive(true);
        int linecnt = GlobalData.selectedLine.Count;
        int planecnt = GlobalData.selectedPlane.Count;
        if (linecnt == 1&&planecnt==1)
        {
            Vector3[] line = GlobalData.selectedLine[0];
            Vector3[] plane = GlobalData.selectedPlane[0];
            float angle = MathCalculate.lpAngle(line, plane);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Angle of the selected line and plane is : " + angle.ToString() + ".";
			character.GetComponentInChildren<charEvent>().speakSomething("选中直线与平面夹角为\n" + angle.ToString());
        }
        else
        {
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select a line and a plane before calculate the angle between line and plane.";
			character.GetComponentInChildren<charEvent>().speakSomething("请先选中直线与平面");
        }
    }

    public void selectPPAngle()
    {
        //operationMenu.SetActive(false);
        //cancelButton.SetActive(false);
        //infoMenu.SetActive(true);
        int planecnt = GlobalData.selectedPlane.Count;
        if (planecnt == 2)
        {
            Vector3[] plane1 = GlobalData.selectedPlane[0];
            Vector3[] plane2 = GlobalData.selectedPlane[1];
            float angle = MathCalculate.llAngle(plane1, plane2);
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Angle of the two selected planes is : " + angle.ToString() + ".";
			character.GetComponentInChildren<charEvent>().speakSomething("选中面面夹角为\n" + angle.ToString());
        }
        else
        {
            //GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select two planes before calculate the angle between plane and plane.";
			character.GetComponentInChildren<charEvent>().speakSomething("请先选择两平面");
        }
    }

    public void selectModelReset()
    {
        modelMenu.SetActive(false);
        cancelButton.SetActive(false);
        initMenu.SetActive(true);
        int cnt = initMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = initMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
        foreach(GameObject model in createModel.modelList)
        {
            GameObject vertexObj = GameObject.Find(model.name + "-vertex");
            Destroy(model);
            Destroy(vertexObj);
        }
    }

    public void selectClipPlane()
    {

    }

    public void cancel()
    {
		hideWrongInput ();
        modelMenu.SetActive(false);
        mainMenu.SetActive(false);
        initMenu.SetActive(true);
        cancelButton.SetActive(false);
        funcMenu.SetActive(false);
        exponentialFuncMenu.SetActive(false);
        polynomialFuncMenu.SetActive(false);
        cubesMenu.SetActive(false);
        pyramidMenu.SetActive(false);
        infoMenu.SetActive(false);
        operationMenu.SetActive(false);
        int cnt = initMenu.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
            Transform btn = initMenu.transform.GetChild(i);
            btn.transform.localScale = Vector3.zero;
            btn.DOScale(Vector3.one, 0.3f).SetDelay(i * 0.1f);
        }
    }

    public void exit()
    {
        Application.Quit();
    }
}
