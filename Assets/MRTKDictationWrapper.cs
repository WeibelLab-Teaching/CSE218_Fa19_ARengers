﻿using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Microsoft.MixedReality.Toolkit.Input
{
    /// <summary>
    /// Script used to start and stop recording sessions in the current dictation system and report the transcribed text via UnityEvents.
    /// For this script to work, a dictation system like 'Windows Dictation Input Provider' must be added to the Data Providers in the Input System profile.
    /// </summary>
    public class MRTKDictationWrapper : BaseInputHandler, IMixedRealityDictationHandler
    {
        [SerializeField]
        [Tooltip("Time length in seconds before the dictation session ends due to lack of audio input in case there was no audio heard in the current session")]
        private float initialSilenceTimeout = 5f;

        [SerializeField]
        [Tooltip("Time length in seconds before the dictation session ends due to lack of audio input.")]
        private float autoSilenceTimeout = 20f;

        [SerializeField]
        [Tooltip("Length in seconds for the dictation service to listen")]
        private int recordingTime = 10;

        [SerializeField]
        [Tooltip("Whether recording should start automatically on start")]
        private bool startRecordingOnStart = false;
        public static bool completed = false;

        private static IMixedRealityDictationSystem dictationSystem;
       
        public TMPro.TextMeshPro hypothesis;
        public TMPro.TextMeshPro result;
        public Text status;
        public int numSentences;

        /// <summary>
        /// Start a recording session in the dictation system.
        /// </summary>
        public void StartRecording()
        {
            if (dictationSystem != null)
            {
                dictationSystem.StartRecording(gameObject, initialSilenceTimeout, autoSilenceTimeout, recordingTime);
            }
        }

        /// <summary>
        /// Stop a recording session in the dictation system.
        /// </summary>
        public void StopRecording()
        {
            if (dictationSystem != null)
            {
                Debug.Log("HERE!!! STOP RECORDING");
                dictationSystem.StopRecording();
            }
        }

        #region InputSystemGlobalHandlerListener Implementation

        /// <inheritdoc />
        protected override void RegisterHandlers()
        {
            InputSystem?.RegisterHandler<IMixedRealityDictationHandler>(this);
        }

        /// <inheritdoc />
        protected override void UnregisterHandlers()
        {
            InputSystem?.UnregisterHandler<IMixedRealityDictationHandler>(this);
        }

        #endregion InputSystemGlobalHandlerListener Implementation

        #region IMixedRealityDictationHandler implementation

        void IMixedRealityDictationHandler.OnDictationHypothesis(DictationEventData eventData)
        {
            //hypothesis.text = eventData.DictationResult;
        }

        void IMixedRealityDictationHandler.OnDictationResult(DictationEventData eventData)
        {
            string[] sentences = eventData.DictationResult.Split(new[] { ". " }, StringSplitOptions.RemoveEmptyEntries);
            string textToShow = "";
            if (sentences.Length > 0 && sentences.Length <= numSentences)
            {
                foreach (string stc in sentences)
                {
                    textToShow += stc + ".\n";
                }
            } else if (sentences.Length > numSentences)
            {
                for (int i=sentences.Length-numSentences; i<sentences.Length; ++i)
                {
                    textToShow += sentences[i] + ".\n";
                }
            }
            result.text = textToShow;
        }

        void IMixedRealityDictationHandler.OnDictationComplete(DictationEventData eventData)
        {
            Debug.Log("Complete!");

            Task.Run( () => {
                while (!dictationSystem.IsReadyToStart) { }
                completed = true;
            });

        }

        void IMixedRealityDictationHandler.OnDictationError(DictationEventData eventData)
        {
            status.text = eventData.DictationResult;
        }

        #endregion IMixedRealityDictationHandler implementation

        #region MonoBehaviour implementation

        protected override void Start()
        {
            base.Start();

            Debug.Log("Start() !!!");
        }

        protected override void Update()
        {
            base.Update();

            if (completed)
            {
                completed = false;
                dictationSystem.StartRecordingAsync(gameObject, initialSilenceTimeout, autoSilenceTimeout, recordingTime);
                //Task.Run(() =>
                //{
                //    //StopRecording();
                //    Debug.Log("Start here!!!");
                //    //dictationSystem.StartRecordingAsync(gameObject, initialSilenceTimeout, autoSilenceTimeout, recordingTime);
                //});

            }
        }

        protected override void OnDisable()
        {
            StopRecording();

            base.OnDisable();
        }

        protected override void OnEnable()
        {
            if (dictationSystem == null)
                dictationSystem = (InputSystem as IMixedRealityDataProviderAccess)?.GetDataProvider<IMixedRealityDictationSystem>();
            Debug.Assert(dictationSystem != null, "No dictation system found. In order to use dictation, add a dictation system like 'Windows Dictation Input Provider' to the Data Providers in the Input System profile");


            base.OnEnable();
            if (startRecordingOnStart)
            {
                StartRecording();
            }

        }



    #endregion MonoBehaviour implementation
}
}
