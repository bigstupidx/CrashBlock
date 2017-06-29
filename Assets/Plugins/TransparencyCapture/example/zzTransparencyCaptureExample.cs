using System.Collections;
using UnityEngine;
using System.Collections;
using System.IO;

public class zzTransparencyCaptureExample:MonoBehaviour
{
    public Texture2D capturedImage;
    public Transform cameraTransform;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }


    public IEnumerator capture()
    {
        //capture whole screen
        Rect lRect = new Rect(0f,0f,Screen.width,Screen.height);
        if(capturedImage)
            Destroy(capturedImage);

        yield return new WaitForEndOfFrame();
        //After Unity4,you have to do this function after WaitForEndOfFrame in Coroutine
        //Or you will get the error:"ReadPixels was called to read pixels from system frame buffer, while not inside drawing frame"
        capturedImage = zzTransparencyCapture.capture(lRect);
    }

    Vector3 lastMousePosition;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            StartCoroutine(capture());
        if (Input.GetKeyDown(KeyCode.S))
            Destroy(capturedImage);
        if (Input.GetKeyDown(KeyCode.X))
            SaveImageOnDesktop();

            //Update camera position
            Vector3 lTranslate = Input.mousePosition - lastMousePosition;
        lTranslate*=0.15f;
        cameraTransform.Translate(lTranslate);
        lastMousePosition = Input.mousePosition;
    }

    void OnGUI()
    {

        if (capturedImage)
        {
            GUI.DrawTexture(
                new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f),
                capturedImage,
                ScaleMode.ScaleToFit,
                true);
            GUI.color = Color.green;
            GUILayout.Label("press S to clear");
        }

        GUI.color = Color.black;
        GUILayout.Label("Press C to do transparent capturing, please capture those boxes");
        GUILayout.Label("The result won't include background color, and the transparency (alpha value) in scene objects, is also can be captured");
    }

    public void SaveImageOnDesktop()
    {
        StartCoroutine(StartsaveImage());
    }
    // Take a shot immediately
    IEnumerator StartsaveImage()
    {
        yield return UploadPNG();
    }

    IEnumerator UploadPNG()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

       // // Create a texture the size of the screen, RGB24 format
       // int width = Screen.width;
       // int height = Screen.height;
       // Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
      //  capturedImage.ReadPixels(new Rect(0, 0, width, height), 0, 0);
      //  capturedImage.Apply();

        // Encode texture into PNG
        byte[] bytes = capturedImage.EncodeToPNG();
       // Object.Destroy(tex);

        // For testing purposes, also write to a file in the project folder
         File.WriteAllBytes(Application.dataPath + "/SavedScreen.png", bytes);


        // Create a Web Form
     //  WWWForm form = new WWWForm();
     //  form.AddField("frameCount", Time.frameCount.ToString());
     //  form.AddBinaryData("fileUpload", bytes);

       // yield return w;

       // if (w.error != null)
       // {
       //     Debug.Log(w.error);
       // }
       // else
       // {
       //     Debug.Log("Finished Uploading Screenshot");
       // }
    }




}