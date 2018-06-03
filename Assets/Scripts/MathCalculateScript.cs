using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LLRELATION { VERTICAL,PARALLEL,INTERSECT,VERANDINT,NONE,ERROR};
public enum LPRELATION { VERTICAL,PARALLEL,IN,INTERSECT,ERROR};

public class MathCalculateScript : MonoBehaviour {
    public bool flag;
    public float angle;
	// Use this for initialization
	void Start () {
        flag = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            Vector3[] plane1 = { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 1, 0) };
            Vector3[] plane2 = { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(-1, 0, -2) };
            angle = ppAngle(plane1, plane2);
            flag = false;
        }
        
	}

    //connect two point to a line
    public void connect(Vector3 p1,Vector3 p2)
    {
        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        //        lr.material = new Material(Shader.Find("Assets/Red"));
        UnityEngine.Object matObj = UnityEditor.AssetDatabase.LoadMainAssetAtPath("Assets/Red");
        Material mat = matObj as Material;
        lr.material = mat;
        lr.positionCount = 2;
        lr.SetPosition(0, p1);
        lr.SetPosition(1, p2);
    }

    //calculate length of a segment
    public float segmentLength(Vector3[] line)
    {
        if (line.Length != 2)
        {
            return -1f;
        }
        Vector3 p1 = line[0];
        Vector3 p2 = line[1];
        return Mathf.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y) + (p1.z - p2.z) * (p1.z - p2.z));
    }

    //calculate relation of two lines
    public LLRELATION llRelation(Vector3[] line1, Vector3[] line2)
    {
        if (line1.Length != 2 || line2.Length != 2)
        {
            return LLRELATION.ERROR;
        }
        bool isVer = false;
        //set a proper value
        float epsilonVer = 0.001f, epsilonPara = 0.001f, epsilonInter = 0.001f;
        float angle = Vector3.Angle(line1[0] - line1[1], line2[0] - line2[1]);
        
        //vertical?
        if (Mathf.Abs(90 - angle) < epsilonVer)
        {
            isVer = true;
        }

        //parallel?
        if (angle < epsilonPara) 
        {
            return LLRELATION.PARALLEL;
        }

        //intersect?    (a×b)·c
        if (Mathf.Abs(
            Vector3.Dot(Vector3.Cross(line1[0] - line1[1], line2[0] - line2[1]), line1[0] - line2[0])
            ) < epsilonInter)
        {
            if (isVer)
            {
                return LLRELATION.VERANDINT;
            }
            else
            {
                return LLRELATION.INTERSECT;
            }
        }

        if (isVer)
        {
            return LLRELATION.VERTICAL;
        }

        return LLRELATION.NONE;
    }

    //calculate relation of a line and a plane
    public LPRELATION lpRelation(Vector3[] line,Vector3[] plane)
    {
        if (line.Length != 2 || plane.Length != 3)
        {
            return LPRELATION.ERROR;
        }

        float epsilon = 0.001f;

        //vertical?
        if (Mathf.Abs(Vector3.Dot(line[0] - line[1], plane[0] - plane[1])) < epsilon&&
            Mathf.Abs(Vector3.Dot(line[0] - line[1], plane[2] - plane[1])) < epsilon)
        {
            return LPRELATION.VERTICAL;
        }

        //intersect?
        if(Mathf.Abs(
            Vector3.Dot(Vector3.Cross(plane[0] - plane[1], plane[2] - plane[1]), line[0] - line[1])
            ) > epsilon)
        {
            return LPRELATION.INTERSECT;
        }

        //in?
        if(Mathf.Abs(
            Vector3.Dot(Vector3.Cross(plane[0] - plane[1], plane[2] - plane[1]),line[0]-plane[0])
            ) < epsilon)
        {
            return LPRELATION.IN;
        }
        //parallel
        else
        {
            return LPRELATION.PARALLEL;
        }
    }

    //calculate angle of two lines(0 - 90)
    public float llAngle(Vector3[] line1,Vector3[] line2)
    {
        if (line1.Length != 2 || line2.Length != 2)
        {
            return -1f;
        }
        float angle = Vector3.Angle(line1[0] - line1[1], line2[0] - line2[1]);
        if (angle > 90)
        {
            angle = 180 - angle;
        }
        return angle;
    }

    //calculate angle of two planes(0 - 90)
    public float ppAngle(Vector3[] plane1, Vector3[] plane2)
    {
        if (plane1.Length != 3 || plane2.Length != 3)
        {
            return -1;
        }
        Vector3 normal1 = planeNormal(plane1);
        Vector3 normal2 = planeNormal(plane2);
        float angle = Vector3.Angle(normal1, normal2);
        if (angle > 90)
        {
            angle = 180 - angle;
        }
        return angle;
    }

    //calculate angle of a line and a plane(0 - 90)
    public float lpAngle(Vector3[] line, Vector3[] plane)
    {
        if (line.Length != 2 || plane.Length != 3)
        {
            return -1;
        }
        Vector3 normal = planeNormal(plane);
        float angle = Vector3.Angle(line[0] - line[1], normal);
        return Mathf.Abs(90 - angle);
    }

    private Vector3 planeNormal(Vector3[] plane)
    {
        return Vector3.Cross(plane[0] - plane[1], plane[0] - plane[2]);
    }
}
