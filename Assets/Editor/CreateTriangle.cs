using UnityEngine;
using UnityEditor;
using System.Collections;

// an Editor method to create a cone primitive (so far no end caps)
// the top center is placed at (0/0/0)
// the bottom center is placed at (0/0/length)
// if either one of the radii is 0, the result will be a cone, otherwise a truncated cone
// note you will get inevitable breaks in the smooth shading at cone tips
// note the resulting mesh will be created as an asset in Assets/Editor
// Author: Wolfram Kresse
public class CreateTriangle : ScriptableWizard
{

    public float length = 1f;

    [MenuItem("GameObject/Create Other/Triangle")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Triangle", typeof(CreateTriangle));
    }

    void OnWizardCreate()
    {
        GameObject newCone = new GameObject("Triangle");
        string meshName = newCone.name;
        string meshPrefabPath = "Assets/Editor/" + meshName + ".asset";
        Mesh mesh = (Mesh)AssetDatabase.LoadAssetAtPath(meshPrefabPath, typeof(Mesh));
        if (mesh == null)
        {
            mesh = new Mesh();
            mesh.name = meshName;
            // can't access Camera.current
            //newCone.transform.position = Camera.current.transform.position + Camera.current.transform.forward * 5.0f;
            Vector3[] vertices = new Vector3[3*2]; // 0..n-1: top, n..2n-1: bottom
            Vector3[] normals = new Vector3[3*2];
            Vector2[] uvs = new Vector2[3*2];
            int[] tris;
            int i;

            for (i = 0; i < 3; i++)
            {
                float angle = 2 * Mathf.PI * i / 3;
                float angleSin = Mathf.Sin(angle);
                float angleCos = Mathf.Cos(angle);

                vertices[i] = new Vector3(3 * angleCos, 3 * angleSin, 0);
                vertices[i+3] = new Vector3(3 * angleCos, 3 * angleSin, 0);
                normals[i] = new Vector3(0, 0, 1);
                normals[i+3] = new Vector3(0, 0, 1);
                uvs[i] = new Vector2(1.0f * i / 3, 1);
                uvs[i+3] = new Vector2(1.0f * i / 3, 0);
            }
            mesh.vertices = vertices;
            mesh.normals = normals;
            //mesh.uv = uvs;

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
            AssetDatabase.CreateAsset(mesh, meshPrefabPath);
            AssetDatabase.SaveAssets();
        }

        MeshFilter mf = newCone.AddComponent<MeshFilter>();
        mf.mesh = mesh;

        newCone.AddComponent<MeshRenderer>();

        Selection.activeObject = newCone;
    }
}