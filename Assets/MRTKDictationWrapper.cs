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

        private IMixedRealityDictationSystem dictationSystem;

        public TMPro.TextMeshPro hypothesis;
        public TMPro.TextMeshPro result;
        public Text status;

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
            hypothesis.text = eventData.DictationResult;
        }

        void IMixedRealityDictationHandler.OnDictationResult(DictationEventData eventData)
        {
            //result.text = eventData.DictationResult;
            Debug.Log(eventData.DictationResult);
        }

        void IMixedRealityDictationHandler.OnDictationComplete(DictationEventData eventData)
        {
            status.text = eventData.DictationResult;
            Debug.Log("Complete!");
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

            dictationSystem = (InputSystem as IMixedRealityDataProviderAccess)?.GetDataProvider<IMixedRealityDictationSystem>();
            Debug.Assert(dictationSystem != null, "No dictation system found. In order to use dictation, add a dictation system like 'Windows Dictation Input Provider' to the Data Providers in the Input System profile");

            if (startRecordingOnStart)
            {
                StartRecording();
            }
        }

        protected override void OnDisable()
        {
            StopRecording();

            base.OnDisable();
        }

        #endregion MonoBehaviour implementation
    }
}