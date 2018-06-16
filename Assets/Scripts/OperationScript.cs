using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationScript : MonoBehaviour
{
    private int mode;    //0:nothing 1:line  2:plane
    private List<LineRenderer> lrList;
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
        foreach(LineRenderer lr in lrList)
        {
            Destroy(lr);
        }
        foreach(GameObject v in GlobalData.selectedVertex)
        {
            foreach (Transform child in v.transform)
            {
                Destroy(child.gameObject);
            }
            GameObject effect = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereBlue"));
            effect.transform.parent = this.transform;
            effect.transform.localPosition = Vector3.zero;
        }
        GlobalData.selectedVertex.Clear();
        GlobalData.selectedPlane.Clear();
        GlobalData.selectedLine.Clear();
    }

    void Start()
    {
        mode = 0;
        lrList = new List<LineRenderer>();
    }

    void Update()
    {
        if (mode == 1)
        {
            if (GlobalData.selectedVertex.Count == 2)
            {
                Vector3 p1 = GlobalData.selectedVertex[0].transform.position;
                Vector3 p2 = GlobalData.selectedVertex[1].transform.position;
                LineRenderer lr = this.gameObject.AddComponent<LineRenderer>();
                lrList.Add(lr);
                lr.positionCount = 2;
                lr.startWidth = 0.05f;
                lr.endWidth = 0.05f;
                lr.SetPosition(0, p1);
                lr.SetPosition(1, p2);
                Vector3[] line = { p1, p2 };
                GlobalData.selectedLine.Add(line);
            }
        }
        else if (mode == 2)
        {
            if (GlobalData.selectedVertex.Count == 3)
            {
                Vector3 p1 = GlobalData.selectedVertex[0].transform.position;
                Vector3 p2 = GlobalData.selectedVertex[1].transform.position;
                Vector3 p3 = GlobalData.selectedVertex[2].transform.position;
                LineRenderer lr = this.gameObject.AddComponent<LineRenderer>();
                lrList.Add(lr);
                lr.positionCount = 3;
                lr.startWidth = 0.05f;
                lr.endWidth = 0.05f;
                lr.SetPosition(0, p1);
                lr.SetPosition(1, p2);
                lr.SetPosition(2, p3);
                Vector3[] plane = { p1, p2, p3 };
                GlobalData.selectedPlane.Add(plane);
            }
        }
        mode = 0;
    }
}
