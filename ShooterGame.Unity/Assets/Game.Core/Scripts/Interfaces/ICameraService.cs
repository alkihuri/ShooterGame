using UnityEngine;

public interface ICameraService
{
    Vector3 GetCameraForward();
    Vector3 GetCameraPosition();
    public void Innit(IMouseAxesInputService inputService, GameObject view);
}