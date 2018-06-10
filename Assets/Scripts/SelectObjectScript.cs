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
            if (this.tag.Equals("model"))
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
            if (this.tag.Equals("model")&&flag)
            {
                accuTime += Time.deltaTime;
                if (accuTime >= 2)
                {
                    this.tag = "selected";
                    flag = false;
                }
            }
            else if (this.tag.Equals("selected")&&flag)
            {
                accuTime += Time.deltaTime;
                if (accuTime >= 2)
                {
                    this.tag = "model";
                    flag = false;
                }
            }
        }
    }
}
