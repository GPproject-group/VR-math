using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addSimpleModel : MonoBehaviour {

    public GameObject cones;
    public GameObject cubes;
    public GameObject cylinders;
    public GameObject planes;
    public GameObject prism_3;
    public GameObject prism_5;
    public GameObject pyramid_3;
    public GameObject pyramid_4;
    public GameObject pyramid_5;
    public GameObject spheres;
    public GameObject triangles;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addcone()
    {
        //Instantiate(cones);
        GameObject g = Instantiate(cones) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

    }

    public void addcube()
    {
        //Instantiate(cubes);
        GameObject g = Instantiate(cubes) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

    }

    public void addcylinder()
    {
        GameObject g = Instantiate(cylinders) as GameObject;
 //       g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(cylinders);
    }

    public void addplane()
    {
        GameObject g = Instantiate(planes) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(planes);
    }

    public void addprism_3()
    {
        GameObject g = Instantiate(prism_3) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(prism_3);
    }
    public void addprism_5()
    {
        GameObject g = Instantiate(prism_5) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(prism_5);
    }
    public void addpyramid_3()
    {
        GameObject g = Instantiate(pyramid_3) as GameObject;
 //       g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(pyramid_3);
    }
    public void addpyramid_4()
    {
        GameObject g = Instantiate(pyramid_4) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(pyramid_4);
    }
    public void addpyramid_5()
    {
        GameObject g = Instantiate(pyramid_5) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(pyramid_5);
    }
    public void addsphere()
    {
        GameObject g = Instantiate(spheres) as GameObject;
//        g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(spheres);
    }
    public void addtriangle()
    {
        GameObject g = Instantiate(triangles) as GameObject;
 //       g.transform.localScale = new Vector3(1.0f, 2.0f, 3.0f);

        //Instantiate(triangles);
    }

}
