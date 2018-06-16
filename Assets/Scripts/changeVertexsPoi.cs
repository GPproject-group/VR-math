using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeVertexsPoi : MonoBehaviour {

    public GameObject modelObj;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = modelObj.transform.position;
	}

}
