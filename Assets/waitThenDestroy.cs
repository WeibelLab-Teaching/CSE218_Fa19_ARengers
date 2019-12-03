using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitThenDestroy : MonoBehaviour
{
    [Tooltip("set the time this text show in the screen until it disappears.")]
    public int secondsBeforeDisappear;
    private DateTime t_start, t_end;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        t_start = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if ((DateTime.Now - t_start).TotalSeconds > secondsBeforeDisappear)
                this.gameObject.SetActive(false);
        }
    }
}
