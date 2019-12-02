using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Microsoft.CognitiveServices.Speech;
<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> ru_menu_scene

public class Transcribe : MonoBehaviour
{
    // Hook up the two properties below with a Text and Button object in your UI.
    public TMPro.TextMeshPro outputText;

    private object threadLocker = new object();
    private bool waitingForReco;
    private string message;
<<<<<<< HEAD
=======
    private Queue subtitleQueue;
>>>>>>> ru_menu_scene

    private bool micPermissionGranted = false;

    public async void ButtonClick()
    {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        var config = SpeechConfig.FromSubscription("9b841b86d19a46bb9b35701488e3bac3", "westus");

        // Make sure to dispose the recognizer after use!
        using (var recognizer = new SpeechRecognizer(config))
        {
            lock (threadLocker)
            {
                waitingForReco = true;
            }

            // Starts speech recognition, and returns after a single utterance is recognized. The end of a
            // single utterance is determined by listening for silence at the end or until a maximum of 15
            // seconds of audio is processed.  The task returns the recognition text as result.
            // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
<<<<<<< HEAD
            // shot recognition like command or query.
=======
            // shot recognition like command or query. 
>>>>>>> ru_menu_scene
            // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
            var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

            // Checks result.
            string newMessage = string.Empty;
            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                newMessage = result.Text;
            }
            else if (result.Reason == ResultReason.NoMatch)
            {
                newMessage = "NOMATCH: Speech could not be recognized.";
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = CancellationDetails.FromResult(result);
                newMessage = $"CANCELED: Reason={cancellation.Reason} ErrorDetails={cancellation.ErrorDetails}";
            }

            lock (threadLocker)
            {
                message = newMessage;
                waitingForReco = false;
            }
        }
    }

    void Start()
    {
        if (outputText == null)
        {
            Debug.LogError("outputText property is null! Assign a UI Text element to it.");
<<<<<<< HEAD
        }
        else
        {
            // Continue with normal initialization, Text and Button objects are present.
            micPermissionGranted = true;
            message = "";
        }
=======
        }
        else
        {
            // Continue with normal initialization, Text and Button objects are present.
            micPermissionGranted = true;
            message = "";
            subtitleQueue = new Queue();

        }
>>>>>>> ru_menu_scene
    }

    void Update()
    {

        lock (threadLocker)
        {
            if ((!waitingForReco) && micPermissionGranted)
            {
                ButtonClick();
<<<<<<< HEAD
            }
            if (outputText != null)
            {
                outputText.text = message;
            }
=======
                if (message != "")
                    subtitleQueue.Enqueue(message + "\n");
                while (subtitleQueue.Count > 3)
                {
                    subtitleQueue.Dequeue();
                }
                outputText.text = "";
                foreach (var sub in subtitleQueue.ToArray())
                {
                    outputText.text += sub;
                }
            }

>>>>>>> ru_menu_scene
        }
    }
}