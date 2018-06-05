using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	public void showFunctionInput()
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
