using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsMouseInputService : IMouseAxesInputService
{
    public float GetMouseX()
    {
        return Input.GetAxis("Mouse X");
    }

    public float GetMouseY()
    {
        return Input.GetAxis("Mouse Y");
    }


}
