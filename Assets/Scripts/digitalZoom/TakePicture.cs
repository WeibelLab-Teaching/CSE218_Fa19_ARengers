using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.XR.WSA.WebCam;


public class TakePicture : MonoBehaviour
{

    UnityEngine.XR.WSA.WebCam.PhotoCapture photoCaptureObject = null;
    public GameObject quad ;
    public GameObject areaOfInterest;
    public GameObject text ;
    public Camera cam;
    // Globals
    public int camera_x = 2048;
    public int camera_y = 1152;

    private void Start()
    {
        UnityEngine.XR.WSA.WebCam.PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
    }
    public void Init()
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
            Debug.Log("ready to take photo!!");
            // take a picture
            // photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
        }
        else
        {
            Debug.LogError("Unable to start photo mode!");
        }
    }

    public void TakeAShot(){
        Debug.Log("take a picture!!!");
        Debug.Log(photoCaptureObject != null);
        if (photoCaptureObject != null)
        {
            photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
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

            Texture2D newImage = CropImage(targetTexture, cameraResolution.width/2, cameraResolution.height/2);

            quadRenderer.material = new Material(Shader.Find("Unlit/Texture"));

            //quad.transform.parent = this.transform;
            //  quad.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);

            quadRenderer.material.SetTexture("_MainTex", newImage);
            text.SetActive(false);
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
    private Texture2D CropImage(Texture2D old, int x, int y)
    {
        // it works, we just need to find the real resolution for the Hololens' camera
        // and crop the correct area we want. 
        // 2048, 1152 (w, h) resolution in hololenes

        //RectTransform rt = (RectTransform)areaOfInterest.transform;
        //Debug.Log(rt.rect.width);
        //long areaWidth = (long) (rt.rect.width/2) ;
        //long areaHeight = (long) (rt.rect.height/2) ;

        Renderer area_Collider = areaOfInterest.GetComponent<Renderer>();
        Vector3 area_Size = area_Collider.bounds.size;
        //get the pixel from the camera
        Vector3 low = cam.WorldToScreenPoint( areaOfInterest.transform.position - (area_Size/2) );
        Vector3 high = cam.WorldToScreenPoint(areaOfInterest.transform.position + (area_Size/2) );

        float areaWidth = area_Size.x /2;
        float areaHeight = area_Size.y /2;
        Debug.Log("width:" + areaWidth);
        Debug.Log("Height:" + areaHeight);

        //Color[] pix = old.GetPixels(x-150, y-150, 300, 300);
        //Texture2D newTexture = new Texture2D(300, 300);

        int areaWidth_int = (int) (areaWidth*3000);
        int areaHeight_int = (int) (areaHeight*3000);

        Debug.Log("modified width: " + areaWidth_int);
        Debug.Log("modified heigth: " + areaHeight_int);

        //Color[] pix = old.GetPixels(x-150, y-150, areaWidth_int, areaHeight_int);
        int offset_x = (int) ((camera_x - areaWidth) / 2);
        int offset_y = (int) ((camera_y - areaHeight_int) / 2);
        Color[] pix = old.GetPixels(offset_x, offset_y, areaWidth_int, areaHeight_int);
        Texture2D newTexture = new Texture2D(areaWidth_int, areaHeight_int);

        //        Color[] pix = old.GetPixels(1024- areaWidth, 576- areaHeight, areaWidth * 2, areaHeight * 2);
        //        Texture2D newTexture = new Texture2D(areaWidth * 2, areaHeight * 2);
        newTexture.SetPixels(pix);
        newTexture.Apply();
        return newTexture;
    }
    private Texture2D CropImage_new(Texture2D old, int x, int y)
    {


        Renderer area_Collider = areaOfInterest.GetComponent<Renderer>();
        // unit is in meter
        Vector3 area_Size = area_Collider.bounds.size;

        //get the pixel from the camera
        Vector3 low = cam.WorldToScreenPoint(areaOfInterest.transform.position - (area_Size / 2));
        Vector3 high = cam.WorldToScreenPoint(areaOfInterest.transform.position + (area_Size / 2));

        //Color[] pix = old.GetPixels(x-150, y-150, areaWidth_int, areaHeight_int);
        Vector3 size = high - low;
        Color[] pix = old.GetPixels((int)low.x, (int)low.y, (int)size.x, (int)size.y );
        Texture2D newTexture = new Texture2D((int)size.x, (int)size.y);

        //        Color[] pix = old.GetPixels(1024- areaWidth, 576- areaHeight, areaWidth * 2, areaHeight * 2);
        //        Texture2D newTexture = new Texture2D(areaWidth * 2, areaHeight * 2);
        newTexture.SetPixels(pix);
        newTexture.Apply();
        return newTexture;
    }
}
