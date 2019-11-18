using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void LoadSubtitle()
    {
        Debug.Log("Scene to load: Subtitle");
        SceneManager.LoadScene("Init scene");
    }


    public void LoadZoom()
    {
        Debug.Log("Scene to load: Zoom");
        SceneManager.LoadScene("UI scene");
    }

    public void LoadSettings()
    {
        Debug.Log("Scene to load: Settings");
        SceneManager.LoadScene("Settings");
    }

}
