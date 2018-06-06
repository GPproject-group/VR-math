using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createModel : MonoBehaviour {


    public Dictionary<string, Vector3[]> showPoint = new Dictionary<string, Vector3[]>(); 
    private MeshFilter filter;
    private Mesh mesh;
    int num;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	}

    public Dictionary<string, Vector3[]> getPoi()
    {
        return showPoint;
    }
    //三角形
    /*
        创造三角形的语句：createTriangle();
        point有6个，前三个是顶点，后三个是三条边中点
    */
    public void createTriangle()
    {
        num = showPoint.Count;
        string objname = "Triangle-" + num;
        GameObject newTriangle = new GameObject(objname);
        newTriangle.AddComponent<MeshFilter>();
        newTriangle.AddComponent<MeshRenderer>();
        newTriangle.name = objname;
        filter = newTriangle.GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;
        // can't access Camera.current
        //newCone.transform.position = Camera.current.transform.position + Camera.current.transform.forward * 5.0f;
        Vector3[] vertices = new Vector3[3 * 2]; // 0..n-1: top, n..2n-1: bottom
        Vector3[] normals = new Vector3[3 * 2];
        Vector2[] uvs = new Vector2[3 * 2];
        Vector3[] Points = new Vector3[3 * 2];
        int[] tris;
        int i;

        for (i = 0; i < 3; i++)
        {
            float angle = 2 * Mathf.PI * i / 3;
            float angleSin = Mathf.Sin(angle);
            float angleCos = Mathf.Cos(angle);

            vertices[i] = new Vector3(3 * angleCos, 3 * angleSin, 0);
            vertices[i + 3] = new Vector3(3 * angleCos, 3 * angleSin, 0);
            normals[i] = new Vector3(0, 0, 1);
            normals[i + 3] = new Vector3(0, 0, 1);
            uvs[i] = new Vector2(1.0f * i / 3, 1);
            uvs[i + 3] = new Vector2(1.0f * i / 3, 0);

            Points[i] = new Vector3(3 * angleCos, 3 * angleSin, 0);
        }
        Points[3] = (vertices[0] + vertices[1]) / 2.0f;
        Points[4] = (vertices[2] + vertices[1]) / 2.0f;
        Points[5] = (vertices[0] + vertices[2]) / 2.0f;

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;

        // create triangles
        // here we need to take care of point order, depending on inside and outside
        int cnt = 0;
        tris = new int[3 * 2];
        tris[cnt++] = 0;
        tris[cnt++] = 1;
        tris[cnt++] = 2;
        tris[cnt++] = 2;
        tris[cnt++] = 1;
        tris[cnt++] = 0;
        mesh.triangles = tris;

        showPoint.Add(objname, Points);
    }
    //四边形
    /*
        创造四边形的语句：createPlane();
        point有8个，前4个是顶点，后4个是4条边中点
    */
    public void createPlane()
    {
        num = showPoint.Count;
        string objname = "Plane-" + num;
        GameObject newPlane = new GameObject(objname);
        newPlane.AddComponent<MeshFilter>();
        newPlane.AddComponent<MeshRenderer>();
        newPlane.name = objname;
        filter = newPlane.GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;
        // can't access Camera.current
        //newCone.transform.position = Camera.current.transform.position + Camera.current.transform.forward * 5.0f;
        Vector3[] vertices = new Vector3[4 * 2]; // 0..n-1: top, n..2n-1: bottom
        Vector3[] normals = new Vector3[4 * 2];
        Vector2[] uvs = new Vector2[4 * 2];
        Vector3[] Points = new Vector3[4 * 2];
        int[] tris;
        int i;

        for (i = 0; i < 4; i++)
        {
            float angle = 2 * Mathf.PI * i / 4;
            float angleSin = Mathf.Sin(angle);
            float angleCos = Mathf.Cos(angle);

            vertices[i] = new Vector3(4 * angleCos, 4 * angleSin, 0);
            vertices[i + 4] = new Vector3(4 * angleCos, 4 * angleSin, 0);
            normals[i] = new Vector3(0, 0, 1);
            normals[i + 4] = new Vector3(0, 0, 1);
            uvs[i] = new Vector2(1.0f * i / 4, 1);
            uvs[i + 4] = new Vector2(1.0f * i / 4, 0);

            Points[i] = new Vector3(4 * angleCos, 4 * angleSin, 0);
        }
        Points[4] = (vertices[0] + vertices[1]) / 2.0f;
        Points[5] = (vertices[1] + vertices[2]) / 2.0f;
        Points[6] = (vertices[2] + vertices[3]) / 2.0f;
        Points[7] = (vertices[3] + vertices[0]) / 2.0f;
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;

        // create triangles
        // here we need to take care of point order, depending on inside and outside
        int cnt = 0;
        tris = new int[3 * 4];
        tris[cnt++] = 0;
        tris[cnt++] = 2;
        tris[cnt++] = 1;

        tris[cnt++] = 0;
        tris[cnt++] = 3;
        tris[cnt++] = 2;

        tris[cnt++] = 4;
        tris[cnt++] = 5;
        tris[cnt++] = 6;

        tris[cnt++] = 4;
        tris[cnt++] = 6;
        tris[cnt++] = 7;

        mesh.triangles = tris;

        showPoint.Add(objname, Points);
    }
    //圆锥
    /*
        创造圆锥的语句：createCone();
        point有7个，第一个顶点，后6个是圆底面的每60度一个点
    */
    public void createCone()
    {
        num = showPoint.Count;
        string objname = "Cube-" + num;
        GameObject newCone = new GameObject(objname);
        newCone.AddComponent<MeshFilter>();
        newCone.AddComponent<MeshRenderer>();
        newCone.name = objname;
        filter = newCone.GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;


        float myRadius = 0.5f;
        int myAngleStep = 20;
        Vector3 myTopCenter = new Vector3(0, 1, 0);
        Vector3 myBottomCenter = Vector3.zero;
        //构建顶点数组和UV数组
        Vector3[] myVertices = new Vector3[360 / myAngleStep * 2 + 2];
        //
        Vector2[] myUV = new Vector2[myVertices.Length];
        Vector3[] Points = new Vector3[7];
        //这里我把锥尖顶点放在了顶点数组最后一个
        myVertices[0] = myBottomCenter;
        myVertices[myVertices.Length - 1] = myTopCenter;
        myUV[0] = new Vector2(0.5f, 0.5f);
        myUV[myVertices.Length - 1] = new Vector2(0.5f, 0.5f);
        Points[0] = new Vector3(0, 1, 0);
        //因为圆上顶点坐标相同，只是索引不同，所以这里循环一般长度即可
        for (int i = 1; i <= (myVertices.Length - 2) / 2; i++)
        {
            float curAngle = i * myAngleStep * Mathf.Deg2Rad;
            float curX = myRadius * Mathf.Cos(curAngle);
            float curZ = myRadius * Mathf.Sin(curAngle);
            myVertices[i] = myVertices[i + (myVertices.Length - 2) / 2] = new Vector3(curX, 0, curZ);
            myUV[i] = myUV[i + (myVertices.Length - 2) / 2] = new Vector2(curX + 0.5f, curZ + 0.5f);
            if(i%3 == 1 && i < 20)
            {
                Points[(i/3)+1] = new Vector3(curX, 0, curZ);
            }
        }
        //构建三角形数组
        int[] myTriangle = new int[(myVertices.Length - 2) * 3];
        for (int i = 0; i <= myTriangle.Length - 3; i = i + 3)
        {
            if (i + 2 < myTriangle.Length / 2)
            {
                myTriangle[i] = 0;
                myTriangle[i + 1] = i / 3 + 1;
                myTriangle[i + 2] = i + 2 == myTriangle.Length / 2 - 1 ? 1 : i / 3 + 2;
            }
            else
            {
                //绘制锥体部分，索引组起始点都为锥尖
                myTriangle[i] = myVertices.Length - 1;
                //锥体最后一个三角形的中间顶点索引值为19
                myTriangle[i + 1] = i == myTriangle.Length - 3 ? 19 : i / 3 + 2;
                myTriangle[i + 2] = i / 3 + 1;
            }
        }

        mesh.vertices = myVertices;
        mesh.triangles = myTriangle;
        mesh.uv = myUV;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        showPoint.Add(objname, Points);
    }
    //棱锥
    /*
        创造棱锥的语句：createPyramid(棱数);
        point有（棱数+1）个，最后一个为顶点，前第一个棱数是底面的每个顶点，然后第二个棱数的是边和底面定点的中点，第三个棱数的是底面棱的中点
    */
    public void createPyramid(int numVertices)
    {
        num = showPoint.Count;
        string objname = "Pyramid-" + num;
        GameObject newCube = new GameObject(objname);
        newCube.AddComponent<MeshFilter>();
        newCube.AddComponent<MeshRenderer>();
        newCube.name = objname;
        filter = newCube.GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;

        float radiusTop = 0f;
        float radiusBottom = 1f;
        float length = 1f;
        bool outside = true;
        bool inside = true;

        int multiplier = (outside ? 1 : 0) + (inside ? 1 : 0);
        int offset = (outside && inside ? 2 * numVertices : 0);
        Vector3[] vertices = new Vector3[2 * multiplier * numVertices]; // 0..n-1: top, n..2n-1: bottom
        Vector3[] normals = new Vector3[2 * multiplier * numVertices];
        Vector2[] uvs = new Vector2[2 * multiplier * numVertices];
        Vector3[] Points = new Vector3[3 * numVertices + 1];
        int[] tris;
        float slope = Mathf.Atan((radiusBottom - radiusTop) / length); // (rad difference)/height
        float slopeSin = Mathf.Sin(slope);
        float slopeCos = Mathf.Cos(slope);
        int i;

        Points[3 * numVertices] = new Vector3( 0, 0, 0);
        for (i = 0; i < numVertices; i++)
        {
            float angle = 2 * Mathf.PI * i / numVertices;
            float angleSin = Mathf.Sin(angle);
            float angleCos = Mathf.Cos(angle);
            float angleHalf = 2 * Mathf.PI * (i + 0.5f) / numVertices; // for degenerated normals at cone tips
            float angleHalfSin = Mathf.Sin(angleHalf);
            float angleHalfCos = Mathf.Cos(angleHalf);

            vertices[i] = new Vector3(radiusTop * angleCos, radiusTop * angleSin, 0);
            vertices[i + numVertices] = new Vector3(radiusBottom * angleCos, radiusBottom * angleSin, length);
            Points[i] = new Vector3(radiusBottom * angleCos, radiusBottom * angleSin, length);
            Points[i + numVertices] = new Vector3(radiusBottom * angleCos / 2, radiusBottom * angleSin / 2, length / 2);

            if (radiusTop == 0)
                normals[i] = new Vector3(angleHalfCos * slopeCos, angleHalfSin * slopeCos, -slopeSin);
            else
                normals[i] = new Vector3(angleCos * slopeCos, angleSin * slopeCos, -slopeSin);
            if (radiusBottom == 0)
                normals[i + numVertices] = new Vector3(angleHalfCos * slopeCos, angleHalfSin * slopeCos, -slopeSin);
            else
                normals[i + numVertices] = new Vector3(angleCos * slopeCos, angleSin * slopeCos, -slopeSin);

            uvs[i] = new Vector2(1.0f * i / numVertices, 1);
            uvs[i + numVertices] = new Vector2(1.0f * i / numVertices, 0);

            if (outside && inside)
            {
                // vertices and uvs are identical on inside and outside, so just copy
                vertices[i + 2 * numVertices] = vertices[i];
                vertices[i + 3 * numVertices] = vertices[i + numVertices];
                uvs[i + 2 * numVertices] = new Vector2(1, 0);
                uvs[i + 3 * numVertices] = new Vector2(0, 1);
            }
            if (inside)
            {
                // invert normals
                normals[i + offset] = new Vector3(0, 0, -1); ;
                normals[i + numVertices + offset] = new Vector3(0, 0, 1);
            }
        }
        for (i = 0; i < numVertices - 1; i++)
        {
            Points[i + 2 * numVertices] = (vertices[i] + vertices[i + 1] )/ 2;
        }

        Points[3 * numVertices - 1] = (vertices[0] + vertices[numVertices - 1] )/ 2;

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;

        // create triangles
        // here we need to take care of point order, depending on inside and outside
        int cnt = 0;
        if (radiusTop == 0)
        {
            // top cone
            tris = new int[numVertices * 3 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = i;
                    if (i == numVertices - 1)
                        tris[cnt++] = numVertices;
                    else
                        tris[cnt++] = i + 1 + numVertices;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    tris[cnt++] = offset + numVertices;
                    tris[cnt++] = i + numVertices;
                    if (i == numVertices - 1 + offset)
                        tris[cnt++] = numVertices + offset;
                    else
                        tris[cnt++] = i + 1 + numVertices;
                }
        }
        else if (radiusBottom == 0)
        {
            // bottom cone
            tris = new int[numVertices * 3 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    tris[cnt++] = i;
                    if (i == numVertices - 1)
                        tris[cnt++] = 0;
                    else
                        tris[cnt++] = i + 1;
                    tris[cnt++] = i + numVertices;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    if (i == numVertices - 1 + offset)
                        tris[cnt++] = offset;
                    else
                        tris[cnt++] = i + 1;
                    tris[cnt++] = i;
                    tris[cnt++] = offset;
                }
        }
        else
        {
            // truncated cone
            tris = new int[numVertices * 6 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    int ip1 = i + 1;
                    if (ip1 == numVertices)
                        ip1 = 0;

                    tris[cnt++] = i;
                    tris[cnt++] = ip1;
                    tris[cnt++] = i + numVertices;

                    tris[cnt++] = ip1 + numVertices;
                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = ip1;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    int ip1 = i + 1;
                    if (ip1 == numVertices + offset)
                        ip1 = offset;

                    tris[cnt++] = ip1;
                    tris[cnt++] = i;
                    tris[cnt++] = offset;

                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = ip1 + numVertices;
                    tris[cnt++] = offset + numVertices;
                }
        }
        mesh.triangles = tris;

        showPoint.Add(objname, Points);
    }
    //棱柱
    /*
        创造棱柱的语句：createCube(棱数);
        point有（棱数*2）个，
        第一个（棱数）个为顶面的顶点，第二个（棱数）个是底面的每个顶点,
        第三个（棱数）个是竖的棱的中点，第四个（棱数）个是上面的边中点,第五个（棱数）个是底面的边中点
    */
    public void createCube(int numVertices)
    {
        num = showPoint.Count;
        string objname = "Cube-" + num;
        GameObject newCube = new GameObject(objname);
        newCube.AddComponent<MeshFilter>();
        newCube.AddComponent<MeshRenderer>();
        newCube.name = objname;
        filter = newCube.GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;

        float radiusTop = 1f;
        float radiusBottom = 1f;
        float length = 1f;
        bool outside = true;
        bool inside = true;

        int multiplier = (outside ? 1 : 0) + (inside ? 1 : 0);
        int offset = (outside && inside ? 2 * numVertices : 0);
        Vector3[] vertices = new Vector3[2 * multiplier * numVertices]; // 0..n-1: top, n..2n-1: bottom
        Vector3[] normals = new Vector3[2 * multiplier * numVertices];
        Vector2[] uvs = new Vector2[2 * multiplier * numVertices];
        Vector3[] Points = new Vector3[5 * numVertices];
        int[] tris;
        float slope = Mathf.Atan((radiusBottom - radiusTop) / length); // (rad difference)/height
        float slopeSin = Mathf.Sin(slope);
        float slopeCos = Mathf.Cos(slope);
        int i;

        for (i = 0; i < numVertices; i++)
        {
            float angle = 2 * Mathf.PI * i / numVertices;
            float angleSin = Mathf.Sin(angle);
            float angleCos = Mathf.Cos(angle);
            float angleHalf = 2 * Mathf.PI * (i + 0.5f) / numVertices; // for degenerated normals at cone tips
            float angleHalfSin = Mathf.Sin(angleHalf);
            float angleHalfCos = Mathf.Cos(angleHalf);

            vertices[i] = new Vector3(radiusTop * angleCos, radiusTop * angleSin, 0);
            vertices[i + numVertices] = new Vector3(radiusBottom * angleCos, radiusBottom * angleSin, length);
            Points[i] = new Vector3(radiusTop * angleCos, radiusTop * angleSin, 0);
            Points[i + numVertices] = new Vector3(radiusBottom * angleCos, radiusBottom * angleSin, length);
            Points[i + 2 * numVertices] = new Vector3((radiusBottom + radiusTop)/ 2 * angleCos, (radiusBottom + radiusTop) / 2 * angleSin, length / 2);

            if (radiusTop == 0)
                normals[i] = new Vector3(angleHalfCos * slopeCos, angleHalfSin * slopeCos, -slopeSin);
            else
                normals[i] = new Vector3(angleCos * slopeCos, angleSin * slopeCos, -slopeSin);
            if (radiusBottom == 0)
                normals[i + numVertices] = new Vector3(angleHalfCos * slopeCos, angleHalfSin * slopeCos, -slopeSin);
            else
                normals[i + numVertices] = new Vector3(angleCos * slopeCos, angleSin * slopeCos, -slopeSin);

            uvs[i] = new Vector2(1.0f * i / numVertices, 1);
            uvs[i + numVertices] = new Vector2(1.0f * i / numVertices, 0);

            if (outside && inside)
            {
                // vertices and uvs are identical on inside and outside, so just copy
                vertices[i + 2 * numVertices] = vertices[i];
                vertices[i + 3 * numVertices] = vertices[i + numVertices];
                uvs[i + 2 * numVertices] = new Vector2(1, 0);
                uvs[i + 3 * numVertices] = new Vector2(0, 1);
            }
            if (inside)
            {
                // invert normals
                normals[i + offset] = new Vector3(0, 0, -1); ;
                normals[i + numVertices + offset] = new Vector3(0, 0, 1);
            }
        }
        for (i = 0; i < numVertices - 1; i++)
        {
            Points[i + 3 * numVertices] = (vertices[i] + vertices[i + 1]) / 2;
            Points[i + 4 * numVertices] = (vertices[i + numVertices] + vertices[i + 1 + numVertices]) / 2;
        }

        Points[4 * numVertices - 1] = (vertices[0] + vertices[numVertices - 1]) / 2;
        Points[5 * numVertices - 1] = (vertices[numVertices] + vertices[2 * numVertices - 1]) / 2;

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;

        // create triangles
        // here we need to take care of point order, depending on inside and outside
        int cnt = 0;
        if (radiusTop == 0)
        {
            // top cone
            tris = new int[numVertices * 3 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = i;
                    if (i == numVertices - 1)
                        tris[cnt++] = numVertices;
                    else
                        tris[cnt++] = i + 1 + numVertices;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    tris[cnt++] = offset + numVertices;
                    tris[cnt++] = i + numVertices;
                    if (i == numVertices - 1 + offset)
                        tris[cnt++] = numVertices + offset;
                    else
                        tris[cnt++] = i + 1 + numVertices;
                }
        }
        else if (radiusBottom == 0)
        {
            // bottom cone
            tris = new int[numVertices * 3 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    tris[cnt++] = i;
                    if (i == numVertices - 1)
                        tris[cnt++] = 0;
                    else
                        tris[cnt++] = i + 1;
                    tris[cnt++] = i + numVertices;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    if (i == numVertices - 1 + offset)
                        tris[cnt++] = offset;
                    else
                        tris[cnt++] = i + 1;
                    tris[cnt++] = i;
                    tris[cnt++] = offset;
                }
        }
        else
        {
            // truncated cone
            tris = new int[numVertices * 6 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    int ip1 = i + 1;
                    if (ip1 == numVertices)
                        ip1 = 0;

                    tris[cnt++] = i;
                    tris[cnt++] = ip1;
                    tris[cnt++] = i + numVertices;

                    tris[cnt++] = ip1 + numVertices;
                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = ip1;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    int ip1 = i + 1;
                    if (ip1 == numVertices + offset)
                        ip1 = offset;

                    tris[cnt++] = ip1;
                    tris[cnt++] = i;
                    tris[cnt++] = offset;

                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = ip1 + numVertices;
                    tris[cnt++] = offset + numVertices;
                }
        }
        mesh.triangles = tris;

        showPoint.Add(objname, Points);
    }
    //圆柱
    /*
        创造圆柱的语句：createCylinder();
        point有8个，前4个为顶面的每90度的顶点，后4个是底面的每90度的顶点
    */
    public void createCylinder()
    {
        num = showPoint.Count;
        string objname = "Cylinder-" + num;
        GameObject newCylinder = new GameObject(objname);
        newCylinder.AddComponent<MeshFilter>();
        newCylinder.AddComponent<MeshRenderer>();
        newCylinder.name = objname;
        filter = newCylinder.GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;

        int numVertices = 20;
        float radiusTop = 1f;
        float radiusBottom = 1f;
        float length = 1f;
        bool outside = true;
        bool inside = true;

        int multiplier = (outside ? 1 : 0) + (inside ? 1 : 0);
        int offset = (outside && inside ? 2 * numVertices : 0);
        Vector3[] vertices = new Vector3[2 * multiplier * numVertices]; // 0..n-1: top, n..2n-1: bottom
        Vector3[] normals = new Vector3[2 * multiplier * numVertices];
        Vector2[] uvs = new Vector2[2 * multiplier * numVertices];
        Vector3[] Points = new Vector3[2 * 4];
        int[] tris;
        float slope = Mathf.Atan((radiusBottom - radiusTop) / length); // (rad difference)/height
        float slopeSin = Mathf.Sin(slope);
        float slopeCos = Mathf.Cos(slope);
        int i;

        for (i = 0; i < numVertices; i++)
        {
            float angle = 2 * Mathf.PI * i / numVertices;
            float angleSin = Mathf.Sin(angle);
            float angleCos = Mathf.Cos(angle);
            float angleHalf = 2 * Mathf.PI * (i + 0.5f) / numVertices; // for degenerated normals at cone tips
            float angleHalfSin = Mathf.Sin(angleHalf);
            float angleHalfCos = Mathf.Cos(angleHalf);

            vertices[i] = new Vector3(radiusTop * angleCos, radiusTop * angleSin, 0);
            vertices[i + numVertices] = new Vector3(radiusBottom * angleCos, radiusBottom * angleSin, length);
            if(i == 0)
            {
                Points[0] = new Vector3(radiusTop * angleCos, radiusTop * angleSin, 0);
                Points[4] = new Vector3(radiusBottom * angleCos, radiusBottom * angleSin, length);
            }
            if(i%5 == 0)
            {
                Points[i/5] = new Vector3(radiusTop * angleCos, radiusTop * angleSin, 0);
                Points[i/5 + 4] = new Vector3(radiusBottom * angleCos, radiusBottom * angleSin, length);
            }

            if (radiusTop == 0)
                normals[i] = new Vector3(angleHalfCos * slopeCos, angleHalfSin * slopeCos, -slopeSin);
            else
                normals[i] = new Vector3(angleCos * slopeCos, angleSin * slopeCos, -slopeSin);
            if (radiusBottom == 0)
                normals[i + numVertices] = new Vector3(angleHalfCos * slopeCos, angleHalfSin * slopeCos, -slopeSin);
            else
                normals[i + numVertices] = new Vector3(angleCos * slopeCos, angleSin * slopeCos, -slopeSin);

            uvs[i] = new Vector2(1.0f * i / numVertices, 1);
            uvs[i + numVertices] = new Vector2(1.0f * i / numVertices, 0);

            if (outside && inside)
            {
                // vertices and uvs are identical on inside and outside, so just copy
                vertices[i + 2 * numVertices] = vertices[i];
                vertices[i + 3 * numVertices] = vertices[i + numVertices];
                uvs[i + 2 * numVertices] = new Vector2(1, 0);
                uvs[i + 3 * numVertices] = new Vector2(0, 1);
            }
            if (inside)
            {
                // invert normals
                normals[i + offset] = new Vector3(0, 0, -1); ;
                normals[i + numVertices + offset] = new Vector3(0, 0, 1);
            }
        }
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;

        // create triangles
        // here we need to take care of point order, depending on inside and outside
        int cnt = 0;
        if (radiusTop == 0)
        {
            // top cone
            tris = new int[numVertices * 3 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = i;
                    if (i == numVertices - 1)
                        tris[cnt++] = numVertices;
                    else
                        tris[cnt++] = i + 1 + numVertices;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    tris[cnt++] = offset + numVertices;
                    tris[cnt++] = i + numVertices;
                    if (i == numVertices - 1 + offset)
                        tris[cnt++] = numVertices + offset;
                    else
                        tris[cnt++] = i + 1 + numVertices;
                }
        }
        else if (radiusBottom == 0)
        {
            // bottom cone
            tris = new int[numVertices * 3 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    tris[cnt++] = i;
                    if (i == numVertices - 1)
                        tris[cnt++] = 0;
                    else
                        tris[cnt++] = i + 1;
                    tris[cnt++] = i + numVertices;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    if (i == numVertices - 1 + offset)
                        tris[cnt++] = offset;
                    else
                        tris[cnt++] = i + 1;
                    tris[cnt++] = i;
                    tris[cnt++] = offset;
                }
        }
        else
        {
            // truncated cone
            tris = new int[numVertices * 6 * multiplier];
            if (outside)
                for (i = 0; i < numVertices; i++)
                {
                    int ip1 = i + 1;
                    if (ip1 == numVertices)
                        ip1 = 0;

                    tris[cnt++] = i;
                    tris[cnt++] = ip1;
                    tris[cnt++] = i + numVertices;

                    tris[cnt++] = ip1 + numVertices;
                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = ip1;
                }
            if (inside)
                for (i = offset + 1; i < numVertices + offset; i++)
                {
                    int ip1 = i + 1;
                    if (ip1 == numVertices + offset)
                        ip1 = offset;

                    tris[cnt++] = ip1;
                    tris[cnt++] = i;
                    tris[cnt++] = offset;

                    tris[cnt++] = i + numVertices;
                    tris[cnt++] = ip1 + numVertices;
                    tris[cnt++] = offset + numVertices;
                }
        }
        mesh.triangles = tris;

        showPoint.Add(objname, Points);
    }

    //球体
    /*
        创造球体的语句：DrawSphere();
        point有1个，为原点
    */
    public Material mat;
    private static Vector3[] directions = {
        Vector3.left,
        Vector3.back,
        Vector3.right,
        Vector3.forward
    };
    public void DrawSphere()
    {
        int subdivisions = 4;
        float radius = 1;
        if (subdivisions > 4)
        {
            subdivisions = 4;
        }
        num = showPoint.Count;
        string objname = "Sphere-" + num;
        GameObject newSphere = new GameObject(objname);
        newSphere.AddComponent<MeshFilter>();
        newSphere.AddComponent<MeshRenderer>();
        newSphere.name = objname;
        filter = newSphere.GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;

        gameObject.GetComponent<MeshRenderer>().material = mat;
        mesh.Clear();

        int resolution = 1 << subdivisions;
        Vector3[] vertices = new Vector3[(resolution + 1) * (resolution + 1) * 4 - 3 * (resolution * 2 + 1)];
        int[] triangles = new int[(1 << (subdivisions * 2 + 3)) * 3];
        CreateOctahedron(vertices, triangles, resolution);

        Vector3[] Points = new Vector3[1];
        Points[0] = new Vector3(0, 0, 0);
        if (radius != 1f)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] *= radius;
            }
        }

        Vector3[] normals = new Vector3[vertices.Length];
        Normalize(vertices, normals);

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;

        showPoint.Add(objname, Points);
    }
    private static void CreateOctahedron(Vector3[] vertices, int[] triangles, int resolution)
    {
        int v = 0, vBottom = 0, t = 0;

        vertices[v++] = Vector3.down;

        for (int i = 1; i <= resolution; i++)
        {
            float progress = (float)i / resolution;
            Vector3 from, to;
            vertices[v++] = to = Vector3.Lerp(Vector3.down, Vector3.forward, progress);
            for (int d = 0; d < 4; d++)
            {
                from = to;
                to = Vector3.Lerp(Vector3.down, directions[d], progress);
                t = CreateLowerStrip(i, v, vBottom, t, triangles);
                v = CreateVertexLine(from, to, i, v, vertices);
                vBottom += i > 1 ? (i - 1) : 0;
            }
            vBottom = v - 1 - i * 4;
        }

        for (int i = resolution - 1; i >= 1; i--)
        {
            float progress = (float)i / resolution;
            Vector3 from, to;
            vertices[v++] = to = Vector3.Lerp(Vector3.up, Vector3.forward, progress);
            for (int d = 0; d < 4; d++)
            {
                from = to;
                to = Vector3.Lerp(Vector3.up, directions[d], progress);
                t = CreateUpperStrip(i, v, vBottom, t, triangles);
                v = CreateVertexLine(from, to, i, v, vertices);
                vBottom += i + 1;
            }
            vBottom = v - 1 - i * 4;
        }

        vertices[vertices.Length - 1] = Vector3.up;

        for (int i = 0; i < 4; i++)
        {
            triangles[t++] = vBottom;
            triangles[t++] = v;
            triangles[t++] = ++vBottom;
        }
    }
    private static int CreateVertexLine(Vector3 from, Vector3 to, int steps, int v, Vector3[] vertices)
    {
        for (int i = 1; i <= steps; i++)
        {
            vertices[v++] = Vector3.Lerp(from, to, (float)i / steps);
        }
        return v;
    }
    private static int CreateLowerStrip(int steps, int vTop, int vBottom, int t, int[] triangles)
    {
        for (int i = 1; i < steps; i++)
        {
            triangles[t++] = vBottom;
            triangles[t++] = vTop - 1;
            triangles[t++] = vTop;

            triangles[t++] = vBottom++;
            triangles[t++] = vTop++;
            triangles[t++] = vBottom;
        }
        triangles[t++] = vBottom;
        triangles[t++] = vTop - 1;
        triangles[t++] = vTop;
        return t;
    }
    private static int CreateUpperStrip(int steps, int vTop, int vBottom, int t, int[] triangles)
    {
        triangles[t++] = vBottom;
        triangles[t++] = vTop - 1;
        triangles[t++] = ++vBottom;
        for (int i = 1; i <= steps; i++)
        {
            triangles[t++] = vTop - 1;
            triangles[t++] = vTop;
            triangles[t++] = vBottom;

            triangles[t++] = vBottom;
            triangles[t++] = vTop++;
            triangles[t++] = ++vBottom;
        }
        return t;
    }
    private static void Normalize(Vector3[] vertices, Vector3[] normals)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            normals[i] = vertices[i] = vertices[i].normalized;
        }
    }
}
