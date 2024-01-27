using UnityEngine;

public class CameraController : MonoBehaviour, ICameraService
{
    public IMouseAxesInputService inputService;
    [SerializeField,Range(0.1f,100f)] float sensitivity = 2.0f;  

    void Update()
    { 
        float mouseX = inputService.GetMouseX();
        float mouseY = inputService.GetMouseY(); 
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity); 
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 180f);
        transform.eulerAngles = currentRotation;
    }
}
