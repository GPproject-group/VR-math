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
    public GameObject controllerRight;
	public GameObject initMenu;
	public GameObject cancelBtn;
	public Material mat;
	public Material clipMat;
	public string scale;

	// Use this for initialization
	void Start () {
		getNames ();
		showButtons ();
		scale = "0.005";
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
				for(int i = 0;i<obj.transform.childCount;++i){
					Destroy(obj.transform.GetChild(i).gameObject);
				}
                GameObject vertexobj = new GameObject(obj.name + "-vertex");
				obj.transform.position = new Vector3 (0, 1, 0);
				float scaleFloat = float.Parse(scale);
				obj.transform.localScale = new Vector3(scaleFloat,scaleFloat,scaleFloat);
                obj.tag = "model";
                createModel.modelList.Add(obj);
                Rigidbody rb = obj.AddComponent<Rigidbody>();
                MeshCollider mc = obj.AddComponent<MeshCollider>();
                VRTK.Examples.TouchToPlane ttp = obj.AddComponent<VRTK.Examples.TouchToPlane>();

                rb = obj.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;

				ttp = obj.GetComponent<VRTK.Examples.TouchToPlane>();
                ttp.isGrabbable = true;
                ttp.isUsable = true;
                ttp.pointerActivatesUseAction = true;
                ttp.controllerRight = controllerRight;
				ttp.clipMat = clipMat;


				mc = obj.GetComponent<MeshCollider>();
				mc.convex = true;
				//only for child in import model
				Transform child = obj.transform.GetChild(0);
				obj.AddComponent<MeshFilter>();
				MeshFilter mf = obj.GetComponent<MeshFilter>();
				mf.mesh = child.gameObject.GetComponent<MeshFilter>().mesh;
				obj.AddComponent<MeshRenderer>();
				MeshRenderer mr = obj.GetComponent<MeshRenderer>();
				mr.material = mat;
				mc.sharedMesh = child.gameObject.GetComponent<MeshFilter>().mesh;

				//this is for model without child
				//mc.sharedMesh = obj.GetComponent<MeshFilter>().mesh;

				mc.isTrigger = false;


				createModel.modelList.Add(obj);

				GameObject select = GameObject.Find("Canvas");
				select.GetComponent<UIScript>().selectImportModel();

				parent.SetActive(false);
				initMenu.SetActive(true);
				cancelBtn.SetActive(false);
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
