using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionDisplayScript : MonoBehaviour {
    public float[] args;
    public Vector2 domain;
    public bool draw;
    private int pointcnt;
    private LineRenderer lr;
	// Use this for initialization
	void Start () {
        draw = false;
        pointcnt = 0;
        lr = this.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (draw)
        {
            float step = (domain[1] - domain[0]) / 200;
            for (float z = domain[0]+step; z < domain[1]; z+=step)
            {
                float y = 0f;
                for(int i = 0; i < args.Length; i++)
                {
                    y += args[i] * Mathf.Pow(z, args.Length - i - 1);
                }
                pointcnt++;
                lr.positionCount = pointcnt;
                lr.SetPosition(pointcnt - 1, new Vector3(0, y, z));
            }
            pointcnt = 0;
            draw = false;
        }
	}
}
