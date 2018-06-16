namespace VRTK.Examples
{
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public class SelectObjectScript : VRTK_InteractableObject
    {
        public GameObject controllerRight;
        private float accuTime;
        private bool flag;


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            flag = true;
            if (this.tag.Equals("vertex"))
            {
                accuTime = 0;
            }
            if (this.tag.Equals("selected"))
            {
                accuTime = 0;
            }
        }
        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
        }

        protected void Start()
        {
            accuTime = 0;
            flag = true;
        }

        protected override void Update()
        {
            base.Update();
            if (this.tag.Equals("vertex")&&flag)
            {
                accuTime += Time.deltaTime;
                if (accuTime >= 2)
                {
                    this.tag = "selected";
                    GlobalData.selectedVertex.Add(this.gameObject);
                    flag = false;
                    foreach (Transform child in this.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    GameObject effect = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereGreen"));
                    effect.transform.parent = this.transform;
                    effect.transform.localPosition = Vector3.zero;
                }
            }
            else if (this.tag.Equals("selected")&&flag)
            {
                accuTime += Time.deltaTime;
                if (accuTime >= 2)
                {
                    this.tag = "vertex";
                    GlobalData.selectedVertex.Remove(this.gameObject);
                    flag = false;
                    foreach (Transform child in this.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    GameObject effect = (GameObject)Instantiate(Resources.Load("Prefabs/MagicSphereBlue"));
                    effect.transform.parent = this.transform;
                    effect.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}
