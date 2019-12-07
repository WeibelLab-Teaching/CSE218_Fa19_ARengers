using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Prompts : MonoBehaviour
{
    public GameObject text_prompt;
    public GameObject slider_prompt;

    public int time_text_prompt;
    public int time_slider_prompt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        slider_prompt.SetActive(false);
        text_prompt.SetActive(true);
        yield return new WaitForSeconds(time_text_prompt);
        text_prompt.SetActive(false);
        slider_prompt.SetActive(true);
        yield return new WaitForSeconds(time_slider_prompt);
        slider_prompt.SetActive(false);

    }
}
