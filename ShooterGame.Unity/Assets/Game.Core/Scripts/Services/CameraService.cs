using UnityEngine;

public class CameraService : ICameraService
{
    public IMouseAxesInputService InputService;

    public GameObject View { get; private set; }

    [SerializeField, Range(0.1f, 100f)] float sensitivity = 2.0f;

    public Transform Trasform { get; private set; }

    public Vector3 GetCameraForward()
    {
        return Trasform.forward;    
    }

    public Vector3 GetCameraPosition()
    {
        return Trasform.position;
    }

    public void Innit(IMouseAxesInputService inputService, GameObject view)
    {
        InputService = inputService; 
        View = view;    
        Trasform = View.transform;  
    }

     

    
}
