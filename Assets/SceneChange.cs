using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void LoadSubtitle()
    {
        Debug.Log("Scene to load: DictationScene");
        SceneManager.LoadScene("DictationScene");
    }


    public void LoadZoom()
    {
        Debug.Log("Scene to load: Zoom");
        SceneManager.LoadScene("Zoom");
    }

    public void LoadSettings()
    {
        Debug.Log("Scene to load: Setting");
        SceneManager.LoadScene("Setting");
    }

}
