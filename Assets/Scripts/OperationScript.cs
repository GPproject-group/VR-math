using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationScript : MonoBehaviour
{
    private int mode;    //0:nothing 1:line  2:plane
    private  List<GameObject> lrobjList;

    public Material mat;
    public GameObject controllerRight;
	public GameObject character;
    public void connectToLine()
    {
        mode = 1;
    }

    public void connectToPlane()
    {
        mode = 2;
    }
    public void midpoint()
    {
        if (GlobalData.selectedVertex.Count == 2)
        {
            GameObject midpointObj = new GameObject("new point");
            GlobalData.selectedMidpoint.Add(midpointObj);
            midpointObj.transform.position = (GlobalData.selectedVertex[0].transform.position + GlobalData.selectedVertex[1].transform.position)/2;
            midpointObj.tag = "selected";
            GameObject effect0 = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereGreen"));
            effect0.transform.parent = midpointObj.transform;
            effect0.transform.localPosition = Vector3.zero;
            midpointObj.AddComponent<SphereCollider>();
            midpointObj.AddComponent<ChangeMaterialScript>();
            midpointObj.AddComponent<VRTK.Examples.SelectObjectScript>();
            SphereCollider sphereCol = midpointObj.GetComponent<SphereCollider>();
            sphereCol.isTrigger = false;
            sphereCol.radius = 0.1f;

            VRTK.Examples.SelectObjectScript selObjSrc = midpointObj.GetComponent<VRTK.Examples.SelectObjectScript>();
            selObjSrc.holdButtonToGrab = false;
            selObjSrc.isUsable = true;
            selObjSrc.pointerActivatesUseAction = true;
            selObjSrc.controllerRight = controllerRight;

            foreach (GameObject v in GlobalData.selectedVertex)
            {
                v.tag = "vertex";
                foreach (Transform child in v.transform)
                {
                    Destroy(child.gameObject);
                }
                GameObject effect = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereBlue"));
                effect.transform.parent = v.transform;
                effect.transform.localPosition = Vector3.zero;
            }
            GlobalData.selectedVertex.Clear();
        }
    }
    public void reset()
    {
        foreach(GameObject obj in lrobjList)
        {
            Destroy(obj);
        }
        foreach(GameObject v in GlobalData.selectedVertex)
        {
            v.tag = "vertex";
            foreach (Transform child in v.transform)
            {
                Destroy(child.gameObject);
            }
            GameObject effect = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereBlue"));
            effect.transform.parent = v.transform;
            effect.transform.localPosition = Vector3.zero;
        }
        foreach (GameObject v in GlobalData.selectedMidpoint)
        {
            Destroy(v);
        }
        GlobalData.selectedVertex.Clear();
        GlobalData.selectedPlane.Clear();
        GlobalData.selectedLine.Clear();
        GlobalData.selectedMidpoint.Clear();
    }

    public void destroyLr()
    {
        foreach (GameObject obj in lrobjList)
        {
            Destroy(obj);
        }
		character.GetComponent<charEvent> ().speakSomething ("模型已清空");
    }

    void Start()
    {
        mode = 0;
        lrobjList = new List<GameObject>();
    }

    void Update()
    {
        if (mode == 1)
        {
            if (GlobalData.selectedVertex.Count == 2)
            {
                Vector3 p1 = GlobalData.selectedVertex[0].transform.position;
                Vector3 p2 = GlobalData.selectedVertex[1].transform.position;
                GameObject obj = new GameObject();
                LineRenderer lr = obj.AddComponent<LineRenderer>();
                lrobjList.Add(obj);
                lr.positionCount = 2;
                lr.startWidth = 0.05f;
                lr.endWidth = 0.05f;
                lr.SetPosition(0, p1);
                lr.SetPosition(1, p2);
                lr.material = mat;
                Vector3[] line = { p1, p2 };
                GlobalData.selectedLine.Add(line);
                foreach (GameObject v in GlobalData.selectedVertex)
                {
                    v.tag = "vertex";
                    foreach (Transform child in v.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    GameObject effect = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereBlue"));
                    effect.transform.parent = v.transform;
                    effect.transform.localPosition = Vector3.zero;
                }
                GlobalData.selectedVertex.Clear();
            }
        }
        else if (mode == 2)
        {
            if (GlobalData.selectedVertex.Count == 3)
            {
                Vector3 p1 = GlobalData.selectedVertex[0].transform.position;
                Vector3 p2 = GlobalData.selectedVertex[1].transform.position;
                Vector3 p3 = GlobalData.selectedVertex[2].transform.position;

                /*GameObject obj = new GameObject();
                LineRenderer lr = obj.AddComponent<LineRenderer>();
                lrobjList.Add(obj);
                lr.loop = true;
                lr.positionCount = 3;
                lr.startWidth = 0.05f;
                lr.endWidth = 0.05f;
                lr.SetPosition(0, p1);
                lr.SetPosition(1, p2);
                lr.SetPosition(2, p3);*/
                GameObject obj = new GameObject();
                obj.AddComponent<MeshFilter>();
                obj.AddComponent<MeshRenderer>();
                lrobjList.Add(obj);
                MeshFilter filter = obj.GetComponent<MeshFilter>();
                Mesh mesh = new Mesh();
                filter.mesh = mesh;
                Vector3[] vertices = new Vector3[3 * 2];
                Vector2[] uvs = new Vector2[3 * 2];
                int[] tris;
                int i;

                vertices[0] = p1;
                vertices[3] = p1;
                vertices[1] = p2;
                vertices[4] = p2;
                vertices[2] = p3;
                vertices[5] = p3;
                for (i = 0; i < 3; i++)
                {
                    uvs[i] = new Vector2(1.0f * i / 3, 1);
                    uvs[i + 3] = new Vector2(1.0f * i / 3, 0);
                }
                mesh.vertices = vertices;
                mesh.uv = uvs;
                
                int cnt = 0;
                tris = new int[3 * 2];
                tris[cnt++] = 0;
                tris[cnt++] = 2;
                tris[cnt++] = 1;
                tris[cnt++] = 3;
                tris[cnt++] = 4;
                tris[cnt++] = 5;
                mesh.triangles = tris;
                mesh.RecalculateNormals();
                obj.GetComponent<MeshRenderer>().material = mat;

                Vector3[] plane = { p1, p2, p3 };
                GlobalData.selectedPlane.Add(plane);
                foreach (GameObject v in GlobalData.selectedVertex)
                {
                    v.tag = "vertex";
                    foreach (Transform child in v.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    GameObject effect = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereBlue"));
                    effect.transform.parent = v.transform;
                    effect.transform.localPosition = Vector3.zero;
                }
                GlobalData.selectedVertex.Clear();
            }
        }
        mode = 0;
    }
}
