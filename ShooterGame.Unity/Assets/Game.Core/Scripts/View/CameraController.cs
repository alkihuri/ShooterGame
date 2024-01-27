using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public ICameraService cameraService;
     
    public void Innit(ICameraService cameraService)
    {
        this.cameraService = cameraService;
    }   
     
}
