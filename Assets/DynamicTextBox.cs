using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;

public class DynamicTextBox : MonoBehaviour
{
    public TextMeshPro textbox;
    public int maxFontSize = 30;
    public int minFontSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void appendText(string text)
    {
        textbox.SetText(textbox.text + text);
    }

    void setText(string text)
    {
        textbox.SetText(text);
    }

    void setFontSize(int fontSize)
    {
        textbox.fontSize = fontSize;
    }

    public void onSliderChange(SliderEventData sliderVal)
    {
        int fontSize = (int) (sliderVal.NewValue * (maxFontSize - minFontSize) + minFontSize);
        setFontSize(fontSize);
    }
}


