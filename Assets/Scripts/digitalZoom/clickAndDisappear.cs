// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.Events;

namespace Microsoft.MixedReality.Toolkit.Input
{
    public class clickAndDisappear : BaseInputHandler, IMixedRealityInputActionHandler
    {
        public TakePicture Camera;
        [SerializeField]
        [Tooltip("Input Action to handle")]
        private MixedRealityInputAction InputAction = MixedRealityInputAction.None;

        [Tooltip("the image box gameobject which appears when area-of-interest disappears")]
        public GameObject imgBox;

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

        }
        void IMixedRealityInputActionHandler.OnActionEnded(BaseInputEventData eventData)
        {
            // set the position and rotation of image box;
            imgBox.transform.position = this.gameObject.transform.position;
            imgBox.transform.rotation = this.gameObject.transform.rotation;

            Camera.TakeAShot();
            // deactivate area-of-interest and activate image box
            this.gameObject.SetActive(false);
            imgBox.SetActive(true);

            Debug.Log("clicked on area-of-interest.");
        }
    }
}