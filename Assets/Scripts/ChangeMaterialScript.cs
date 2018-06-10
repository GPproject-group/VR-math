using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialScript : MonoBehaviour {
    public Material selectedMaterial;
    public Material defaultMaterial;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.tag.Equals("selected"))
        {
            this.GetComponent<Renderer>().material = selectedMaterial;
        }
        if (this.tag.Equals("model"))
        {
            this.GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}
