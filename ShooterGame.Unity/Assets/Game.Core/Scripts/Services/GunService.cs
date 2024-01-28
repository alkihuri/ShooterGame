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
    public Transform GunTransform { get; private set; }

    public Transform GetGunTransform()
    {
        return GunTransform;
    }

    public void Innit(IMouseAxesInputService mouseservice, ICameraService cameraservice)
    {

        mouseService = mouseservice;
        cameraService = cameraservice;

    }

    public void InnitBalls(List<IBallService> balls)
    {
        Balls = balls;

        CursorLockMode cursorLockMode = CursorLockMode.Locked;
    }

    public void SetGunTransform(Transform transform)
    {
        GunTransform = transform;
    }

    public void Shoot(float power)
    {

        CurrentBallIndex = (CurrentBallIndex + 1) % Balls.Count;
        Balls[CurrentBallIndex].Show();
        Balls[CurrentBallIndex].Shoot(power, GunTransform.forward);

    }

    public void Update(Transform transform)
    {
        /// rotate transform by y axes  
        GunTransform = transform;
        float mouseX = mouseService.GetMouseX();   
        transform.Rotate(0, mouseX * sensitivity, 0);
        Vector3 currentRotation = transform.eulerAngles; 
        // clamp rotation by y axes beween -130 to -30 
        transform.eulerAngles = currentRotation;
    }
}
