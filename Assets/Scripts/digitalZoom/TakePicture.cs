﻿using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.XR.WSA.WebCam;


public class TakePicture : MonoBehaviour
{

    UnityEngine.XR.WSA.WebCam.PhotoCapture photoCaptureObject = null;
    public GameObject quad;

    public void TakeAShot()
    {
       // Debug.Log(WebCam.Mode);
        
        UnityEngine.XR.WSA.WebCam.PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
    }
    void OnPhotoCaptureCreated(UnityEngine.XR.WSA.WebCam.PhotoCapture captureObject)
    {
        photoCaptureObject = captureObject;

        Resolution cameraResolution = UnityEngine.XR.WSA.WebCam.PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

        UnityEngine.XR.WSA.WebCam.CameraParameters c = new UnityEngine.XR.WSA.WebCam.CameraParameters();
        c.hologramOpacity = 0.0f;
        c.cameraResolutionWidth = cameraResolution.width;
        c.cameraResolutionHeight = cameraResolution.height;
        c.pixelFormat = UnityEngine.XR.WSA.WebCam.CapturePixelFormat.BGRA32;

        captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
    }
    private void OnPhotoModeStarted(UnityEngine.XR.WSA.WebCam.PhotoCapture.PhotoCaptureResult result)
    {
        if (result.success)
        {
            // take a picture
            photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
        }
        else
        {
            Debug.LogError("Unable to start photo mode!");
        }
    }

    void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        if (result.success)
        {
            Debug.Log("Photo Captured");
            // Create our Texture2D for use and set the correct resolution
            // GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            Renderer quadRenderer = quad.GetComponent<Renderer>() as Renderer;
            Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
            Texture2D targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

            Debug.Log(cameraResolution.width + " " + cameraResolution.height);

            // Copy the raw image data into our target texture
            photoCaptureFrame.UploadImageDataToTexture(targetTexture);

            Texture2D newImage = CropImage(targetTexture, 0, 0, cameraResolution.width, cameraResolution.height);

            quadRenderer.material = new Material(Shader.Find("Unlit/Texture"));

            //quad.transform.parent = this.transform;
            //  quad.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);

            quadRenderer.material.SetTexture("_MainTex", newImage);
        }
        // Clean up
        Debug.Log("Cleaning it up");
        photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }
    void OnStoppedPhotoMode(UnityEngine.XR.WSA.WebCam.PhotoCapture.PhotoCaptureResult result)
    {
        Debug.Log("Camera closed");
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
    }
    private Texture2D CropImage(Texture2D old, int x, int y, int width, int height)
    {
        // it works, we just need to find the real resolution for the Hololens' camera
        // and crop the correct area we want. 
        Color[] pix = old.GetPixels(0, 0, width, height);
        Texture2D newTexture = new Texture2D(width, height);
        newTexture.SetPixels(pix);
        newTexture.Apply();
        return newTexture;
    }
}
