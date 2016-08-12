using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebCam : MonoBehaviour {

    // Use this for initialization
    public string deviceName;
    static WebCamTexture wct;
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        deviceName = devices[0].name;
        wct = new WebCamTexture(deviceName, 400, 300, 12);
        rend.material.mainTexture = wct;
        wct.Play();
    }

    // For photo varibles

    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);

    /*
    void OnClickButton()
    {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
            TakeSnapshot();

    }

*/

    
    // For saving to the _savepath
    static private string _SavePath = "C:/WebcamSnaps/"; //Change the path here!
    static int _CaptureCounter = 0;

   public static void TakeSnapshot()
    {
        Texture2D snap = new Texture2D(wct.width, wct.height);
        snap.SetPixels(wct.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
    }
}
