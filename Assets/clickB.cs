using UnityEngine;
using System.Collections;

public class clickB : MonoBehaviour {

    public GameObject a;
    public bool b;
    // Use this for initialization

    
    void Start()
    {
        b = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ONCLICKB1()
    {

        if  (b == false)
        {
           a.SetActive(true);
            b = true;
        }
        else
        {
            a.SetActive(false);
            b = false;
        }
    }
}
