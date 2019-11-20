using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaOfInterest : MonoBehaviour
{
    [Tooltip("user-specified distance along z axis to the camera")]
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        //this.gameObject.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, distance);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
