using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScript : MonoBehaviour {
    public GameObject initMenu;
    public GameObject mainMenu;
    public GameObject modelMenu;
	public GameObject functionMenu;
    public GameObject cancelButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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

	public void showFunctionMenu()
	{
		mainMenu.SetActive (false);
		functionMenu.SetActive (true);
		cancelButton.SetActive (true);
		int cnt = functionMenu.transform.childCount;
		for (int i = 0; i < cnt; i++) {
			Transform btn = functionMenu.transform.GetChild (i);
			btn.transform.localScale = Vector3.zero;
			btn.DOScale (Vector3.one, 0.3f).SetDelay (i * 0.1f);
		}
	}

    public void confirmFunction()
    {      
        cancelButton.SetActive(false);
        initMenu.SetActive(true);
        float k1 = float.Parse(GameObject.Find("Canvas/FunMenu/k1").GetComponent<InputField>().text);
        float k2 = float.Parse(GameObject.Find("Canvas/FunMenu/k2").GetComponent<InputField>().text);
        float k3 = float.Parse(GameObject.Find("Canvas/FunMenu/k3").GetComponent<InputField>().text);
        float b = float.Parse(GameObject.Find("Canvas/FunMenu/b").GetComponent<InputField>().text);
        float[] args = { k1, k2, k3, b };
        Vector2 domain = new Vector2(-5, 5);
        GameObject function = GameObject.Find("Axis/FunctionRender");
        function.GetComponent<FunctionDisplayScript>().args = args;
        function.GetComponent<FunctionDisplayScript>().domain = domain;
        function.GetComponent<FunctionDisplayScript>().draw = true;
        functionMenu.SetActive(false);
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

    public void cancel()
    {
        modelMenu.SetActive(false);
        mainMenu.SetActive(false);
        initMenu.SetActive(true);
        cancelButton.SetActive(false);
        functionMenu.SetActive(false);
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
