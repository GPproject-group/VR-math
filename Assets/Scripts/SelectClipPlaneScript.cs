namespace VRTK.Examples
{
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public class SelectClipPlaneScript : VRTK_InteractableObject
    {
        public GameObject controllerRight;
        private float accuTime;
        private bool flag;


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            flag = true;
            accuTime = 0;
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
            if (flag)
            {
                accuTime += Time.deltaTime;
                if (accuTime >= 2)
                {
                    flag = false;
                    this.transform.position = controllerRight.transform.position;
                    Destroy(GetComponent<SelectClipPlaneScript>());
                    VRTK_InteractableObject io = this.gameObject.AddComponent<VRTK_InteractableObject>();
                    io.isGrabbable = true;
                    io.holdButtonToGrab = true;
                    io.isUsable = true;
                    io.pointerActivatesUseAction = true;
                }
            }
        }
    }
}
