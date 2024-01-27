using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsMouseInputService : IMouseAxesInputService
{
    public bool GetFireButtonPressed()
    { 
         return Input.GetMouseButtonDown(0);
    }


    public bool GetFireButtonStillPressed()
    {
        return Input.GetMouseButton(0);
    }

    public bool GetFireButtonReleased()
    {
       return Input.GetMouseButtonUp(0);
    }

    public float GetMouseX()
    {
        return Input.GetAxis("Mouse X");
    }

    public float GetMouseY()
    {
        return Input.GetAxis("Mouse Y");
    }


}
