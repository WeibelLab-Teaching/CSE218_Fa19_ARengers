using Microsoft.MixedReality.Toolkit.Input;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class Transcribe : MonoBehaviour
{
    // Unity built-in
    public TMPro.TextMeshPro hypothesis;
    public TMPro.TextMeshPro result;
    public Text status;
    public int mode;
    private DictationRecognizer m_DictationRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            //Debug.LogFormat("Dictation result: {0}", text);
            //m_Recognitions.text += text + "\n";
            result.text = text;
            status.text = "Listening...";
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            //Debug.LogFormat("Dictation hypothesis: {0}", text);
            //m_Hypotheses.text += text;
            hypothesis.text = text;
            status.text = "Thinking...";
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            status.text = "Sleeping...";
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };

        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        if (PhraseRecognitionSystem.Status == SpeechSystemStatus.Running)
        {
            PhraseRecognitionSystem.Shutdown();
        }

        m_DictationRecognizer.AutoSilenceTimeoutSeconds = 100000;

        m_DictationRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
