// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Microsoft.MixedReality.Toolkit.Input
{
    public class clickAndDisappearImage : BaseInputHandler, IMixedRealityInputActionHandler
    {
        [SerializeField]
        //[Tooltip("Input Action to handle")]
        //private MixedRealityInputAction InputAction = MixedRealityInputAction.None;
        private DateTime t_start, t_end;
        public TakePicture Camera;

        [Tooltip("Area-of-interest object which appears when the image box disappears")]
        public GameObject areaOfInterest;
        public GameObject text;

        #region InputSystemGlobalHandlerListener Implementation

        protected override void RegisterHandlers()
        {
            InputSystem?.RegisterHandler<IMixedRealityInputActionHandler>(this);
        }

        /// <inheritdoc />
        protected override void UnregisterHandlers()
        {
            InputSystem?.UnregisterHandler<IMixedRealityInputActionHandler>(this);
        }

        #endregion InputSystemGlobalHandlerListener Implementation

        void IMixedRealityInputActionHandler.OnActionStarted(BaseInputEventData eventData)
        {
            //t_start = DateTime.Now;
        }
        void IMixedRealityInputActionHandler.OnActionEnded(BaseInputEventData eventData)
        { 

        }

        public void deActive()
        {
            this.gameObject.SetActive(false);
            // reset the material/shader to white and bring back the text
            Camera.Init();
            Renderer renderer = this.gameObject.GetComponent<Renderer>() as Renderer;
            renderer.material.SetTexture("_MainTex", null);
            text.SetActive(true);
        }
    }
}