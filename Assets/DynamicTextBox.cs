using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicTextBox : MonoBehaviour
{
    public TextMeshPro textbox;
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

}
