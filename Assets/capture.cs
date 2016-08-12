using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class capture : MonoBehaviour {
    public GameObject HandCursor;
     WebCamTexture wct;
    public GameObject Select;
    public Image Mouseclik;
    public GameObject textcontercaptureshow;
    public float delayclik;
    public float delaycapture;
    public int conterclik;
    public int contercapture;
    public bool oncapture;

    // Use this for initialization
    void Start () {
        delayclik = 0;
        conterclik = 0;
        oncapture = false;
        Select.SetActive(false);
        textcontercaptureshow.SetActive(false);
        textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 3";


    }
	
	// Update is called once per frame
	void Update () {
        delaycapture += Time.deltaTime;
        if (HandCursor.transform.position.x < 0.91 && HandCursor.transform.position.x > 0.7 && HandCursor.transform.position.y < 0.58 && HandCursor.transform.position.y > 0.3)
        {
            Select.SetActive(true);
            delayclik += Time.deltaTime;

            



            if (delayclik > 1f && oncapture == false)
            {
                Debug.Log("conterclik " + conterclik);
                delayclik = 0f;
                conterclik ++;
                if (conterclik == 6)
                {
                    delaycapture = 0;
                    Debug.Log("Capture ");
                    oncapture = true;
                }

                

                if (conterclik == 1)
                {
                    Mouseclik.fillAmount = 0.16f;
                }
                else if (conterclik == 2)
                {
                    Mouseclik.fillAmount = 0.33f;
                }
                else if (conterclik == 3)
                {
                    Mouseclik.fillAmount = 0.49f;
                }
                else if (conterclik == 4)
                {
                    Mouseclik.fillAmount = 0.66f;
                }
                else if (conterclik == 5)
                {
                    Mouseclik.fillAmount = 0.82f;
                }
                else if (conterclik == 6)
                {
                    Mouseclik.fillAmount = 1f;
                }
                else if (conterclik == 7)
                {
                    Mouseclik.fillAmount = 0f;
                    conterclik = 0;
                }

            }
            

        }
        else
        {
            Mouseclik.fillAmount = 0f;
            Select.SetActive(false);
            conterclik = 0;
            delayclik = 0f;
        }

        
       


        if (oncapture == true)
        {
            textcontercaptureshow.SetActive(true);


            if (delaycapture > 1f)
            {
                Debug.Log("contercapure " + contercapture);
                delaycapture = 0f;
                contercapture++;

                if (contercapture == 3)
                {
                    WebCam.TakeSnapshot();
                }


                if (contercapture == 0)
                {
                    textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 3";
                }
                else if (contercapture == 1)
                {
                    textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 2";
                }
                else if (contercapture == 2)
                {
                    textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 1";
                }
                else if (contercapture == 3)
                {
                    textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 0";
                }

                if (contercapture == 4)
                {
                    contercapture = 0;
                    delaycapture = 0;
                    oncapture = false;
                    textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 3";
                    textcontercaptureshow.SetActive(false);
                }
            }


        }




    }


/*
    public void PreCapture()
    {
        Debug.Log("cap1");
        oncapture = true;
        while (contercapture < 4)
        {
            textcontercaptureshow.SetActive(true);
            

            if (delaycapture > 1f)
        {
            Debug.Log("contercapure " + contercapture);
            delaycapture = 0f;
            contercapture++;
               
                if (contercapture == 3)
                {
                    WebCam.TakeSnapshot();
                }


            if (contercapture == 0)
            {
                textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 3";
            }
            else if (contercapture == 1)
            {
                textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 2";
            }
            else if (contercapture == 2)
            {
                textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 1";
            }
            else
            {
                textcontercaptureshow.GetComponent<TextMesh>().text = "Capture 0";
            }
        }

            
        }
        

    }
    */

    /*

    // For saving to the _savepath
     private string _SavePath = "C:/WebcamSnaps/"; //Change the path here!
    int _CaptureCounter = 0;

    public void TakeSnapshot()
    {
        // For saving to the _savepath
        Debug.Log("capture");
        Texture2D snap = new Texture2D(wct.width, wct.height);
        snap.SetPixels(wct.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
    }*/

}
