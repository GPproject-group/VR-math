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



	/* 
	 * confirm part
	 * confirm the input of keyboard and input field
	 */
    public void confirmPolynomialFunction()
    {      
        cancelButton.SetActive(false);
        initMenu.SetActive(true);
        float k1 = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/k1").GetComponent<InputField>().text);
        float k2 = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/k2").GetComponent<InputField>().text);
        float k3 = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/k3").GetComponent<InputField>().text);
        float b = float.Parse(GameObject.Find("Canvas/PolynomialFuncMenu/Formula/b").GetComponent<InputField>().text);
        float[] args = { k1, k2, k3, b };
        Vector2 domain = new Vector2(-5, 5);
        GameObject function = GameObject.Find("Axis/FunctionRender");
        function.GetComponent<FunctionDisplayScript>().args = args;
        function.GetComponent<FunctionDisplayScript>().domain = domain;
        function.GetComponent<FunctionDisplayScript>().draw = true;
        polynomialFuncMenu.SetActive(false);
		keyboard.SetActive (false);
    }

    public void confirmExponentialFunction()
    {
        cancelButton.SetActive(false);
        initMenu.SetActive(true);
        float k1 = float.Parse(GameObject.Find("Canvas/ExponentialFuncMenu/Formula/k1").GetComponent<InputField>().text);
        int k2 = int.Parse(GameObject.Find("Canvas/ExponentialFuncMenu/Formula/k2").GetComponent<InputField>().text);
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
    }

	public void confirmCubeModel()
	{
		cancelButton.SetActive(false);
		initMenu.SetActive(true);
		int edge = int.Parse (GameObject.Find ("Canvas/CubesMenu/Formula/edge").GetComponent<InputField> ().text);
		GameObject model = GameObject.Find ("Axis/ModelCreater");
		model.GetComponent<createModel> ().createCube (edge);
		cubesMenu.SetActive (false);
		keyboard.SetActive (false);
	}

	public void confirmPyramidModel()
	{
		cancelButton.SetActive(false);
		initMenu.SetActive(true);
		int edge = int.Parse (GameObject.Find ("Canvas/PyramidsMenu/Formula/edge").GetComponent<InputField> ().text);
		GameObject model = GameObject.Find ("Axis/ModelCreater");
		model.GetComponent<createModel> ().createPyramid (edge);
		pyramidMenu.SetActive (false);
		keyboard.SetActive (false);

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
		modelMenu.SetActive (false);
		importModelMenu.SetActive (true);
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
            operationMenu.SetActive(false);
            cancelButton.SetActive(false);
            initMenu.SetActive(true);
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
            operationMenu.SetActive(false);
            cancelButton.SetActive(false);
            infoMenu.SetActive(true);
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select two point before connecting to line.";
        }
    }

    public void selectPlane()
    {
        if (GlobalData.selectedVertex.Count == 3)
        {
            operationMenu.SetActive(false);
            cancelButton.SetActive(false);
            initMenu.SetActive(true);
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
            operationMenu.SetActive(false);
            cancelButton.SetActive(false);
            infoMenu.SetActive(true);
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select there point before connecting to plane.";
        }
    }

    public void selectLength()
    {
        operationMenu.SetActive(false);
        cancelButton.SetActive(false);
        infoMenu.SetActive(true);
        if (GlobalData.selectedLine.Count != 1)
        {
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "You must select a line before calculate its length.";
        }
        else
        {
            Vector3[] line = GlobalData.selectedLine[0];
            float len = MathCalculate.segmentLength(line);
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Length of selected line is " + len.ToString() + ".";
        }
    }

    public void selectRelation()
    {
        operationMenu.SetActive(false);
        cancelButton.SetActive(false);
        infoMenu.SetActive(true);
        int linecnt = GlobalData.selectedLine.Count;
        int planecnt = GlobalData.selectedPlane.Count;
        if (linecnt == 2 && planecnt == 0)
        {
            Vector3[] line1 = GlobalData.selectedLine[0];
            Vector3[] line2 = GlobalData.selectedLine[1];
            LLRELATION relation = MathCalculate.llRelation(line1,line2);
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Relation of the two selected lines is : " + MathCalculate.toString(relation) + ".";
        }
        else if (linecnt == 1 && planecnt == 1)
        {
            Vector3[] line = GlobalData.selectedLine[0];
            Vector3[] plane = GlobalData.selectedPlane[0];
            LPRELATION relation = MathCalculate.lpRelation(line, plane);
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Relation of selected line and plane is : " + MathCalculate.toString(relation) + ".";
        }
        else if (linecnt == 0 && planecnt == 2)
        {
            Vector3[] plane1 = GlobalData.selectedPlane[0];
            Vector3[] plane2 = GlobalData.selectedPlane[1];
            PPRELATION relation = MathCalculate.ppRelation(plane1, plane2);
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Relation of two selected planes is : " + MathCalculate.toString(relation) + ".";
        }
        else
        {
            GameObject.Find("Canvas/InfoMenu/InfoText").GetComponent<Text>().text = "Selection is not correct.";
        }
    }

    public void selectClip()
    {
        operationMenu.SetActive(false);
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
            model.GetComponent<VRTK.Examples.TouchToPlane>().flag = true;
        }
    }

    public void cancel()
    {
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
