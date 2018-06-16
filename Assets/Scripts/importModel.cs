using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class importModel : MonoBehaviour {

	public string path = "Assets/Resources/models";
	public List<string> files;
	public GameObject importBtn;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		getNames ();
		showButtons ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void getNames(){
		DirectoryInfo folder = new DirectoryInfo (path);
		foreach (FileInfo file in folder.GetFiles("*.obj")) {
			files.Add (file.Name);
		}
	}

	private void showButtons(){
		int cnt = 0;
		int x = 90;
		int y = -45;
		foreach (string filename in files) {
			GameObject btnObj = Instantiate (importBtn) as GameObject;
			btnObj.transform.parent = parent.transform;
			Button btn = btnObj.GetComponent<Button> ();
			btn.transform.Find ("Text").GetComponent<Text> ().text = filename;
			Debug.Log (btn.transform.Find ("Text").GetComponent<Text> ().text);
			btn.onClick.AddListener (delegate() {
				GameObject obj = OBJLoader.LoadOBJFile (path + '/' + filename);
				obj.transform.position = new Vector3 (0, 0, 0);
			});

			btnObj.transform.localScale = new Vector3(1,1,1);
			btnObj.transform.localPosition = new Vector3 (x, y, 0);
			btnObj.transform.localEulerAngles = new Vector3(0,0,0);
			cnt++;
			if (cnt > 2) {
				x = 90;
				y -= 50;
				cnt = 0;
			} else {
				x += 110;
			}
		}
	}
}
