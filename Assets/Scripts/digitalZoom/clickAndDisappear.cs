// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Microsoft.MixedReality.Toolkit.Input
{
    public class clickAndDisappear : BaseInputHandler, IMixedRealityInputActionHandler
    {
        public TakePicture Camera;

        [Tooltip("audio source gameobject of camera shutter click")]
        public GameObject shutterSound;

        public GameObject textInstrut;

        /*[SerializeField]
        [Tooltip("Input Action to handle")]
        private MixedRealityInputAction InputAction = MixedRealityInputAction.None;*/

        [Tooltip("the image box gameobject which appears when area-of-interest disappears")]
        public GameObject imgBox;


        private DateTime t_start, t_end;

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
            t_start = DateTime.Now;
        }

        void IMixedRealityInputActionHandler.OnActionEnded(BaseInputEventData eventData)
        {
            t_end = DateTime.Now;
            // when hold is less than 1 second, treat as a click behaviour
            if ((t_end - t_start).TotalSeconds < 0.5)
            {
                // set the position and rotation of image box;
                imgBox.transform.position = this.gameObject.transform.position;
                imgBox.transform.rotation = this.gameObject.transform.rotation;

                // click sound
                shutterSound.GetComponent<AudioSource>().Play();

                // take a shot
                Camera.TakeAShot();

                // deactivate area-of-interest and activate image box
                this.gameObject.SetActive(false);
                textInstrut.SetActive(false);
                imgBox.SetActive(true);

                Debug.Log("clicked on area-of-interest.");
            }
        }
    }
}