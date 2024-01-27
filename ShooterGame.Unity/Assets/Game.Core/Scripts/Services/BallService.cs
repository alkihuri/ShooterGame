using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallService : IBallService
{
    public IMouseAxesInputService MouseAxesInputService;

    public ICameraService CameraService;

    public GameObject View { get; set; }

    public void Hide()
    {
        View.transform.position = new Vector3(0, 0, 0);
        View.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        View.GetComponent<Rigidbody>().isKinematic = true;
        View.SetActive(false);
    }

    public void Innit(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService)
    {
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
    }

    public void Innit(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, GameObject view)
    {
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
        View = view;
    }

    public void PhysicUpdate(Rigidbody rBody)
    {
        Debug.DrawLine(rBody.position, rBody.position + rBody.velocity, Color.red, 1);
    }

    public void Shoot(float power)
    {
        View.transform.position = new Vector3(0, 0, 0);
        View.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        View.GetComponent<Rigidbody>().isKinematic = false;
        var force = Mathf.Pow(power, 10);
        force = Mathf.Clamp(force, 1, 50);
        View.GetComponent<Rigidbody>().AddForce(View.transform.forward * force, ForceMode.Impulse);
    }

    public void Show()
    {
        View.SetActive(true);
    }
}
