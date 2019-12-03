using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;

public class imageBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // when the gameobject is active(shown in the view)
        if (this.gameObject.activeSelf)
        {
            this.gameObject.transform.LookAt(this.transform.position + Camera.main.transform.rotation * Vector3.forward,
                                               Camera.main.transform.rotation * Vector3.up);
        }         
    }

    public void deActive()
    {
        this.gameObject.SetActive(false);
    }
}
