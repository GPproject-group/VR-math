using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class importModel : MonoBehaviour {

	public string path = "Assets/Resources/models";
	public List<string> files;

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
		foreach (string filename in files) {
			GameObject obj = OBJLoader.LoadOBJFile (path + '/' + filename);
			obj.transform.position = new Vector3 (0, 0, 0);
		}
	}
}
