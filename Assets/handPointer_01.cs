
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class handPointer_01 : MonoBehaviour {

    public Texture2D cursorImage_00;
    public Texture2D cursorImage_01;
    public Texture2D cursorImage_02;
    private Texture2D cursorImage;
    private int cursorWidth = 16;
    private int cursorHeight = 16;
    private string defaultResource = "MousePointer";
    private GameObject target;

    public GameObject leftHandPos;
    public GameObject rightHandPos;
    public GameObject leftShoulderPos;
    public GameObject rightShoulderPos;
    public GameObject leftHipPos;
    public GameObject rightHipPos;

    private float RightHandX;
    private float RightHandY;
    private float xPrevious;
    private float yPrevious;
    private double MoveThreshold = 0.01;
    void Start()
    {
        //Switch off default cursor

        if (!cursorImage_00 || !cursorImage_01 || !cursorImage_02)
        {
            cursorImage = (Texture2D)Resources.Load(defaultResource);
            Debug.Log(cursorImage);
        }
        else Cursor.visible = false;
        //cursorImage = (Texture2D) Instantiate(cursorImage);
    }
    void Update()
    {

        if (rightShoulderPos.transform.position.z - rightHandPos.transform.position.z > 0.01)
        {
            float xScaled = Mathf.Abs((rightHandPos.transform.position.x - rightShoulderPos.transform.position.x) / ((rightShoulderPos.transform.position.x - leftShoulderPos.transform.position.x) * 2)) * Screen.width;
            float yScaled = Mathf.Abs((rightHandPos.transform.position.y - rightHipPos.transform.position.y) / ((rightShoulderPos.transform.position.y - rightHipPos.transform.position.y) * 2)) * Screen.height;

            // the hand has moved enough to update screen position (jitter control / smoothing)
            if (Mathf.Abs(rightHandPos.transform.position.x - xPrevious) > MoveThreshold || Mathf.Abs(rightHandPos.transform.position.y - yPrevious) > MoveThreshold)
            {
                RightHandX = Mathf.Min(Mathf.Max(xScaled, Screen.width), 0);
                RightHandY = Mathf.Min(Mathf.Max(yScaled, Screen.height), 0);

                xPrevious = rightHandPos.transform.position.x;
                yPrevious = rightHandPos.transform.position.y;

                // reset the tracking timer
                //trackingTimerCounter = 10;
            }
        }

        // // Get the left mouse button
        // if(Input.GetMouseButtonDown(0))
        // {          
        // RaycastHit hitInfo;
        // target = GetClickedObject (out hitInfo);

        // if (target != null && target.gameObject.tag =="Draggable")
        // {
        // cursorImage = cursorImage_02;
        // Debug.Log("Hit");
        // }
        // else
        // {
        // cursorImage = cursorImage_01;
        // Debug.Log("Miss");
        // }
        // }

        // // Disable movements on button release
        // if (!Input.GetMouseButton(0))
        // {
        // cursorImage = cursorImage_00;
        // }
        cursorImage = cursorImage_00;
    }

    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
        GUI.DrawTexture(new Rect(RightHandX, RightHandY, cursorWidth, cursorHeight), cursorImage);
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

}
