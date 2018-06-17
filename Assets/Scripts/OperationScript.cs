using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationScript : MonoBehaviour
{
    private int mode;    //0:nothing 1:line  2:plane
    private List<GameObject> lrobjList;
    public void connectToLine()
    {
        mode = 1;
    }

    public void connectToPlane()
    {
        mode = 2;
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
        GlobalData.selectedVertex.Clear();
        GlobalData.selectedPlane.Clear();
        GlobalData.selectedLine.Clear();
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
                GameObject obj = new GameObject();
                LineRenderer lr = obj.AddComponent<LineRenderer>();
                lrobjList.Add(obj);
                lr.loop = true;
                lr.positionCount = 3;
                lr.startWidth = 0.05f;
                lr.endWidth = 0.05f;
                lr.SetPosition(0, p1);
                lr.SetPosition(1, p2);
                lr.SetPosition(2, p3);
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
