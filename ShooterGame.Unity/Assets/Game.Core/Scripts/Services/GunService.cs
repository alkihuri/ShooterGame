using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class GunService : IGunService
{
    private IMouseAxesInputService mouseService;
    private ICameraService cameraService;
    [SerializeField, Range(0.1f, 100f)] float sensitivity = 2.0f;

    public List<IBallService> Balls { get; set; }

    public int CurrentBallIndex { get; set; } = 0;
    public Transform Trasform { get; private set; }

    public void Innit(IMouseAxesInputService mouseservice, ICameraService cameraservice)
    {

        mouseService = mouseservice;
        cameraService = cameraservice;

    }

    public void InnitBalls(List<IBallService> balls)
    {
        Balls = balls;
    }

    public void Shoot(float power)
    {
       
        CurrentBallIndex = (CurrentBallIndex + 1) % Balls.Count;
        Balls[CurrentBallIndex].Show();
        Balls[CurrentBallIndex].Shoot(power);

    }

    public void Update(Transform transform)
    {
        Trasform = transform;
        float mouseX = mouseService.GetMouseX();
        float mouseY = mouseService.GetMouseY();
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity);
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 180f);
        transform.eulerAngles = currentRotation;
    }
}
